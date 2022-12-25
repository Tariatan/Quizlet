using CSCore.MediaFoundation;
using CSCore.SoundOut;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using System.Text;
using System.Windows.Forms;

namespace Quizlet
{
    public partial class Quizlet : Form
    {
        private List<string> m_Files;
        private List<Tuple<string, string>> m_Quiz = new List<Tuple<string, string>>();
        private Tuple<string, string> m_CurrentPair;

        private Timer mWordTimer = new Timer();
        private Timer mDescrTimer = new Timer();
        
        private NAudio.Wave.WaveOut mPlayer = new NAudio.Wave.WaveOut();
        private Random mRand = new Random();
        private Mp3FileReader mMp3File = null;

        private SpeechSynthesizer       mSpeech = new SpeechSynthesizer();
        private CSCore.SoundOut.WaveOut mSpeaker = new CSCore.SoundOut.WaveOut();
        private MemoryStream            mSpeechStream = null;
        private MediaFoundationDecoder  mSpeechDecoder = null;
        private WaveOutDevice           AUDIO_DEVICE_TV = null;
        private WaveOutDevice           AUDIO_DEVICE_PC = null;

        private const int DELAY_INTERVAL_PER_LETTER_MS = 180;
        private const int MIN_DISPLAY_INTERVAL_MS = 5000;

        private bool mMuted = false;

        public Quizlet(List<string> files, int audioDeviceId)
        {
            m_Files = files;

            foreach (var device in WaveOutDevice.EnumerateDevices())
            {
                if(device.Name.Contains("SONY"))
                {
                    AUDIO_DEVICE_TV = new WaveOutDevice(device.DeviceId);
                }
                else if(device.Name.Contains("Realtek"))
                {
                    AUDIO_DEVICE_PC = new WaveOutDevice(device.DeviceId);
                }
            }

            if((AUDIO_DEVICE_TV != null) && (audioDeviceId == AUDIO_DEVICE_TV.DeviceId))
            {
                mPlayer.DeviceNumber = AUDIO_DEVICE_TV.DeviceId;
                mSpeaker.Device = AUDIO_DEVICE_TV;
            }
            else if(AUDIO_DEVICE_PC != null)
            {
                mPlayer.DeviceNumber = AUDIO_DEVICE_PC.DeviceId;
                mSpeaker.Device = AUDIO_DEVICE_PC;
            }

            mSpeech.SelectVoice("Microsoft Zira Desktop");
            mSpeech.Volume = 100;  // (0 - 100)
            mSpeech.Rate = 0;     // (-10 - 10)

            foreach (InstalledVoice voice in mSpeech.GetInstalledVoices())
            {
                VoiceInfo info = voice.VoiceInfo;
            }

            InitializeComponent();
        }
        private void Quizlet_Load(object sender, EventArgs e)
        {
            foreach(var file in m_Files)
            {
                readFile(file);
            }

            mWordTimer.Tick += new EventHandler(quizDescription);
            mWordTimer.Interval = DELAY_INTERVAL_PER_LETTER_MS;
            mWordTimer.Enabled = false;

            mDescrTimer.Tick += new EventHandler(quizWord);
            mDescrTimer.Interval = DELAY_INTERVAL_PER_LETTER_MS;
            mDescrTimer.Enabled = false;

            quizWord(null, null);
        }
        private void readFile(string file)
        {
            const Int32 BufferSize = 256;

            using (var fileStream = File.OpenRead(file))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String line;
                string sWord = "";
                string sDescr = "";
                while ((line = streamReader.ReadLine()) != null)
                {
                    if(line == "")
                    {
                        if(sWord != "" && sDescr != "")
                        {
                            m_Quiz.Add(new Tuple<string, string>(sWord, sDescr));
                        }
                        sWord = "";
                        sDescr = "";
                    }
                    if((line != "") && (sWord == ""))
                    {
                        sWord = line;
                    }
                    else if((line != "") && (sWord != ""))
                    {
                        if(sDescr != "")
                        {
                            sDescr += "\n";
                        }
                        sDescr += line;
                    }
                }
            }
        }
        private void quizWord(Object sender, EventArgs e)
        {
            mDescrTimer.Enabled = false;

            m_CurrentPair = m_Quiz[mRand.Next(m_Quiz.Count)];

            m_lblText.Text = m_CurrentPair.Item1;
            m_lblHint.Text = "";

            mWordTimer.Interval = Math.Max(DELAY_INTERVAL_PER_LETTER_MS * m_lblText.Text.Length, MIN_DISPLAY_INTERVAL_MS);
            mWordTimer.Enabled = true;

            readoutWord();
        }
        private void quizDescription(Object sender, EventArgs e)
        {
            mWordTimer.Enabled = false;

            m_lblText.Text = m_CurrentPair.Item2;
            m_lblHint.Text = m_CurrentPair.Item1;
            m_lblHint.Location = new System.Drawing.Point((this.Size.Width / 2) - (m_lblHint.Size.Width / 2), m_lblHint.Location.Y);

            mDescrTimer.Interval = Math.Max(DELAY_INTERVAL_PER_LETTER_MS * m_lblText.Text.Length, MIN_DISPLAY_INTERVAL_MS);
            mDescrTimer.Enabled = true;

            readoutDescription();
        }
        private void readoutWord()
        {
            if (mMuted)
            {
                return;
            }

            var name = m_CurrentPair.Item1.Replace("/", " ");
            if (!playAudioFile("readout\\" + name + ".mp3"))
            {
                speak(m_CurrentPair.Item1);
            }
        }
        private void readoutDescription()
        {
            if (mMuted)
            {
                return;
            }

            var name = m_CurrentPair.Item1.Replace("/", " ");
            if(!playAudioFile("readout\\" + name + "_d.mp3"))
            {
                speak(m_CurrentPair.Item2);
            }
        }
        private void Quizlet_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.M:
                    toggleMute();
                    break;
                case Keys.A:
                    toggleAudioDevice();
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }
        private void toggleMute()
        {
            mMuted = !mMuted;
            picAudio.Image = mMuted ? global::Quizlet.Properties.Resources.audio_off : global::Quizlet.Properties.Resources.audio_on;
            if(mMuted)
            {
                stopAudioFile();
                stopSpeak();
            }
        }
        private void toggleAudioDevice()
        {
            mSpeaker.Device = null;

            if (mSpeaker.Device.DeviceId == AUDIO_DEVICE_TV.DeviceId)
            {
                mSpeaker.Device = AUDIO_DEVICE_PC;
                mPlayer.DeviceNumber = AUDIO_DEVICE_PC.DeviceId;
            }
            else
            {
                mSpeaker.Device = AUDIO_DEVICE_TV;
                mPlayer.DeviceNumber = AUDIO_DEVICE_TV.DeviceId;
            }
        }
        private bool playAudioFile(string fileName)
        {
            if(!File.Exists(fileName))
            {
                return false;
            }

            stopAudioFile();
            mMp3File = new Mp3FileReader(fileName);
            mPlayer.Init(mMp3File);
            mPlayer.PlaybackStopped += (sender, evn) => { stopAudioFile(); };
            mPlayer.Play();

            return true;
        }
        private void stopAudioFile()
        {
            mPlayer.Stop();
            if (mMp3File != null)
            {
                mMp3File.Flush();
                mMp3File.Dispose();
                mMp3File = null;

                System.GC.Collect();
            }
        }
        private void speak(string text)
        {
            stopSpeak();

            mSpeech.SelectVoice("Microsoft Zira Desktop");
            mSpeechStream = new MemoryStream();
            mSpeech.SetOutputToWaveStream(mSpeechStream);
            mSpeech.Speak(text);

            if(mSpeechStream.Capacity == 256)
            {
                stopSpeak();

                mSpeech.SelectVoice("Microsoft Irina Desktop");
                mSpeechStream = new MemoryStream();
                mSpeech.SetOutputToWaveStream(mSpeechStream);
                mSpeech.Speak(text);
            }

            mSpeechDecoder = new MediaFoundationDecoder(mSpeechStream);
            try
            {
                mSpeaker.Initialize(mSpeechDecoder);
                mSpeaker.Play();
            }
            catch
            {
                stopSpeak();
            }
        }
        private void stopSpeak()
        {
            if(mSpeaker.PlaybackState != CSCore.SoundOut.PlaybackState.Stopped)
            {
                mSpeaker.Stop();
            }
            else if(mSpeaker.WaveSource != null)
            {
                mSpeaker.Pause();
            }

            if (mSpeechStream != null)
            {
                mSpeechStream.Flush();
                mSpeechStream.Dispose();
                mSpeechStream = null;

                System.GC.Collect();
            }

            if(mSpeechDecoder != null)
            {
                mSpeechDecoder.Dispose();
                mSpeechDecoder = null;

                System.GC.Collect();
            }
        }
    }
}

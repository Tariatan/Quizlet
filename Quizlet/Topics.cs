using CSCore.SoundOut;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace Quizlet
{
    public partial class Topics : Form
    {
        public List<string> Files { get; set; }
        public int AudioDeviceId { get; set; }
        public class ListBoxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }
        }
        public class CheckBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
        }
        public Topics()
        {
            Files = new List<string>();
            InitializeComponent();
        }
        private void Topics_Load(object sender, EventArgs e)
        {
            foreach (var device in WaveOutDevice.EnumerateDevices())
            {
                var deviceName = device.Name.Substring(0, device.Name.IndexOf("("));
                var item = new CheckBoxItem { Text = deviceName, Value = device.DeviceId };
                if (device.Name.Contains("Philips"))
                {
                    m_AudioDeviceCmb.Items.Insert(0, item);
                }
                else
                {
                    m_AudioDeviceCmb.Items.Add(item);
                }
            }
            m_AudioDeviceCmb.SelectedIndex = 0;

            m_lstTopics.DisplayMember = "Text";
            m_lstTopics.ValueMember = "Value";

            m_AudioDeviceCmb.DisplayMember = "Text";
            m_AudioDeviceCmb.ValueMember = "Value";

            m_btnStart.Enabled = false;

            var Files = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\vocabulary");
            foreach (var file in Files)
            {
                var extStartPos = file.LastIndexOf('.') + 1;
                string ext = "";
                if (extStartPos > 0)
                {
                    ext = file.Substring(extStartPos).ToUpper();
                }

                var name = file.Substring(file.LastIndexOf('\\') + 1, file.LastIndexOf('.') - file.LastIndexOf('\\') - 1);

                if(ext.Equals("TXT"))
                {
                    m_lstTopics.Items.Add(new ListBoxItem { Text = name, Value = file });
                }
            }
        }
        private void m_btnStart_Click(object sender, EventArgs e)
        {
            foreach (object itemChecked in m_lstTopics.CheckedItems)
            {
                var castedItem = itemChecked as ListBoxItem;
                Files.Add(castedItem.Value);
            }
            this.Close();
        }
        private void m_checkAll_CheckedChanged(object sender, EventArgs e)
        {
            for(int i = 0; i < m_lstTopics.Items.Count; ++i)
            {
                m_lstTopics.SetItemChecked(i, m_checkAll.Checked);
            }

            updateStartBtnState();
        }
        private void updateStartBtnState()
        {
            m_btnStart.Enabled = (m_lstTopics.CheckedItems.Count > 0);
        }
        private void Topics_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                return;
            }
        }
        private void m_AudioDeviceCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            var castedItem = m_AudioDeviceCmb.SelectedItem as CheckBoxItem;
            AudioDeviceId = castedItem.Value;
        }
        private void m_lstTopics_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateStartBtnState();
        }
    }
}

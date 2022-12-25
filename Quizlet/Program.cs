using System;
using System.Windows.Forms;

namespace Quizlet
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Topics topics = new Topics();
            Application.Run(topics);

            if(topics.Files.Count > 0)
            {
                Application.Run(new Quizlet(topics.Files, topics.AudioDeviceId));
            }
        }
    }
}

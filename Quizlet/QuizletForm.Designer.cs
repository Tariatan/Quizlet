namespace Quizlet
{
    partial class Quizlet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Quizlet));
            this.m_lblText = new System.Windows.Forms.Label();
            this.picAudio = new System.Windows.Forms.PictureBox();
            this.m_lblHint = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picAudio)).BeginInit();
            this.SuspendLayout();
            // 
            // m_lblText
            // 
            this.m_lblText.BackColor = System.Drawing.Color.Transparent;
            this.m_lblText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblText.Font = new System.Drawing.Font("Microsoft PhagsPa", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_lblText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.m_lblText.Location = new System.Drawing.Point(0, 0);
            this.m_lblText.Name = "m_lblText";
            this.m_lblText.Size = new System.Drawing.Size(1595, 882);
            this.m_lblText.TabIndex = 0;
            this.m_lblText.Text = "authentic";
            this.m_lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picAudio
            // 
            this.picAudio.BackColor = System.Drawing.Color.Transparent;
            this.picAudio.BackgroundImage = global::Quizlet.Properties.Resources.audio_on;
            this.picAudio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picAudio.InitialImage = null;
            this.picAudio.Location = new System.Drawing.Point(13, 0);
            this.picAudio.Name = "picAudio";
            this.picAudio.Size = new System.Drawing.Size(149, 150);
            this.picAudio.TabIndex = 1;
            this.picAudio.TabStop = false;
            // 
            // m_lblHint
            // 
            this.m_lblHint.AutoSize = true;
            this.m_lblHint.BackColor = System.Drawing.Color.Transparent;
            this.m_lblHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_lblHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.m_lblHint.Location = new System.Drawing.Point(703, 227);
            this.m_lblHint.Name = "m_lblHint";
            this.m_lblHint.Size = new System.Drawing.Size(196, 55);
            this.m_lblHint.TabIndex = 2;
            this.m_lblHint.Text = "genuine";
            this.m_lblHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Quizlet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Quizlet.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1595, 882);
            this.Controls.Add(this.m_lblHint);
            this.Controls.Add(this.picAudio);
            this.Controls.Add(this.m_lblText);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Quizlet";
            this.Text = "Quizlet";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Quizlet_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Quizlet_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picAudio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_lblText;
        private System.Windows.Forms.PictureBox picAudio;
        private System.Windows.Forms.Label m_lblHint;
    }
}


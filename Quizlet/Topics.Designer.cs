namespace Quizlet
{
    partial class Topics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Topics));
            this.m_lstTopics = new System.Windows.Forms.CheckedListBox();
            this.m_checkAll = new System.Windows.Forms.CheckBox();
            this.m_btnStart = new System.Windows.Forms.Button();
            this.m_AudioDeviceCmb = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // m_lstTopics
            // 
            this.m_lstTopics.BackColor = System.Drawing.Color.SteelBlue;
            this.m_lstTopics.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_lstTopics.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_lstTopics.ForeColor = System.Drawing.Color.White;
            this.m_lstTopics.FormattingEnabled = true;
            this.m_lstTopics.Location = new System.Drawing.Point(12, 61);
            this.m_lstTopics.Margin = new System.Windows.Forms.Padding(0);
            this.m_lstTopics.Name = "m_lstTopics";
            this.m_lstTopics.Size = new System.Drawing.Size(673, 495);
            this.m_lstTopics.TabIndex = 0;
            this.m_lstTopics.SelectedIndexChanged += new System.EventHandler(this.m_lstTopics_SelectedIndexChanged);
            // 
            // m_checkAll
            // 
            this.m_checkAll.AutoSize = true;
            this.m_checkAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_checkAll.ForeColor = System.Drawing.Color.White;
            this.m_checkAll.Location = new System.Drawing.Point(12, 12);
            this.m_checkAll.Name = "m_checkAll";
            this.m_checkAll.Size = new System.Drawing.Size(202, 35);
            this.m_checkAll.TabIndex = 1;
            this.m_checkAll.Text = "Выбрать все";
            this.m_checkAll.UseVisualStyleBackColor = true;
            this.m_checkAll.CheckedChanged += new System.EventHandler(this.m_checkAll_CheckedChanged);
            // 
            // m_btnStart
            // 
            this.m_btnStart.BackColor = System.Drawing.Color.SteelBlue;
            this.m_btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_btnStart.ForeColor = System.Drawing.Color.AliceBlue;
            this.m_btnStart.Location = new System.Drawing.Point(564, 14);
            this.m_btnStart.Name = "m_btnStart";
            this.m_btnStart.Size = new System.Drawing.Size(121, 34);
            this.m_btnStart.TabIndex = 2;
            this.m_btnStart.Text = "Запуск";
            this.m_btnStart.UseVisualStyleBackColor = false;
            this.m_btnStart.Click += new System.EventHandler(this.m_btnStart_Click);
            // 
            // m_AudioDeviceCmb
            // 
            this.m_AudioDeviceCmb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_AudioDeviceCmb.FormattingEnabled = true;
            this.m_AudioDeviceCmb.Location = new System.Drawing.Point(331, 14);
            this.m_AudioDeviceCmb.Name = "m_AudioDeviceCmb";
            this.m_AudioDeviceCmb.Size = new System.Drawing.Size(227, 28);
            this.m_AudioDeviceCmb.TabIndex = 3;
            this.m_AudioDeviceCmb.SelectedIndexChanged += new System.EventHandler(this.m_AudioDeviceCmb_SelectedIndexChanged);
            // 
            // Topics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(697, 572);
            this.Controls.Add(this.m_AudioDeviceCmb);
            this.Controls.Add(this.m_btnStart);
            this.Controls.Add(this.m_checkAll);
            this.Controls.Add(this.m_lstTopics);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Topics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Темы";
            this.Load += new System.EventHandler(this.Topics_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Topics_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox m_lstTopics;
        private System.Windows.Forms.CheckBox m_checkAll;
        private System.Windows.Forms.Button m_btnStart;
        private System.Windows.Forms.ComboBox m_AudioDeviceCmb;
    }
}
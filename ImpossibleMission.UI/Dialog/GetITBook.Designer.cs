namespace ImpossibleMission
{
    partial class GetITBook
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
            this.btnStart = new System.Windows.Forms.Button();
            this.txtStartIndex = new System.Windows.Forms.TextBox();
            this.btnDownloadMissed = new System.Windows.Forms.Button();
            this.chkIncludeNotFound = new System.Windows.Forms.CheckBox();
            this.btnGetRealUrl = new System.Windows.Forms.Button();
            this.txtStartNum = new System.Windows.Forms.TextBox();
            this.txtEndNum = new System.Windows.Forms.TextBox();
            this.btnUpdateDownloaded = new System.Windows.Forms.Button();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.btnUpdateLocalFiles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(13, 13);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "StartFrom";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtStartIndex
            // 
            this.txtStartIndex.Location = new System.Drawing.Point(111, 14);
            this.txtStartIndex.Name = "txtStartIndex";
            this.txtStartIndex.Size = new System.Drawing.Size(100, 21);
            this.txtStartIndex.TabIndex = 1;
            this.txtStartIndex.Text = "1";
            this.txtStartIndex.TextChanged += new System.EventHandler(this.Number_TextChanged);
            // 
            // btnDownloadMissed
            // 
            this.btnDownloadMissed.Location = new System.Drawing.Point(13, 59);
            this.btnDownloadMissed.Name = "btnDownloadMissed";
            this.btnDownloadMissed.Size = new System.Drawing.Size(118, 23);
            this.btnDownloadMissed.TabIndex = 2;
            this.btnDownloadMissed.Text = "DownloadMissed";
            this.btnDownloadMissed.UseVisualStyleBackColor = true;
            this.btnDownloadMissed.Click += new System.EventHandler(this.btnDownloadMissed_Click);
            // 
            // chkIncludeNotFound
            // 
            this.chkIncludeNotFound.AutoSize = true;
            this.chkIncludeNotFound.Location = new System.Drawing.Point(159, 65);
            this.chkIncludeNotFound.Name = "chkIncludeNotFound";
            this.chkIncludeNotFound.Size = new System.Drawing.Size(126, 16);
            this.chkIncludeNotFound.TabIndex = 3;
            this.chkIncludeNotFound.Text = "Include NOT Found";
            this.chkIncludeNotFound.UseVisualStyleBackColor = true;
            this.chkIncludeNotFound.CheckedChanged += new System.EventHandler(this.chkIncludeNotFound_CheckedChanged);
            // 
            // btnGetRealUrl
            // 
            this.btnGetRealUrl.Location = new System.Drawing.Point(13, 104);
            this.btnGetRealUrl.Name = "btnGetRealUrl";
            this.btnGetRealUrl.Size = new System.Drawing.Size(134, 23);
            this.btnGetRealUrl.TabIndex = 4;
            this.btnGetRealUrl.Text = "GetRealDownloadUrl";
            this.btnGetRealUrl.UseVisualStyleBackColor = true;
            this.btnGetRealUrl.Click += new System.EventHandler(this.btnGetRealUrl_Click);
            // 
            // txtStartNum
            // 
            this.txtStartNum.Location = new System.Drawing.Point(173, 105);
            this.txtStartNum.Name = "txtStartNum";
            this.txtStartNum.Size = new System.Drawing.Size(100, 21);
            this.txtStartNum.TabIndex = 5;
            this.txtStartNum.TextChanged += new System.EventHandler(this.Number_TextChanged);
            // 
            // txtEndNum
            // 
            this.txtEndNum.Location = new System.Drawing.Point(302, 104);
            this.txtEndNum.Name = "txtEndNum";
            this.txtEndNum.Size = new System.Drawing.Size(100, 21);
            this.txtEndNum.TabIndex = 6;
            this.txtEndNum.TextChanged += new System.EventHandler(this.Number_TextChanged);
            // 
            // btnUpdateDownloaded
            // 
            this.btnUpdateDownloaded.Location = new System.Drawing.Point(13, 149);
            this.btnUpdateDownloaded.Name = "btnUpdateDownloaded";
            this.btnUpdateDownloaded.Size = new System.Drawing.Size(134, 23);
            this.btnUpdateDownloaded.TabIndex = 7;
            this.btnUpdateDownloaded.Text = "UpdateDownloaded";
            this.btnUpdateDownloaded.UseVisualStyleBackColor = true;
            this.btnUpdateDownloaded.Click += new System.EventHandler(this.btnUpdateDownloaded_Click);
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(173, 150);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(229, 21);
            this.txtFolder.TabIndex = 8;
            this.txtFolder.Text = "E:\\ITBooks\\1-1000";
            this.txtFolder.TextChanged += new System.EventHandler(this.txtFolder_TextChanged);
            this.txtFolder.DoubleClick += new System.EventHandler(this.txtFolder_DoubleClick);
            // 
            // btnUpdateLocalFiles
            // 
            this.btnUpdateLocalFiles.Location = new System.Drawing.Point(13, 189);
            this.btnUpdateLocalFiles.Name = "btnUpdateLocalFiles";
            this.btnUpdateLocalFiles.Size = new System.Drawing.Size(149, 23);
            this.btnUpdateLocalFiles.TabIndex = 9;
            this.btnUpdateLocalFiles.Text = "Update Local Files";
            this.btnUpdateLocalFiles.UseVisualStyleBackColor = true;
            this.btnUpdateLocalFiles.Click += new System.EventHandler(this.btnUpdateLocalFiles_Click);
            // 
            // GetITBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 265);
            this.Controls.Add(this.btnUpdateLocalFiles);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.btnUpdateDownloaded);
            this.Controls.Add(this.txtEndNum);
            this.Controls.Add(this.txtStartNum);
            this.Controls.Add(this.btnGetRealUrl);
            this.Controls.Add(this.chkIncludeNotFound);
            this.Controls.Add(this.btnDownloadMissed);
            this.Controls.Add(this.txtStartIndex);
            this.Controls.Add(this.btnStart);
            this.Name = "GetITBook";
            this.Text = "GetITBook";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GetITBook_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtStartIndex;
        private System.Windows.Forms.Button btnDownloadMissed;
        private System.Windows.Forms.CheckBox chkIncludeNotFound;
        private System.Windows.Forms.Button btnGetRealUrl;
        private System.Windows.Forms.TextBox txtStartNum;
        private System.Windows.Forms.TextBox txtEndNum;
        private System.Windows.Forms.Button btnUpdateDownloaded;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private System.Windows.Forms.Button btnUpdateLocalFiles;
    }
}
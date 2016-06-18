namespace ImpossibleMission.Widget.File.Ebbinghaus
{
    partial class AddEbbinghous
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tplMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTemplate = new System.Windows.Forms.Panel();
            this.pnlRow1 = new System.Windows.Forms.Panel();
            this.rtxDescription = new System.Windows.Forms.RichTextBox();
            this.fplRow1 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkDefaultEbbinghous = new System.Windows.Forms.CheckBox();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.dtPicker = new System.Windows.Forms.DateTimePicker();
            this.btnCreateTemplate = new System.Windows.Forms.Button();
            this.gbxDetails = new System.Windows.Forms.GroupBox();
            this.rtxDetails = new System.Windows.Forms.RichTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.ucNameFormatter = new ImpossibleMission.Widget.File.CommonNameFormatter();
            this.tplMain.SuspendLayout();
            this.pnlTemplate.SuspendLayout();
            this.pnlRow1.SuspendLayout();
            this.fplRow1.SuspendLayout();
            this.gbxDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // tplMain
            // 
            this.tplMain.AutoScroll = true;
            this.tplMain.AutoSize = true;
            this.tplMain.ColumnCount = 1;
            this.tplMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplMain.Controls.Add(this.pnlTemplate, 0, 0);
            this.tplMain.Controls.Add(this.gbxDetails, 0, 2);
            this.tplMain.Controls.Add(this.btnSave, 0, 3);
            this.tplMain.Controls.Add(this.ucNameFormatter, 0, 1);
            this.tplMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tplMain.Location = new System.Drawing.Point(0, 0);
            this.tplMain.Margin = new System.Windows.Forms.Padding(10);
            this.tplMain.Name = "tplMain";
            this.tplMain.RowCount = 4;
            this.tplMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tplMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tplMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tplMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tplMain.Size = new System.Drawing.Size(810, 412);
            this.tplMain.TabIndex = 0;
            // 
            // pnlTemplate
            // 
            this.pnlTemplate.Controls.Add(this.pnlRow1);
            this.pnlTemplate.Controls.Add(this.fplRow1);
            this.pnlTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTemplate.Location = new System.Drawing.Point(3, 3);
            this.pnlTemplate.Name = "pnlTemplate";
            this.pnlTemplate.Size = new System.Drawing.Size(804, 114);
            this.pnlTemplate.TabIndex = 0;
            // 
            // pnlRow1
            // 
            this.pnlRow1.Controls.Add(this.rtxDescription);
            this.pnlRow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRow1.Location = new System.Drawing.Point(0, 36);
            this.pnlRow1.Name = "pnlRow1";
            this.pnlRow1.Size = new System.Drawing.Size(804, 78);
            this.pnlRow1.TabIndex = 5;
            // 
            // rtxDescription
            // 
            this.rtxDescription.BackColor = System.Drawing.SystemColors.Control;
            this.rtxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxDescription.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.rtxDescription.Location = new System.Drawing.Point(0, 0);
            this.rtxDescription.Name = "rtxDescription";
            this.rtxDescription.ReadOnly = true;
            this.rtxDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtxDescription.Size = new System.Drawing.Size(804, 78);
            this.rtxDescription.TabIndex = 0;
            this.rtxDescription.Text = "";
            // 
            // fplRow1
            // 
            this.fplRow1.Controls.Add(this.chkDefaultEbbinghous);
            this.fplRow1.Controls.Add(this.lblStartTime);
            this.fplRow1.Controls.Add(this.dtPicker);
            this.fplRow1.Controls.Add(this.btnCreateTemplate);
            this.fplRow1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fplRow1.Location = new System.Drawing.Point(0, 0);
            this.fplRow1.Name = "fplRow1";
            this.fplRow1.Size = new System.Drawing.Size(804, 36);
            this.fplRow1.TabIndex = 4;
            // 
            // chkDefaultEbbinghous
            // 
            this.chkDefaultEbbinghous.AutoSize = true;
            this.chkDefaultEbbinghous.Checked = true;
            this.chkDefaultEbbinghous.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDefaultEbbinghous.Location = new System.Drawing.Point(10, 10);
            this.chkDefaultEbbinghous.Margin = new System.Windows.Forms.Padding(10, 10, 20, 3);
            this.chkDefaultEbbinghous.Name = "chkDefaultEbbinghous";
            this.chkDefaultEbbinghous.Size = new System.Drawing.Size(72, 16);
            this.chkDefaultEbbinghous.TabIndex = 1;
            this.chkDefaultEbbinghous.Text = "默认模板";
            this.chkDefaultEbbinghous.UseVisualStyleBackColor = true;
            // 
            // lblStartTime
            // 
            this.lblStartTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(112, 12);
            this.lblStartTime.Margin = new System.Windows.Forms.Padding(10, 3, 3, 0);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(71, 12);
            this.lblStartTime.TabIndex = 0;
            this.lblStartTime.Text = " 开始日期：";
            // 
            // dtPicker
            // 
            this.dtPicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtPicker.Location = new System.Drawing.Point(189, 8);
            this.dtPicker.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.dtPicker.Name = "dtPicker";
            this.dtPicker.Size = new System.Drawing.Size(100, 21);
            this.dtPicker.TabIndex = 1;
            // 
            // btnCreateTemplate
            // 
            this.btnCreateTemplate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCreateTemplate.Location = new System.Drawing.Point(312, 7);
            this.btnCreateTemplate.Margin = new System.Windows.Forms.Padding(20, 7, 3, 3);
            this.btnCreateTemplate.Name = "btnCreateTemplate";
            this.btnCreateTemplate.Size = new System.Drawing.Size(75, 23);
            this.btnCreateTemplate.TabIndex = 2;
            this.btnCreateTemplate.Text = "自定义模板";
            this.btnCreateTemplate.UseVisualStyleBackColor = true;
            // 
            // gbxDetails
            // 
            this.gbxDetails.Controls.Add(this.rtxDetails);
            this.gbxDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxDetails.Location = new System.Drawing.Point(3, 275);
            this.gbxDetails.Name = "gbxDetails";
            this.gbxDetails.Size = new System.Drawing.Size(804, 94);
            this.gbxDetails.TabIndex = 4;
            this.gbxDetails.TabStop = false;
            this.gbxDetails.Text = " 描述";
            // 
            // rtxDetails
            // 
            this.rtxDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxDetails.Location = new System.Drawing.Point(3, 17);
            this.rtxDetails.Name = "rtxDetails";
            this.rtxDetails.Size = new System.Drawing.Size(798, 74);
            this.rtxDetails.TabIndex = 0;
            this.rtxDetails.Text = "";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(10, 378);
            this.btnSave.Margin = new System.Windows.Forms.Padding(10, 6, 3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ucNameFormatter
            // 
            this.ucNameFormatter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucNameFormatter.Location = new System.Drawing.Point(3, 123);
            this.ucNameFormatter.Name = "ucNameFormatter";
            this.ucNameFormatter.Size = new System.Drawing.Size(804, 146);
            this.ucNameFormatter.TabIndex = 6;
            // 
            // AddEbbinghous
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.tplMain);
            this.Name = "AddEbbinghous";
            this.Size = new System.Drawing.Size(810, 412);
            this.tplMain.ResumeLayout(false);
            this.pnlTemplate.ResumeLayout(false);
            this.pnlRow1.ResumeLayout(false);
            this.fplRow1.ResumeLayout(false);
            this.fplRow1.PerformLayout();
            this.gbxDetails.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tplMain;
        private System.Windows.Forms.Panel pnlTemplate;
        private System.Windows.Forms.CheckBox chkDefaultEbbinghous;
        private System.Windows.Forms.Button btnCreateTemplate;
        private System.Windows.Forms.FlowLayoutPanel fplRow1;
        private System.Windows.Forms.Panel pnlRow1;
        private System.Windows.Forms.RichTextBox rtxDescription;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.DateTimePicker dtPicker;
        private System.Windows.Forms.GroupBox gbxDetails;
        private System.Windows.Forms.RichTextBox rtxDetails;
        private System.Windows.Forms.Button btnSave;
        private CommonNameFormatter ucNameFormatter;
    }
}

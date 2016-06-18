namespace ImpossibleMission.Widget.File
{
    partial class CommonNameFormatter
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.gbxPreview = new System.Windows.Forms.GroupBox();
            this.rtxPreview = new System.Windows.Forms.RichTextBox();
            this.fplStartTime = new System.Windows.Forms.FlowLayoutPanel();
            this.lblItemCount = new System.Windows.Forms.Label();
            this.txtItemCount = new System.Windows.Forms.TextBox();
            this.lblStartNumber = new System.Windows.Forms.Label();
            this.txtStartNumber = new System.Windows.Forms.TextBox();
            this.lblIncrement = new System.Windows.Forms.Label();
            this.txtIncrement = new System.Windows.Forms.TextBox();
            this.lblGenerateTemplate = new System.Windows.Forms.Label();
            this.txtGenerateTemplate = new System.Windows.Forms.TextBox();
            this.btnAdvanceGenerate = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.gbxPreview.SuspendLayout();
            this.fplStartTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.gbxPreview, 0, 1);
            this.tlpMain.Controls.Add(this.fplStartTime, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpMain.Size = new System.Drawing.Size(800, 200);
            this.tlpMain.TabIndex = 0;
            // 
            // gbxPreview
            // 
            this.gbxPreview.Controls.Add(this.rtxPreview);
            this.gbxPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxPreview.Location = new System.Drawing.Point(3, 53);
            this.gbxPreview.Name = "gbxPreview";
            this.gbxPreview.Size = new System.Drawing.Size(794, 144);
            this.gbxPreview.TabIndex = 4;
            this.gbxPreview.TabStop = false;
            this.gbxPreview.Text = "预览";
            // 
            // rtxPreview
            // 
            this.rtxPreview.BackColor = System.Drawing.SystemColors.Control;
            this.rtxPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxPreview.Location = new System.Drawing.Point(3, 17);
            this.rtxPreview.Name = "rtxPreview";
            this.rtxPreview.ReadOnly = true;
            this.rtxPreview.Size = new System.Drawing.Size(788, 124);
            this.rtxPreview.TabIndex = 0;
            this.rtxPreview.Text = "";
            // 
            // fplStartTime
            // 
            this.fplStartTime.Controls.Add(this.lblItemCount);
            this.fplStartTime.Controls.Add(this.txtItemCount);
            this.fplStartTime.Controls.Add(this.lblStartNumber);
            this.fplStartTime.Controls.Add(this.txtStartNumber);
            this.fplStartTime.Controls.Add(this.lblIncrement);
            this.fplStartTime.Controls.Add(this.txtIncrement);
            this.fplStartTime.Controls.Add(this.lblGenerateTemplate);
            this.fplStartTime.Controls.Add(this.txtGenerateTemplate);
            this.fplStartTime.Controls.Add(this.btnAdvanceGenerate);
            this.fplStartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fplStartTime.Location = new System.Drawing.Point(3, 3);
            this.fplStartTime.Name = "fplStartTime";
            this.fplStartTime.Size = new System.Drawing.Size(794, 44);
            this.fplStartTime.TabIndex = 2;
            // 
            // lblItemCount
            // 
            this.lblItemCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblItemCount.AutoSize = true;
            this.lblItemCount.Location = new System.Drawing.Point(10, 15);
            this.lblItemCount.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.lblItemCount.Name = "lblItemCount";
            this.lblItemCount.Size = new System.Drawing.Size(89, 12);
            this.lblItemCount.TabIndex = 0;
            this.lblItemCount.Text = "完成条项个数：";
            // 
            // txtItemCount
            // 
            this.txtItemCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtItemCount.Location = new System.Drawing.Point(105, 7);
            this.txtItemCount.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.txtItemCount.Name = "txtItemCount";
            this.txtItemCount.Size = new System.Drawing.Size(50, 21);
            this.txtItemCount.TabIndex = 1;
            this.txtItemCount.WordWrap = false;
            this.txtItemCount.TextChanged += new System.EventHandler(this.Number_TextChanged);
            // 
            // lblStartNumber
            // 
            this.lblStartNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStartNumber.AutoSize = true;
            this.lblStartNumber.Location = new System.Drawing.Point(168, 15);
            this.lblStartNumber.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.lblStartNumber.Name = "lblStartNumber";
            this.lblStartNumber.Size = new System.Drawing.Size(65, 12);
            this.lblStartNumber.TabIndex = 2;
            this.lblStartNumber.Text = "开始计数：";
            // 
            // txtStartNumber
            // 
            this.txtStartNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtStartNumber.Location = new System.Drawing.Point(246, 7);
            this.txtStartNumber.Margin = new System.Windows.Forms.Padding(10, 7, 3, 3);
            this.txtStartNumber.MaxLength = 5;
            this.txtStartNumber.Name = "txtStartNumber";
            this.txtStartNumber.Size = new System.Drawing.Size(50, 21);
            this.txtStartNumber.TabIndex = 3;
            this.txtStartNumber.Text = "1";
            this.txtStartNumber.TextChanged += new System.EventHandler(this.Number_TextChanged);
            // 
            // lblIncrement
            // 
            this.lblIncrement.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblIncrement.AutoSize = true;
            this.lblIncrement.Location = new System.Drawing.Point(309, 15);
            this.lblIncrement.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.lblIncrement.Name = "lblIncrement";
            this.lblIncrement.Size = new System.Drawing.Size(41, 12);
            this.lblIncrement.TabIndex = 4;
            this.lblIncrement.Text = "增量：";
            // 
            // txtIncrement
            // 
            this.txtIncrement.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtIncrement.Location = new System.Drawing.Point(363, 7);
            this.txtIncrement.Margin = new System.Windows.Forms.Padding(10, 7, 3, 3);
            this.txtIncrement.MaxLength = 5;
            this.txtIncrement.Name = "txtIncrement";
            this.txtIncrement.Size = new System.Drawing.Size(50, 21);
            this.txtIncrement.TabIndex = 5;
            this.txtIncrement.Text = "1";
            this.txtIncrement.TextChanged += new System.EventHandler(this.Number_TextChanged);
            // 
            // lblGenerateTemplate
            // 
            this.lblGenerateTemplate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblGenerateTemplate.AutoSize = true;
            this.lblGenerateTemplate.Location = new System.Drawing.Point(426, 15);
            this.lblGenerateTemplate.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.lblGenerateTemplate.Name = "lblGenerateTemplate";
            this.lblGenerateTemplate.Size = new System.Drawing.Size(89, 12);
            this.lblGenerateTemplate.TabIndex = 0;
            this.lblGenerateTemplate.Text = "生成条项模板：";
            // 
            // txtGenerateTemplate
            // 
            this.txtGenerateTemplate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtGenerateTemplate.Location = new System.Drawing.Point(521, 7);
            this.txtGenerateTemplate.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.txtGenerateTemplate.Name = "txtGenerateTemplate";
            this.txtGenerateTemplate.Size = new System.Drawing.Size(80, 21);
            this.txtGenerateTemplate.TabIndex = 1;
            this.txtGenerateTemplate.Text = "XX{0}YY";
            this.txtGenerateTemplate.TextChanged += new System.EventHandler(this.TxtChanged);
            // 
            // btnAdvanceGenerate
            // 
            this.btnAdvanceGenerate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAdvanceGenerate.Location = new System.Drawing.Point(614, 6);
            this.btnAdvanceGenerate.Margin = new System.Windows.Forms.Padding(10, 6, 3, 3);
            this.btnAdvanceGenerate.Name = "btnAdvanceGenerate";
            this.btnAdvanceGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnAdvanceGenerate.TabIndex = 2;
            this.btnAdvanceGenerate.Text = "高级";
            this.btnAdvanceGenerate.UseVisualStyleBackColor = true;
            // 
            // CommonNameFormatter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Name = "CommonNameFormatter";
            this.Size = new System.Drawing.Size(800, 200);
            this.tlpMain.ResumeLayout(false);
            this.gbxPreview.ResumeLayout(false);
            this.fplStartTime.ResumeLayout(false);
            this.fplStartTime.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.FlowLayoutPanel fplStartTime;
        private System.Windows.Forms.Label lblItemCount;
        private System.Windows.Forms.TextBox txtItemCount;
        private System.Windows.Forms.Label lblStartNumber;
        private System.Windows.Forms.TextBox txtStartNumber;
        private System.Windows.Forms.Label lblGenerateTemplate;
        private System.Windows.Forms.TextBox txtGenerateTemplate;
        private System.Windows.Forms.Button btnAdvanceGenerate;
        private System.Windows.Forms.GroupBox gbxPreview;
        private System.Windows.Forms.RichTextBox rtxPreview;
        private System.Windows.Forms.Label lblIncrement;
        private System.Windows.Forms.TextBox txtIncrement;
    }
}

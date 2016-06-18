namespace ImpossibleMission.Widget.File
{
    partial class UCCompleteOperator
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
            this.flpHeader = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.gbxReview = new System.Windows.Forms.GroupBox();
            this.rtxReview = new System.Windows.Forms.RichTextBox();
            this.tplMain.SuspendLayout();
            this.flpHeader.SuspendLayout();
            this.gbxReview.SuspendLayout();
            this.SuspendLayout();
            // 
            // tplMain
            // 
            this.tplMain.ColumnCount = 1;
            this.tplMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplMain.Controls.Add(this.flpHeader, 0, 0);
            this.tplMain.Controls.Add(this.gbxReview, 0, 1);
            this.tplMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tplMain.Location = new System.Drawing.Point(0, 0);
            this.tplMain.Name = "tplMain";
            this.tplMain.RowCount = 2;
            this.tplMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tplMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplMain.Size = new System.Drawing.Size(997, 320);
            this.tplMain.TabIndex = 0;
            // 
            // flpHeader
            // 
            this.flpHeader.Controls.Add(this.btnSave);
            this.flpHeader.Controls.Add(this.lblMsg);
            this.flpHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpHeader.Location = new System.Drawing.Point(3, 3);
            this.flpHeader.Name = "flpHeader";
            this.flpHeader.Size = new System.Drawing.Size(991, 29);
            this.flpHeader.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMsg.ForeColor = System.Drawing.Color.Blue;
            this.lblMsg.Location = new System.Drawing.Point(84, 7);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(97, 15);
            this.lblMsg.TabIndex = 1;
            this.lblMsg.Text = "Completed!";
            // 
            // gbxReview
            // 
            this.gbxReview.Controls.Add(this.rtxReview);
            this.gbxReview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxReview.Location = new System.Drawing.Point(3, 38);
            this.gbxReview.Name = "gbxReview";
            this.gbxReview.Size = new System.Drawing.Size(991, 279);
            this.gbxReview.TabIndex = 1;
            this.gbxReview.TabStop = false;
            this.gbxReview.Text = "Review";
            // 
            // rtxReview
            // 
            this.rtxReview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxReview.Location = new System.Drawing.Point(3, 17);
            this.rtxReview.Name = "rtxReview";
            this.rtxReview.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtxReview.Size = new System.Drawing.Size(985, 259);
            this.rtxReview.TabIndex = 0;
            this.rtxReview.Text = "";
            this.rtxReview.TextChanged += new System.EventHandler(this.rtxReview_TextChanged);
            // 
            // UCCompleteOperator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tplMain);
            this.Name = "UCCompleteOperator";
            this.Size = new System.Drawing.Size(997, 320);
            this.tplMain.ResumeLayout(false);
            this.flpHeader.ResumeLayout(false);
            this.flpHeader.PerformLayout();
            this.gbxReview.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tplMain;
        private System.Windows.Forms.FlowLayoutPanel flpHeader;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.GroupBox gbxReview;
        private System.Windows.Forms.RichTextBox rtxReview;
    }
}

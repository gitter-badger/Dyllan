namespace ImpossibleMission.Widget.File
{
    partial class AddSchedulePlan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSchedulePlan));
            this.tplMain = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblStartIndex = new System.Windows.Forms.Label();
            this.txtStartIndex = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEndIndex = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.fplRow1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtPicker = new System.Windows.Forms.DateTimePicker();
            this.lblSeperate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblWeekDayWorkload = new System.Windows.Forms.Label();
            this.txtWorkdayWorkload = new System.Windows.Forms.TextBox();
            this.lblWeekendWorkload = new System.Windows.Forms.Label();
            this.txtWeekendWorkload = new System.Windows.Forms.TextBox();
            this.lblBuffer = new System.Windows.Forms.Label();
            this.txtBuffer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbxDetails = new System.Windows.Forms.GroupBox();
            this.rtxDetails = new System.Windows.Forms.RichTextBox();
            this.tplMain.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.fplRow1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.gbxDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // tplMain
            // 
            resources.ApplyResources(this.tplMain, "tplMain");
            this.tplMain.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tplMain.Controls.Add(this.fplRow1, 0, 0);
            this.tplMain.Controls.Add(this.flowLayoutPanel2, 0, 2);
            this.tplMain.Controls.Add(this.btnSave, 0, 4);
            this.tplMain.Controls.Add(this.gbxDetails, 0, 3);
            this.tplMain.Name = "tplMain";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblStartIndex);
            this.flowLayoutPanel1.Controls.Add(this.txtStartIndex);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.txtEndIndex);
            this.flowLayoutPanel1.Controls.Add(this.lblAmount);
            this.flowLayoutPanel1.Controls.Add(this.txtAmount);
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // lblStartIndex
            // 
            resources.ApplyResources(this.lblStartIndex, "lblStartIndex");
            this.lblStartIndex.Name = "lblStartIndex";
            // 
            // txtStartIndex
            // 
            resources.ApplyResources(this.txtStartIndex, "txtStartIndex");
            this.txtStartIndex.Name = "txtStartIndex";
            this.txtStartIndex.TextChanged += new System.EventHandler(this.Number_TextChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtEndIndex
            // 
            resources.ApplyResources(this.txtEndIndex, "txtEndIndex");
            this.txtEndIndex.Name = "txtEndIndex";
            this.txtEndIndex.TextChanged += new System.EventHandler(this.TxtChanged);
            // 
            // lblAmount
            // 
            resources.ApplyResources(this.lblAmount, "lblAmount");
            this.lblAmount.Name = "lblAmount";
            // 
            // txtAmount
            // 
            resources.ApplyResources(this.txtAmount, "txtAmount");
            this.txtAmount.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtAmount.Name = "txtAmount";
            // 
            // fplRow1
            // 
            this.fplRow1.Controls.Add(this.lblStartDate);
            this.fplRow1.Controls.Add(this.dtPicker);
            this.fplRow1.Controls.Add(this.lblSeperate);
            this.fplRow1.Controls.Add(this.lblEndDate);
            this.fplRow1.Controls.Add(this.txtEndDate);
            resources.ApplyResources(this.fplRow1, "fplRow1");
            this.fplRow1.Name = "fplRow1";
            // 
            // lblStartDate
            // 
            resources.ApplyResources(this.lblStartDate, "lblStartDate");
            this.lblStartDate.Name = "lblStartDate";
            // 
            // dtPicker
            // 
            resources.ApplyResources(this.dtPicker, "dtPicker");
            this.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPicker.Name = "dtPicker";
            // 
            // lblSeperate
            // 
            resources.ApplyResources(this.lblSeperate, "lblSeperate");
            this.lblSeperate.Name = "lblSeperate";
            // 
            // lblEndDate
            // 
            resources.ApplyResources(this.lblEndDate, "lblEndDate");
            this.lblEndDate.Name = "lblEndDate";
            // 
            // txtEndDate
            // 
            resources.ApplyResources(this.txtEndDate, "txtEndDate");
            this.txtEndDate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtEndDate.Name = "txtEndDate";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.lblWeekDayWorkload);
            this.flowLayoutPanel2.Controls.Add(this.txtWorkdayWorkload);
            this.flowLayoutPanel2.Controls.Add(this.lblWeekendWorkload);
            this.flowLayoutPanel2.Controls.Add(this.txtWeekendWorkload);
            this.flowLayoutPanel2.Controls.Add(this.lblBuffer);
            this.flowLayoutPanel2.Controls.Add(this.txtBuffer);
            this.flowLayoutPanel2.Controls.Add(this.label1);
            resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // lblWeekDayWorkload
            // 
            resources.ApplyResources(this.lblWeekDayWorkload, "lblWeekDayWorkload");
            this.lblWeekDayWorkload.Name = "lblWeekDayWorkload";
            // 
            // txtWorkdayWorkload
            // 
            resources.ApplyResources(this.txtWorkdayWorkload, "txtWorkdayWorkload");
            this.txtWorkdayWorkload.Name = "txtWorkdayWorkload";
            this.txtWorkdayWorkload.TextChanged += new System.EventHandler(this.Number_TextChanged);
            // 
            // lblWeekendWorkload
            // 
            resources.ApplyResources(this.lblWeekendWorkload, "lblWeekendWorkload");
            this.lblWeekendWorkload.Name = "lblWeekendWorkload";
            // 
            // txtWeekendWorkload
            // 
            resources.ApplyResources(this.txtWeekendWorkload, "txtWeekendWorkload");
            this.txtWeekendWorkload.Name = "txtWeekendWorkload";
            this.txtWeekendWorkload.TextChanged += new System.EventHandler(this.Number_TextChanged);
            // 
            // lblBuffer
            // 
            resources.ApplyResources(this.lblBuffer, "lblBuffer");
            this.lblBuffer.Name = "lblBuffer";
            // 
            // txtBuffer
            // 
            resources.ApplyResources(this.txtBuffer, "txtBuffer");
            this.txtBuffer.Name = "txtBuffer";
            this.txtBuffer.TextChanged += new System.EventHandler(this.Float_TextChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbxDetails
            // 
            this.gbxDetails.Controls.Add(this.rtxDetails);
            resources.ApplyResources(this.gbxDetails, "gbxDetails");
            this.gbxDetails.Name = "gbxDetails";
            this.gbxDetails.TabStop = false;
            // 
            // rtxDetails
            // 
            resources.ApplyResources(this.rtxDetails, "rtxDetails");
            this.rtxDetails.Name = "rtxDetails";
            // 
            // AddSchedulePlan
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tplMain);
            this.Name = "AddSchedulePlan";
            this.tplMain.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.fplRow1.ResumeLayout(false);
            this.fplRow1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.gbxDetails.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tplMain;
        private System.Windows.Forms.FlowLayoutPanel fplRow1;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtPicker;
        private System.Windows.Forms.Label lblSeperate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblStartIndex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStartIndex;
        private System.Windows.Forms.TextBox txtEndIndex;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lblWeekDayWorkload;
        private System.Windows.Forms.TextBox txtWorkdayWorkload;
        private System.Windows.Forms.Label lblWeekendWorkload;
        private System.Windows.Forms.TextBox txtWeekendWorkload;
        private System.Windows.Forms.Label lblBuffer;
        private System.Windows.Forms.TextBox txtBuffer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gbxDetails;
        private System.Windows.Forms.RichTextBox rtxDetails;
    }
}

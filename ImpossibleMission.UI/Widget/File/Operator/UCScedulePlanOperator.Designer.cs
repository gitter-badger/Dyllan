namespace ImpossibleMission.Widget.File
{
    partial class UCScedulePlanOperator
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
            DevExpress.XtraCharts.XYDiagram xyDiagram2 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series4 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView4 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.Series series5 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView5 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.Series series6 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView6 = new DevExpress.XtraCharts.LineSeriesView();
            this.tplMain = new System.Windows.Forms.TableLayoutPanel();
            this.chart = new DevExpress.XtraCharts.ChartControl();
            this.tplLeft = new System.Windows.Forms.TableLayoutPanel();
            this.gbxNote = new System.Windows.Forms.GroupBox();
            this.rtxNode = new System.Windows.Forms.RichTextBox();
            this.pnlLeftHeader = new System.Windows.Forms.Panel();
            this.txtTodayIndex = new System.Windows.Forms.TextBox();
            this.lblTodayIndex = new System.Windows.Forms.Label();
            this.txtCurrentIndex = new System.Windows.Forms.TextBox();
            this.lblCurrenIndex = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.ucTimer = new ImpossibleMission.Widget.Common.UCTimer();
            this.tplMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView6)).BeginInit();
            this.tplLeft.SuspendLayout();
            this.gbxNote.SuspendLayout();
            this.pnlLeftHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // tplMain
            // 
            this.tplMain.ColumnCount = 2;
            this.tplMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 460F));
            this.tplMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplMain.Controls.Add(this.chart, 1, 0);
            this.tplMain.Controls.Add(this.tplLeft, 0, 0);
            this.tplMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tplMain.Location = new System.Drawing.Point(0, 0);
            this.tplMain.Name = "tplMain";
            this.tplMain.RowCount = 1;
            this.tplMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplMain.Size = new System.Drawing.Size(997, 320);
            this.tplMain.TabIndex = 0;
            // 
            // chart
            // 
            xyDiagram2.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram2.AxisY.VisibleInPanesSerializable = "-1";
            this.chart.Diagram = xyDiagram2;
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart.Location = new System.Drawing.Point(463, 3);
            this.chart.Name = "chart";
            series4.Name = "Actual";
            lineSeriesView4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(73)))), ((int)(((byte)(125)))));
            series4.View = lineSeriesView4;
            series5.Name = "Expected";
            lineSeriesView5.Color = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series5.View = lineSeriesView5;
            series6.Name = "Plan";
            series6.View = lineSeriesView6;
            this.chart.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series4,
        series5,
        series6};
            this.chart.Size = new System.Drawing.Size(531, 314);
            this.chart.TabIndex = 15;
            // 
            // tplLeft
            // 
            this.tplLeft.ColumnCount = 1;
            this.tplLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplLeft.Controls.Add(this.gbxNote, 0, 1);
            this.tplLeft.Controls.Add(this.pnlLeftHeader, 0, 0);
            this.tplLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tplLeft.Location = new System.Drawing.Point(3, 3);
            this.tplLeft.Name = "tplLeft";
            this.tplLeft.RowCount = 2;
            this.tplLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tplLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplLeft.Size = new System.Drawing.Size(454, 314);
            this.tplLeft.TabIndex = 16;
            // 
            // gbxNote
            // 
            this.gbxNote.Controls.Add(this.rtxNode);
            this.gbxNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxNote.Location = new System.Drawing.Point(3, 92);
            this.gbxNote.Name = "gbxNote";
            this.gbxNote.Size = new System.Drawing.Size(448, 219);
            this.gbxNote.TabIndex = 29;
            this.gbxNote.TabStop = false;
            this.gbxNote.Text = "Note";
            // 
            // rtxNode
            // 
            this.rtxNode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxNode.Location = new System.Drawing.Point(3, 17);
            this.rtxNode.Name = "rtxNode";
            this.rtxNode.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtxNode.Size = new System.Drawing.Size(442, 199);
            this.rtxNode.TabIndex = 0;
            this.rtxNode.Text = "";
            this.rtxNode.TextChanged += new System.EventHandler(this.TxtChanged);
            // 
            // pnlLeftHeader
            // 
            this.pnlLeftHeader.Controls.Add(this.ucTimer);
            this.pnlLeftHeader.Controls.Add(this.txtTodayIndex);
            this.pnlLeftHeader.Controls.Add(this.lblTodayIndex);
            this.pnlLeftHeader.Controls.Add(this.txtCurrentIndex);
            this.pnlLeftHeader.Controls.Add(this.lblCurrenIndex);
            this.pnlLeftHeader.Controls.Add(this.lblMsg);
            this.pnlLeftHeader.Controls.Add(this.btnSave);
            this.pnlLeftHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeftHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlLeftHeader.Name = "pnlLeftHeader";
            this.pnlLeftHeader.Size = new System.Drawing.Size(448, 83);
            this.pnlLeftHeader.TabIndex = 0;
            // 
            // txtTodayIndex
            // 
            this.txtTodayIndex.Location = new System.Drawing.Point(81, 59);
            this.txtTodayIndex.Name = "txtTodayIndex";
            this.txtTodayIndex.Size = new System.Drawing.Size(100, 21);
            this.txtTodayIndex.TabIndex = 34;
            this.txtTodayIndex.TextChanged += new System.EventHandler(this.Number_TextChanged);
            // 
            // lblTodayIndex
            // 
            this.lblTodayIndex.AutoSize = true;
            this.lblTodayIndex.Location = new System.Drawing.Point(3, 62);
            this.lblTodayIndex.Name = "lblTodayIndex";
            this.lblTodayIndex.Size = new System.Drawing.Size(65, 12);
            this.lblTodayIndex.TabIndex = 33;
            this.lblTodayIndex.Text = "今日进度：";
            // 
            // txtCurrentIndex
            // 
            this.txtCurrentIndex.Enabled = false;
            this.txtCurrentIndex.Location = new System.Drawing.Point(81, 23);
            this.txtCurrentIndex.Name = "txtCurrentIndex";
            this.txtCurrentIndex.Size = new System.Drawing.Size(100, 21);
            this.txtCurrentIndex.TabIndex = 32;
            // 
            // lblCurrenIndex
            // 
            this.lblCurrenIndex.AutoSize = true;
            this.lblCurrenIndex.Location = new System.Drawing.Point(3, 26);
            this.lblCurrenIndex.Name = "lblCurrenIndex";
            this.lblCurrenIndex.Size = new System.Drawing.Size(65, 12);
            this.lblCurrenIndex.TabIndex = 31;
            this.lblCurrenIndex.Text = "当前进度：";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(79, 5);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(89, 12);
            this.lblMsg.TabIndex = 30;
            this.lblMsg.Text = "计量：{0} ~{1}";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(3, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 23);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ucTimer
            // 
            this.ucTimer.Location = new System.Drawing.Point(230, 0);
            this.ucTimer.Name = "ucTimer";
            this.ucTimer.Size = new System.Drawing.Size(199, 80);
            this.ucTimer.TabIndex = 35;
            this.ucTimer.StatusChanged += new System.EventHandler<System.TimeSpan>(this.ucTimer_StatusChanged);
            // 
            // UCScedulePlanOperator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tplMain);
            this.Name = "UCScedulePlanOperator";
            this.Size = new System.Drawing.Size(997, 320);
            this.tplMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.tplLeft.ResumeLayout(false);
            this.gbxNote.ResumeLayout(false);
            this.pnlLeftHeader.ResumeLayout(false);
            this.pnlLeftHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tplMain;
        private DevExpress.XtraCharts.ChartControl chart;
        private System.Windows.Forms.TableLayoutPanel tplLeft;
        private System.Windows.Forms.Panel pnlLeftHeader;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label lblCurrenIndex;
        private System.Windows.Forms.TextBox txtCurrentIndex;
        private System.Windows.Forms.Label lblTodayIndex;
        private System.Windows.Forms.TextBox txtTodayIndex;
        private System.Windows.Forms.RichTextBox rtxNode;
        private System.Windows.Forms.GroupBox gbxNote;
        private Common.UCTimer ucTimer;
    }
}

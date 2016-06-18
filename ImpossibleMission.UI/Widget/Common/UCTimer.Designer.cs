namespace ImpossibleMission.Widget.Common
{
    partial class UCTimer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCTimer));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpTimer = new System.Windows.Forms.TabPage();
            this.gaugeControl1 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.digitalGauge1 = new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge();
            this.digitalBackgroundLayerComponent2 = new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent();
            this.btnStart = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tpManual = new System.Windows.Forms.TabPage();
            this.timeSpanEdt = new DevExpress.XtraEditors.TimeSpanEdit();
            this.digitalBackgroundLayerComponent1 = new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tpTimer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.digitalGauge1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.digitalBackgroundLayerComponent2)).BeginInit();
            this.tpManual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeSpanEdt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.digitalBackgroundLayerComponent1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpTimer);
            this.tabControl1.Controls.Add(this.tpManual);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(199, 80);
            this.tabControl1.TabIndex = 0;
            // 
            // tpTimer
            // 
            this.tpTimer.Controls.Add(this.gaugeControl1);
            this.tpTimer.Controls.Add(this.btnStart);
            this.tpTimer.Location = new System.Drawing.Point(4, 22);
            this.tpTimer.Name = "tpTimer";
            this.tpTimer.Padding = new System.Windows.Forms.Padding(3);
            this.tpTimer.Size = new System.Drawing.Size(191, 54);
            this.tpTimer.TabIndex = 0;
            this.tpTimer.Text = "计时器";
            this.tpTimer.UseVisualStyleBackColor = true;
            // 
            // gaugeControl1
            // 
            this.gaugeControl1.AutoLayout = false;
            this.gaugeControl1.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.digitalGauge1});
            this.gaugeControl1.Location = new System.Drawing.Point(53, 7);
            this.gaugeControl1.Name = "gaugeControl1";
            this.gaugeControl1.Size = new System.Drawing.Size(134, 41);
            this.gaugeControl1.TabIndex = 3;
            // 
            // digitalGauge1
            // 
            this.digitalGauge1.AppearanceOff.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#E3E5EA");
            this.digitalGauge1.AppearanceOn.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#59616F");
            this.digitalGauge1.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent[] {
            this.digitalBackgroundLayerComponent2});
            this.digitalGauge1.Bounds = new System.Drawing.Rectangle(3, 3, 125, 36);
            this.digitalGauge1.DigitCount = 6;
            this.digitalGauge1.Name = "digitalGauge1";
            this.digitalGauge1.Padding = new DevExpress.XtraGauges.Core.Base.TextSpacing(26, 20, 26, 20);
            this.digitalGauge1.Text = "00:00:00";
            // 
            // digitalBackgroundLayerComponent2
            // 
            this.digitalBackgroundLayerComponent2.BottomRight = new DevExpress.XtraGauges.Core.Base.PointF2D(313.775F, 99.9625F);
            this.digitalBackgroundLayerComponent2.Name = "digitalBackgroundLayerComponent1";
            this.digitalBackgroundLayerComponent2.ShapeType = DevExpress.XtraGauges.Core.Model.DigitalBackgroundShapeSetType.Style18;
            this.digitalBackgroundLayerComponent2.TopLeft = new DevExpress.XtraGauges.Core.Base.PointF2D(26F, 0F);
            this.digitalBackgroundLayerComponent2.ZOrder = 1000;
            // 
            // btnStart
            // 
            this.btnStart.ImageIndex = 0;
            this.btnStart.ImageList = this.imageList1;
            this.btnStart.Location = new System.Drawing.Point(7, 7);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(41, 41);
            this.btnStart.TabIndex = 0;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Start_48px_1192352_easyicon.net.png");
            this.imageList1.Images.SetKeyName(1, "pause_48px_1140380_easyicon.net.png");
            // 
            // tpManual
            // 
            this.tpManual.Controls.Add(this.timeSpanEdt);
            this.tpManual.Location = new System.Drawing.Point(4, 22);
            this.tpManual.Name = "tpManual";
            this.tpManual.Padding = new System.Windows.Forms.Padding(3);
            this.tpManual.Size = new System.Drawing.Size(191, 54);
            this.tpManual.TabIndex = 1;
            this.tpManual.Text = "手写";
            this.tpManual.UseVisualStyleBackColor = true;
            // 
            // timeSpanEdt
            // 
            this.timeSpanEdt.EditValue = System.TimeSpan.Parse("00:00:00");
            this.timeSpanEdt.Location = new System.Drawing.Point(3, 6);
            this.timeSpanEdt.Name = "timeSpanEdt";
            this.timeSpanEdt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeSpanEdt.Properties.Mask.EditMask = "dd.HH:mm:ss";
            this.timeSpanEdt.Size = new System.Drawing.Size(100, 20);
            this.timeSpanEdt.TabIndex = 0;
            this.timeSpanEdt.EditValueChanged += new System.EventHandler(this.timeSpanEdt_EditValueChanged);
            // 
            // digitalBackgroundLayerComponent1
            // 
            this.digitalBackgroundLayerComponent1.BottomRight = new DevExpress.XtraGauges.Core.Base.PointF2D(265.8125F, 99.9625F);
            this.digitalBackgroundLayerComponent1.Name = "digitalBackgroundLayerComponent1";
            this.digitalBackgroundLayerComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.DigitalBackgroundShapeSetType.Style18;
            this.digitalBackgroundLayerComponent1.TopLeft = new DevExpress.XtraGauges.Core.Base.PointF2D(26F, 0F);
            this.digitalBackgroundLayerComponent1.ZOrder = 1000;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // UCTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "UCTimer";
            this.Size = new System.Drawing.Size(199, 80);
            this.tabControl1.ResumeLayout(false);
            this.tpTimer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.digitalGauge1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.digitalBackgroundLayerComponent2)).EndInit();
            this.tpManual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timeSpanEdt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.digitalBackgroundLayerComponent1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpManual;
        private DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent digitalBackgroundLayerComponent1;
        private System.Windows.Forms.TabPage tpTimer;
        private System.Windows.Forms.Button btnStart;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl1;
        private DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge digitalGauge1;
        private DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent digitalBackgroundLayerComponent2;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.TimeSpanEdit timeSpanEdt;
        private System.Windows.Forms.ImageList imageList1;
    }
}

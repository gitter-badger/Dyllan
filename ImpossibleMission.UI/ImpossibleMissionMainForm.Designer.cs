namespace ImpossibleMission
{
    partial class ImpossibleMissionMainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImpossibleMissionMainForm));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.documentContainer = new TD.SandDock.DocumentContainer();
            this.tdWelcome = new TD.SandDock.TabbedDocument();
            this.sandDockManager1 = new TD.SandDock.SandDockManager();
            this.dockContainerBottom = new TD.SandDock.DockContainer();
            this.dwOutput = new TD.SandDock.DockableWindow();
            this.gcOutput = new DevExpress.XtraGrid.GridControl();
            this.gvOutput = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMessageType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tsOutput = new System.Windows.Forms.ToolStrip();
            this.tsBtnErrors = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnWarning = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnInformation = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnClear = new System.Windows.Forms.ToolStripButton();
            this.tsTxtFilter = new System.Windows.Forms.ToolStripTextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tsStandard = new System.Windows.Forms.ToolStrip();
            this.stbNew = new System.Windows.Forms.ToolStripButton();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiParament = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCreateEbb = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAllPlans = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTask = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTools = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiITEbooks = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxWindow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRename = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.stmiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.documentContainer.SuspendLayout();
            this.dockContainerBottom.SuspendLayout();
            this.dwOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOutput)).BeginInit();
            this.tsOutput.SuspendLayout();
            this.tsStandard.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.ctxWindow.SuspendLayout();
            this.cmsNotify.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlContent);
            this.pnlMain.Controls.Add(this.statusStrip);
            this.pnlMain.Controls.Add(this.tsStandard);
            this.pnlMain.Controls.Add(this.menuStrip);
            resources.ApplyResources(this.pnlMain, "pnlMain");
            this.pnlMain.Name = "pnlMain";
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.documentContainer);
            this.pnlContent.Controls.Add(this.dockContainerBottom);
            resources.ApplyResources(this.pnlContent, "pnlContent");
            this.pnlContent.Name = "pnlContent";
            // 
            // documentContainer
            // 
            this.documentContainer.ContentSize = 329;
            this.documentContainer.Controls.Add(this.tdWelcome);
            this.documentContainer.LayoutSystem = new TD.SandDock.SplitLayoutSystem(new System.Drawing.SizeF(534F, 329F), System.Windows.Forms.Orientation.Horizontal, new TD.SandDock.LayoutSystemBase[] {
            ((TD.SandDock.LayoutSystemBase)(new TD.SandDock.DocumentLayoutSystem(new System.Drawing.SizeF(534F, 329F), new TD.SandDock.DockControl[] {
                        ((TD.SandDock.DockControl)(this.tdWelcome))}, this.tdWelcome)))});
            resources.ApplyResources(this.documentContainer, "documentContainer");
            this.documentContainer.Manager = this.sandDockManager1;
            this.documentContainer.Name = "documentContainer";
            // 
            // tdWelcome
            // 
            this.tdWelcome.BackColor = System.Drawing.SystemColors.Window;
            this.tdWelcome.FloatingSize = new System.Drawing.Size(550, 400);
            this.tdWelcome.Guid = new System.Guid("a391a42f-b7f0-4773-9d75-04f2c86636d9");
            resources.ApplyResources(this.tdWelcome, "tdWelcome");
            this.tdWelcome.Name = "tdWelcome";
            // 
            // sandDockManager1
            // 
            this.sandDockManager1.DockSystemContainer = this.pnlContent;
            this.sandDockManager1.OwnerForm = this;
            this.sandDockManager1.ShowControlContextMenu += new TD.SandDock.ShowControlContextMenuEventHandler(this.sandDockManager1_ShowControlContextMenu);
            this.sandDockManager1.DockControlActivated += new TD.SandDock.DockControlEventHandler(this.sandDockManager1_DockControlActivated);
            // 
            // dockContainerBottom
            // 
            this.dockContainerBottom.ContentSize = 157;
            this.dockContainerBottom.Controls.Add(this.dwOutput);
            resources.ApplyResources(this.dockContainerBottom, "dockContainerBottom");
            this.dockContainerBottom.LayoutSystem = new TD.SandDock.SplitLayoutSystem(new System.Drawing.SizeF(250F, 400F), System.Windows.Forms.Orientation.Vertical, new TD.SandDock.LayoutSystemBase[] {
            ((TD.SandDock.LayoutSystemBase)(new TD.SandDock.ControlLayoutSystem(new System.Drawing.SizeF(385F, 170F), new TD.SandDock.DockControl[] {
                        ((TD.SandDock.DockControl)(this.dwOutput))}, this.dwOutput)))});
            this.dockContainerBottom.Manager = this.sandDockManager1;
            this.dockContainerBottom.Name = "dockContainerBottom";
            // 
            // dwOutput
            // 
            this.dwOutput.BorderStyle = TD.SandDock.Rendering.BorderStyle.Flat;
            this.dwOutput.Controls.Add(this.gcOutput);
            this.dwOutput.Controls.Add(this.tsOutput);
            this.dwOutput.Guid = new System.Guid("ca8fa1d3-5e9c-463b-b815-0fda4ca1ebea");
            resources.ApplyResources(this.dwOutput, "dwOutput");
            this.dwOutput.Name = "dwOutput";
            // 
            // gcOutput
            // 
            resources.ApplyResources(this.gcOutput, "gcOutput");
            this.gcOutput.MainView = this.gvOutput;
            this.gcOutput.Name = "gcOutput";
            this.gcOutput.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvOutput});
            // 
            // gvOutput
            // 
            this.gvOutput.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcTime,
            this.gcMessageType,
            this.gcMessage});
            this.gvOutput.GridControl = this.gcOutput;
            this.gvOutput.Name = "gvOutput";
            this.gvOutput.OptionsView.ShowGroupPanel = false;
            // 
            // gcTime
            // 
            this.gcTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.gcTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcTime.FieldName = "Time";
            this.gcTime.Name = "gcTime";
            this.gcTime.OptionsColumn.AllowEdit = false;
            this.gcTime.OptionsColumn.AllowFocus = false;
            this.gcTime.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcTime.OptionsFilter.AllowAutoFilter = false;
            this.gcTime.OptionsFilter.AllowFilter = false;
            resources.ApplyResources(this.gcTime, "gcTime");
            // 
            // gcMessageType
            // 
            resources.ApplyResources(this.gcMessageType, "gcMessageType");
            this.gcMessageType.FieldName = "MessageType";
            this.gcMessageType.Name = "gcMessageType";
            this.gcMessageType.OptionsColumn.AllowEdit = false;
            this.gcMessageType.OptionsColumn.AllowFocus = false;
            this.gcMessageType.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcMessageType.OptionsFilter.AllowAutoFilter = false;
            // 
            // gcMessage
            // 
            resources.ApplyResources(this.gcMessage, "gcMessage");
            this.gcMessage.FieldName = "Message";
            this.gcMessage.Name = "gcMessage";
            this.gcMessage.OptionsColumn.AllowEdit = false;
            this.gcMessage.OptionsColumn.AllowFocus = false;
            this.gcMessage.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcMessage.OptionsFilter.AllowAutoFilter = false;
            this.gcMessage.OptionsFilter.AllowFilter = false;
            // 
            // tsOutput
            // 
            this.tsOutput.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnErrors,
            this.toolStripSeparator2,
            this.tsBtnWarning,
            this.toolStripSeparator3,
            this.tsBtnInformation,
            this.toolStripSeparator1,
            this.tsBtnClear,
            this.tsTxtFilter});
            this.tsOutput.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            resources.ApplyResources(this.tsOutput, "tsOutput");
            this.tsOutput.Name = "tsOutput";
            // 
            // tsBtnErrors
            // 
            this.tsBtnErrors.Image = global::ImpossibleMission.Properties.Resources.Error_16px_1134460_easyicon_net;
            resources.ApplyResources(this.tsBtnErrors, "tsBtnErrors");
            this.tsBtnErrors.Name = "tsBtnErrors";
            this.tsBtnErrors.Click += new System.EventHandler(this.tsBtnErrors_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // tsBtnWarning
            // 
            this.tsBtnWarning.BackColor = System.Drawing.SystemColors.Control;
            this.tsBtnWarning.Image = global::ImpossibleMission.Properties.Resources.sign_warning_15_223300970874px_1185695_easyicon_net;
            resources.ApplyResources(this.tsBtnWarning, "tsBtnWarning");
            this.tsBtnWarning.Name = "tsBtnWarning";
            this.tsBtnWarning.Click += new System.EventHandler(this.tsBtnWarning_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // tsBtnInformation
            // 
            this.tsBtnInformation.Image = global::ImpossibleMission.Properties.Resources.information_16px_1128290_easyicon_net;
            resources.ApplyResources(this.tsBtnInformation, "tsBtnInformation");
            this.tsBtnInformation.Name = "tsBtnInformation";
            this.tsBtnInformation.Click += new System.EventHandler(this.tsBtnInformation_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // tsBtnClear
            // 
            this.tsBtnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnClear.Image = global::ImpossibleMission.Properties.Resources.Clear_16px_1186688_easyicon_net;
            resources.ApplyResources(this.tsBtnClear, "tsBtnClear");
            this.tsBtnClear.Name = "tsBtnClear";
            this.tsBtnClear.Click += new System.EventHandler(this.tsBtnClear_Click);
            // 
            // tsTxtFilter
            // 
            this.tsTxtFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tsTxtFilter.Name = "tsTxtFilter";
            resources.ApplyResources(this.tsTxtFilter, "tsTxtFilter");
            // 
            // statusStrip
            // 
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // tsStandard
            // 
            resources.ApplyResources(this.tsStandard, "tsStandard");
            this.tsStandard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stbNew});
            this.tsStandard.Name = "tsStandard";
            // 
            // stbNew
            // 
            resources.ApplyResources(this.stbNew, "stbNew");
            this.stbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stbNew.Image = global::ImpossibleMission.Properties.Resources.new_file_32px_1187338_easyicon_net;
            this.stbNew.Name = "stbNew";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiView,
            this.tsmiTools});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNew});
            this.tsmiFile.Name = "tsmiFile";
            resources.ApplyResources(this.tsmiFile, "tsmiFile");
            // 
            // tsmiNew
            // 
            this.tsmiNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiParament,
            this.tsmiCreateEbb});
            this.tsmiNew.Name = "tsmiNew";
            resources.ApplyResources(this.tsmiNew, "tsmiNew");
            // 
            // tsmiParament
            // 
            this.tsmiParament.Name = "tsmiParament";
            resources.ApplyResources(this.tsmiParament, "tsmiParament");
            this.tsmiParament.Click += new System.EventHandler(this.CreateSchedule_Click);
            // 
            // tsmiCreateEbb
            // 
            this.tsmiCreateEbb.Name = "tsmiCreateEbb";
            resources.ApplyResources(this.tsmiCreateEbb, "tsmiCreateEbb");
            this.tsmiCreateEbb.Click += new System.EventHandler(this.tsmiCreateEbb_Click);
            // 
            // tsmiView
            // 
            this.tsmiView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAllPlans,
            this.tsmiTask});
            this.tsmiView.Name = "tsmiView";
            resources.ApplyResources(this.tsmiView, "tsmiView");
            // 
            // tsmiAllPlans
            // 
            this.tsmiAllPlans.Name = "tsmiAllPlans";
            resources.ApplyResources(this.tsmiAllPlans, "tsmiAllPlans");
            this.tsmiAllPlans.Click += new System.EventHandler(this.ShowAllPlans_Click);
            // 
            // tsmiTask
            // 
            this.tsmiTask.Name = "tsmiTask";
            resources.ApplyResources(this.tsmiTask, "tsmiTask");
            this.tsmiTask.Click += new System.EventHandler(this.tsmiTask_Click);
            // 
            // tsmiTools
            // 
            this.tsmiTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiITEbooks});
            this.tsmiTools.Name = "tsmiTools";
            resources.ApplyResources(this.tsmiTools, "tsmiTools");
            // 
            // tsmiITEbooks
            // 
            this.tsmiITEbooks.Name = "tsmiITEbooks";
            resources.ApplyResources(this.tsmiITEbooks, "tsmiITEbooks");
            this.tsmiITEbooks.Click += new System.EventHandler(this.tsmiITEbooks_Click);
            // 
            // ctxWindow
            // 
            this.ctxWindow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSave,
            this.tsmiRename,
            this.tsmiRefresh,
            this.tsSeparator1,
            this.stmiClose});
            this.ctxWindow.Name = "ctxWindow";
            resources.ApplyResources(this.ctxWindow, "ctxWindow");
            this.ctxWindow.Opening += new System.ComponentModel.CancelEventHandler(this.ctxWindow_Opening);
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            resources.ApplyResources(this.tsmiSave, "tsmiSave");
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // tsmiRename
            // 
            this.tsmiRename.Name = "tsmiRename";
            resources.ApplyResources(this.tsmiRename, "tsmiRename");
            this.tsmiRename.Click += new System.EventHandler(this.tsmiRename_Click);
            // 
            // tsmiRefresh
            // 
            this.tsmiRefresh.Name = "tsmiRefresh";
            resources.ApplyResources(this.tsmiRefresh, "tsmiRefresh");
            this.tsmiRefresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // tsSeparator1
            // 
            this.tsSeparator1.Name = "tsSeparator1";
            resources.ApplyResources(this.tsSeparator1, "tsSeparator1");
            // 
            // stmiClose
            // 
            this.stmiClose.Name = "stmiClose";
            resources.ApplyResources(this.stmiClose, "stmiClose");
            this.stmiClose.Click += new System.EventHandler(this.stmiClose_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.cmsNotify;
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // cmsNotify
            // 
            this.cmsNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRestore,
            this.tsmiExit});
            this.cmsNotify.Name = "cmsNotify";
            resources.ApplyResources(this.cmsNotify, "cmsNotify");
            // 
            // tsmiRestore
            // 
            this.tsmiRestore.Name = "tsmiRestore";
            resources.ApplyResources(this.tsmiRestore, "tsmiRestore");
            this.tsmiRestore.Click += new System.EventHandler(this.tsmiRestore_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            resources.ApplyResources(this.tsmiExit, "tsmiExit");
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // ImpossibleMissionMainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "ImpossibleMissionMainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImpossibleMissionMainForm_FormClosing);
            this.SizeChanged += new System.EventHandler(this.ImpossibleMissionMainForm_SizeChanged);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.documentContainer.ResumeLayout(false);
            this.dockContainerBottom.ResumeLayout(false);
            this.dwOutput.ResumeLayout(false);
            this.dwOutput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOutput)).EndInit();
            this.tsOutput.ResumeLayout(false);
            this.tsOutput.PerformLayout();
            this.tsStandard.ResumeLayout(false);
            this.tsStandard.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ctxWindow.ResumeLayout(false);
            this.cmsNotify.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiNew;
        private System.Windows.Forms.ToolStripMenuItem tsmiParament;
        private System.Windows.Forms.ToolStripMenuItem tsmiCreateEbb;
        private System.Windows.Forms.ToolStrip tsStandard;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Panel pnlContent;
        private TD.SandDock.DockContainer dockContainerBottom;
        private TD.SandDock.SandDockManager sandDockManager1;
        TD.SandDock.DocumentContainer documentContainer;
        private TD.SandDock.TabbedDocument tdWelcome;
        private System.Windows.Forms.ContextMenuStrip ctxWindow;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiRename;
        private System.Windows.Forms.ToolStripMenuItem stmiClose;
        private System.Windows.Forms.ToolStripSeparator tsSeparator1;
        private TD.SandDock.DockableWindow dwOutput;
        private System.Windows.Forms.ToolStrip tsOutput;
        private System.Windows.Forms.ToolStripButton tsBtnErrors;
        private System.Windows.Forms.ToolStripButton tsBtnWarning;
        private System.Windows.Forms.ToolStripButton tsBtnInformation;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox tsTxtFilter;
        private System.Windows.Forms.ToolStripButton tsBtnClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton stbNew;
        private System.Windows.Forms.ToolStripMenuItem tsmiView;
        private System.Windows.Forms.ToolStripMenuItem tsmiAllPlans;
        private System.Windows.Forms.ToolStripMenuItem tsmiTask;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefresh;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip cmsNotify;
        private System.Windows.Forms.ToolStripMenuItem tsmiRestore;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiTools;
        private System.Windows.Forms.ToolStripMenuItem tsmiITEbooks;
        private DevExpress.XtraGrid.GridControl gcOutput;
        private DevExpress.XtraGrid.Views.Grid.GridView gvOutput;
        private DevExpress.XtraGrid.Columns.GridColumn gcTime;
        private DevExpress.XtraGrid.Columns.GridColumn gcMessageType;
        private DevExpress.XtraGrid.Columns.GridColumn gcMessage;
    }
}


namespace ImpossibleMission.Widget.File
{
    partial class ActivePlanManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActivePlanManager));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcGuid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProgress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.gcUpdated = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.gridControl1);
            // 
            // gridControl1
            // 
            resources.ApplyResources(this.gridControl1, "gridControl1");
            this.gridControl1.MainView = this.gv;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemProgressBar1});
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcGuid,
            this.gcName,
            this.gcStartDate,
            this.gcEndDate,
            this.gcProgress,
            this.gcUpdated,
            this.gcStatus,
            this.gcTypeName});
            this.gv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gv.GridControl = this.gridControl1;
            this.gv.GroupCount = 1;
            this.gv.Name = "gv";
            this.gv.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.True;
            this.gv.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.True;
            this.gv.OptionsBehavior.AutoExpandAllGroups = true;
            this.gv.OptionsDetail.EnableMasterViewMode = false;
            this.gv.OptionsView.ShowGroupPanel = false;
            this.gv.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcTypeName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gv.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GV_FocusedRowChanged);
            // 
            // gcGuid
            // 
            resources.ApplyResources(this.gcGuid, "gcGuid");
            this.gcGuid.FieldName = "ID";
            this.gcGuid.Name = "gcGuid";
            this.gcGuid.OptionsColumn.AllowEdit = false;
            this.gcGuid.OptionsColumn.AllowFocus = false;
            // 
            // gcName
            // 
            resources.ApplyResources(this.gcName, "gcName");
            this.gcName.FieldName = "Name";
            this.gcName.Name = "gcName";
            this.gcName.OptionsColumn.AllowEdit = false;
            this.gcName.OptionsColumn.AllowFocus = false;
            // 
            // gcStartDate
            // 
            resources.ApplyResources(this.gcStartDate, "gcStartDate");
            this.gcStartDate.FieldName = "StartDate";
            this.gcStartDate.Name = "gcStartDate";
            this.gcStartDate.OptionsColumn.AllowEdit = false;
            this.gcStartDate.OptionsColumn.AllowFocus = false;
            // 
            // gcEndDate
            // 
            resources.ApplyResources(this.gcEndDate, "gcEndDate");
            this.gcEndDate.FieldName = "EndDate";
            this.gcEndDate.Name = "gcEndDate";
            this.gcEndDate.OptionsColumn.AllowEdit = false;
            this.gcEndDate.OptionsColumn.AllowFocus = false;
            // 
            // gcProgress
            // 
            resources.ApplyResources(this.gcProgress, "gcProgress");
            this.gcProgress.ColumnEdit = this.repositoryItemProgressBar1;
            this.gcProgress.FieldName = "CompletedPercent";
            this.gcProgress.Name = "gcProgress";
            this.gcProgress.OptionsColumn.AllowEdit = false;
            this.gcProgress.OptionsColumn.AllowFocus = false;
            this.gcProgress.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            this.repositoryItemProgressBar1.ShowTitle = true;
            // 
            // gcUpdated
            // 
            resources.ApplyResources(this.gcUpdated, "gcUpdated");
            this.gcUpdated.FieldName = "DailyUpdated";
            this.gcUpdated.Name = "gcUpdated";
            this.gcUpdated.OptionsColumn.AllowFocus = false;
            // 
            // gcStatus
            // 
            resources.ApplyResources(this.gcStatus, "gcStatus");
            this.gcStatus.FieldName = "Status";
            this.gcStatus.Name = "gcStatus";
            this.gcStatus.OptionsColumn.AllowEdit = false;
            this.gcStatus.OptionsColumn.AllowFocus = false;
            // 
            // gcTypeName
            // 
            resources.ApplyResources(this.gcTypeName, "gcTypeName");
            this.gcTypeName.FieldName = "TypeName";
            this.gcTypeName.Name = "gcTypeName";
            this.gcTypeName.OptionsColumn.AllowEdit = false;
            this.gcTypeName.OptionsColumn.AllowFocus = false;
            // 
            // ActivePlanManager
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "ActivePlanManager";
            this.splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private DevExpress.XtraGrid.Columns.GridColumn gcTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn gcStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gcProgress;
        private DevExpress.XtraGrid.Columns.GridColumn gcEndDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcName;
        private DevExpress.XtraGrid.Columns.GridColumn gcGuid;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private DevExpress.XtraGrid.Columns.GridColumn gcUpdated;
    }
}

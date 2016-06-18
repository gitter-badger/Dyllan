namespace ImpossibleMission.Widget.File
{
    partial class PlanManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlanManager));
            this.cmsOperation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.lvMain = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StartDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EndDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsOperation.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsOperation
            // 
            this.cmsOperation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stmiDelete,
            this.tsmiRefresh});
            this.cmsOperation.Name = "cmsOperation";
            resources.ApplyResources(this.cmsOperation, "cmsOperation");
            // 
            // stmiDelete
            // 
            this.stmiDelete.Name = "stmiDelete";
            resources.ApplyResources(this.stmiDelete, "stmiDelete");
            this.stmiDelete.Click += new System.EventHandler(this.stmiDelete_Click);
            // 
            // tsmiRefresh
            // 
            this.tsmiRefresh.Name = "tsmiRefresh";
            resources.ApplyResources(this.tsmiRefresh, "tsmiRefresh");
            this.tsmiRefresh.Click += new System.EventHandler(this.tsmiRefresh_Click);
            // 
            // lvMain
            // 
            this.lvMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.HName,
            this.StartDate,
            this.EndDate,
            this.Type,
            this.Status});
            this.lvMain.ContextMenuStrip = this.cmsOperation;
            resources.ApplyResources(this.lvMain, "lvMain");
            this.lvMain.FullRowSelect = true;
            this.lvMain.GridLines = true;
            this.lvMain.Name = "lvMain";
            this.lvMain.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lvMain.UseCompatibleStateImageBehavior = false;
            this.lvMain.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            resources.ApplyResources(this.ID, "ID");
            // 
            // HName
            // 
            resources.ApplyResources(this.HName, "HName");
            // 
            // StartDate
            // 
            resources.ApplyResources(this.StartDate, "StartDate");
            // 
            // EndDate
            // 
            resources.ApplyResources(this.EndDate, "EndDate");
            // 
            // Type
            // 
            resources.ApplyResources(this.Type, "Type");
            // 
            // Status
            // 
            resources.ApplyResources(this.Status, "Status");
            // 
            // PlanManager
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvMain);
            this.Name = "PlanManager";
            this.cmsOperation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsOperation;
        private System.Windows.Forms.ToolStripMenuItem stmiDelete;
        private System.Windows.Forms.ListView lvMain;
        private System.Windows.Forms.ColumnHeader HName;
        private System.Windows.Forms.ColumnHeader StartDate;
        private System.Windows.Forms.ColumnHeader EndDate;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefresh;
    }
}

using ImpossibleMission.Widget;
using ImpossibleMission.Widget.File;
using ImpossibleMission.Widget.File.Ebbinghaus;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TD.SandDock;

namespace ImpossibleMission
{
    [Flags]
    public enum OutputFilterEnum
    {
        Default = 0x0,
        Error = 0x01,
        Warning = 0x02,
        Information = 0x04,
        All = 0x07,
        Non_Error = 0x05,
    }

    public partial class ImpossibleMissionMainForm : Form
    {
        private OutputFilterEnum _outputFilter = OutputFilterEnum.All;
        private DockControl _lastActivatedWindow;
        const string CREATREBBPLAN = "CreateEbbPlan";
        const string CREATEPARAMENTPLAN = "CreateParamentPlan";
        const string ALLPLANS = "All Plans";
        const string MYTASK = "MYTASK";
        public ImpossibleMissionMainForm()
        {
            InitializeComponent();
            InitialStartPage();
        }

        private void InitialStartPage()
        {
            this.Icon = UIResource.Impossible;
            this.notifyIcon.Icon = UIResource.Impossible;
            ActivePlanManager activePlanManager = new ActivePlanManager();
            activePlanManager.Dock = DockStyle.Fill;
            this.tdWelcome.Controls.Add(activePlanManager);
            Transaction.RegisiterStatusChanged(AddEbbinghous_StatusChanged);
            // TODO
            SetOutputButtonsStatus();
        }

        private void DoCommand(string commandLine)
        {
            switch (commandLine)
            {
                case CREATREBBPLAN:
                    AddEbbinghous addEbbinghous = new AddEbbinghous();
                    AddFormToTabControl(addEbbinghous);
                    break;
                case CREATEPARAMENTPLAN:
                    AddSchedulePlan addSchedulePlan = new AddSchedulePlan();
                    AddFormToTabControl(addSchedulePlan);
                    break;
                case ALLPLANS:
                    NavigateOrAddFormToTabControl(typeof(PlanManager));
                    break;
                case MYTASK:
                    NavigateOrAddFormToTabControl(typeof(ActivePlanManager));
                    break;
            }
        }

        private void AddFormToTabControl(UserControl control)
        {
            string name = control.Name;

            UCTabbedDocument doc = control as UCTabbedDocument;
            if (doc != null)
            {
                name = doc.Title;
            }

            if (string.IsNullOrEmpty(name))
                name = Guid.NewGuid().ToString();

            DockControl window = new TabbedDocument(sandDockManager1, control, name);
            window.Open();
        }

        private void NavigateOrAddFormToTabControl(Type controlType)
        {
            foreach (DockControl doc in sandDockManager1.DocumentContainer.Controls)
            {
                if (doc.Controls.Count > 0  && doc.Controls[0].GetType() == controlType)
                {
                    doc.Open();
                    return;
                }
            }

            UCTabbedDocument ucDoc = (UCTabbedDocument)Activator.CreateInstance(controlType);
            AddFormToTabControl(ucDoc);
        }

        private void tsmiCreateEbb_Click(object sender, EventArgs e)
        {
            DoCommand(CREATREBBPLAN);
        }

        private void sandDockManager1_ShowControlContextMenu(object sender, ShowControlContextMenuEventArgs e)
        {
            ctxWindow.Show(e.DockControl, e.Position);
        }

        private void ctxWindow_Opening(object sender, CancelEventArgs e)
        {
            UCTabbedDocument ucDoc = GetActiveUCTabbedDocument();
            UCTabbedStatus status = ucDoc == null ? UCTabbedStatus.Default : ucDoc.TabbedStatus;
            tsmiSave.Visible = (status & UCTabbedStatus.SaveVisible) == UCTabbedStatus.SaveVisible;
            tsmiSave.Enabled = (status & UCTabbedStatus.SaveEnable) == UCTabbedStatus.SaveEnable;
            tsmiRename.Visible = (status & UCTabbedStatus.AllowTitleChange) == UCTabbedStatus.AllowTitleChange;
            tsmiRefresh.Visible = (status & UCTabbedStatus.RefreshVisible) == UCTabbedStatus.RefreshVisible;
            tsmiRefresh.Enabled = (status & UCTabbedStatus.RefreshEnable) == UCTabbedStatus.RefreshEnable;
            tsSeparator1.Visible = !(status == UCTabbedStatus.Default);
        }

        private UCTabbedDocument GetActiveUCTabbedDocument()
        {
            if (_lastActivatedWindow == null)
                return null;

            return _lastActivatedWindow.Controls.Count > 0 ? _lastActivatedWindow.Controls[0] as UCTabbedDocument : null;
        }

        private UCTabbedDocument GetUCTabbedDocumentByType(Type ucTabbedType)
        {
            foreach (DockControl doc in sandDockManager1.DocumentContainer.Controls)
            {
                if (doc.Controls.Count > 0 && doc.Controls[0].GetType() == ucTabbedType)
                {
                    return (UCTabbedDocument)doc.Controls[0];
                }
            }
            return null;
        }

        private void sandDockManager1_DockControlActivated(object sender, DockControlEventArgs e)
        {
            _lastActivatedWindow = e.DockControl;
        }

        #region Document Context

        private void AddEbbinghous_StatusChanged(IStatus e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<IStatus>(AddEbbinghous_StatusChanged), e);
            }
            else
            {
                SetOutputButtonsStatus();
                this.gcOutput.DataSource = e.Status;
                this.gvOutput.RefreshData();
                UpdateDocumentTitle();
            }
        }

        private void UpdateDocumentTitle()
        {
            UCTabbedDocument ucDoc = GetActiveUCTabbedDocument();
            if (ucDoc != null)
            {
                if (_lastActivatedWindow != null && ucDoc != null)
                {
                    _lastActivatedWindow.Text = ucDoc.Title;
                }
            }
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            UCTabbedDocument ucDoc = GetActiveUCTabbedDocument();
            if (ucDoc != null)
            {
                ucDoc.Execute();
            }
        }

        private void tsmiRename_Click(object sender, EventArgs e)
        {
            UCTabbedDocument ucDoc = GetActiveUCTabbedDocument();
            if (ucDoc != null)
            {
                ucDoc.Rename();
                UpdateDocumentTitle();
            }
        }

        private void stmiClose_Click(object sender, EventArgs e)
        {
            if (_lastActivatedWindow != null)
            {
                _lastActivatedWindow.Close();
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            UCTabbedDocument ucDoc = GetActiveUCTabbedDocument();
            if (ucDoc != null)
            {
                ucDoc.SelfRefresh();
            }
        }

        private void CreateSchedule_Click(object sender, EventArgs e)
        {
            DoCommand(CREATEPARAMENTPLAN);
        }

        private void ShowAllPlans_Click(object sender, EventArgs e)
        {
            DoCommand(ALLPLANS);
        }
        
        #endregion

        #region Output window

        private static Color GetColor(bool isSelect)
        {
            return isSelect ? SystemColors.GradientActiveCaption : SystemColors.Control;
        }

        private void SetOutputButtonsStatus()
        {
            this.tsBtnErrors.BackColor = GetColor(_outputFilter.HasFlag(OutputFilterEnum.Error));
            this.tsBtnWarning.BackColor = GetColor(_outputFilter.HasFlag(OutputFilterEnum.Warning));
            this.tsBtnInformation.BackColor = GetColor(_outputFilter.HasFlag(OutputFilterEnum.Information));
        }

        private void tsBtnErrors_Click(object sender, EventArgs e)
        {
            SetOutputFlag(OutputFilterEnum.Error);
            SetOutputButtonsStatus();
        }

        private void SetOutputFlag(OutputFilterEnum flag)
        {
            if (_outputFilter.HasFlag(flag))
            {
                _outputFilter &= ~flag;
            }
            else
            {
                _outputFilter |= flag;
            }
        }

        private void tsBtnWarning_Click(object sender, EventArgs e)
        {
            SetOutputFlag(OutputFilterEnum.Warning);
            SetOutputButtonsStatus();
        }

        private void tsBtnInformation_Click(object sender, EventArgs e)
        {
            SetOutputFlag(OutputFilterEnum.Information);
            SetOutputButtonsStatus();
        }

        private void tsBtnClear_Click(object sender, EventArgs e)
        {
            Transaction.ClearStatus();
            gvOutput.RefreshData();
        }
        #endregion

        #region SystemTray

        private bool _exit = false;

        private void tsmiTask_Click(object sender, EventArgs e)
        {
            DoCommand(MYTASK);
        }
        
        private void tsmiExit_Click(object sender, EventArgs e)
        {
            _exit = true;
            this.Close();
        }

        private void tsmiRestore_Click(object sender, EventArgs e)
        {
            SystemTray(true);
        }

        private void ImpossibleMissionMainForm_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                SystemTray(false);
            }
        }

        private void ImpossibleMissionMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_exit)
            { 
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;
            }
        }

        private void SystemTray(bool show)
        {
            if (show)
            {
                WindowState = FormWindowState.Maximized;
                this.ShowInTaskbar = true;
                UCTabbedDocument doc = GetUCTabbedDocumentByType(typeof(ActivePlanManager));
                if (doc != null)
                    doc.SelfRefresh(false);
            }
            else
            {
                this.ShowInTaskbar = false;
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            SystemTray(true);
        }

        #endregion

        private void tsmiITEbooks_Click(object sender, EventArgs e)
        {
            GetITBook getItBook = GetITBook.Instance;
            getItBook.Show();
        }
    }
}

using ImpossibleMission.Controller.File.Ebbinghaus;
using ImpossibleMission.Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImpossibleMission.Widget.File.Ebbinghaus
{
    public partial class AddEbbinghous : UCTabbedDocument
    {
        EbbinghausTemplate EbbinghausTemplate;
        AddEbbinghousTransaction addEbbinghousTransaction = new AddEbbinghousTransaction();

        #region override
        public override string Title
        {
            get
            {
                return addEbbinghousTransaction.Name;
            }
        }

        public override void Execute()
        {
            if ((_tabbedStatus & UCTabbedStatus.SaveEnable) != UCTabbedStatus.SaveEnable)
            {
                return;
            }
            base.Execute();
            BindData();
            _tabbedStatus &= ~UCTabbedStatus.SaveTEnable;
            this.Enabled = false;
            Task task = Task.Run(new Action(addEbbinghousTransaction.Execute));
            task.ContinueWith(new Action<Task>(OnStatusChanged), _guiTaskScheduler);
        }

        private void OnStatusChanged(Task task)
        {
            var outPutMessage = addEbbinghousTransaction.Status.LastOrDefault();
            if (outPutMessage != null && outPutMessage.MessageType != MessageType.Success)
            {
                _tabbedStatus |= UCTabbedStatus.SaveEnable;
                this.Enabled = true;
            }
            else
            {
                _tabbedStatus = UCTabbedStatus.Default;
            }
        }

        public override void Rename()
        {
            addEbbinghousTransaction.ChooseName(true);
        }
        #endregion

        public AddEbbinghous()
        {
            _tabbedStatus = UCTabbedStatus.SaveEnable | UCTabbedStatus.AllowTitleChange;
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            EbbinghausTemplate = addEbbinghousTransaction.EbbinghausTemplate;
            chkDefaultEbbinghous.Checked = addEbbinghousTransaction.IsTemplateDefault;
            rtxDescription.Text = addEbbinghousTransaction.EbbinghausTemplate.Description;
            dtPicker.CustomFormat = Constant.DateFormat;
            dtPicker.Format = DateTimePickerFormat.Custom;
            dtPicker.Value = DateTime.Now;
        }

        private void ValidateData()
        { }

        private void BindData()
        {
            addEbbinghousTransaction.IsTemplateDefault = chkDefaultEbbinghous.Checked;
            addEbbinghousTransaction.ExecuteDate = dtPicker.Value;
            addEbbinghousTransaction.Details = rtxDetails.Text;
            addEbbinghousTransaction.SetNameFormatter(ucNameFormatter.NameFormatter, ucNameFormatter.Args);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Execute();
        }
    }
}

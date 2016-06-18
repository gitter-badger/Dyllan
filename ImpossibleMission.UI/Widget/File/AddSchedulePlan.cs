using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImpossibleMission.Controller.File;

namespace ImpossibleMission.Widget.File
{
    public partial class AddSchedulePlan : UCTabbedDocument
    {
        AddSchedulePlanTransaction addSchedulePlanTransaction = new AddSchedulePlanTransaction();
        #region override
        public override string Title
        {
            get
            {
                return addSchedulePlanTransaction.Name;
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
            Task task = Task.Run(new Action(addSchedulePlanTransaction.Execute));
            task.ContinueWith(new Action<Task>(OnStatusChanged), _guiTaskScheduler);
        }

        private void OnStatusChanged(Task task)
        {
            var outPutMessage = addSchedulePlanTransaction.Status.LastOrDefault();
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
            _tabbedStatus = UCTabbedStatus.SaveEnable | UCTabbedStatus.AllowTitleChange;
            addSchedulePlanTransaction.ChooseName(true);
        }
        #endregion

        private void BindData()
        {
            addSchedulePlanTransaction.ExecuteDate = dtPicker.Value;
            addSchedulePlanTransaction.Details = rtxDetails.Text;
            if (!string.IsNullOrEmpty(txtStartIndex.Text))
                addSchedulePlanTransaction.StartIndex = int.Parse(txtStartIndex.Text);
            if (!string.IsNullOrEmpty(txtEndIndex.Text))
                addSchedulePlanTransaction.EndIndex = int.Parse(txtEndIndex.Text);
            if (!string.IsNullOrEmpty(txtWorkdayWorkload.Text))
                addSchedulePlanTransaction.WeekDayWorkload = int.Parse(txtWorkdayWorkload.Text);
            if (!string.IsNullOrEmpty(txtWeekendWorkload.Text))
                addSchedulePlanTransaction.WeekendWorkload = int.Parse(txtWeekendWorkload.Text);
            if (!string.IsNullOrEmpty(txtBuffer.Text))
                addSchedulePlanTransaction.Buffer = float.Parse(txtBuffer.Text) / 100f;
        }

        private void TxtChanged(object sender, EventArgs e)
        {
            BindData();
            txtAmount.Text = addSchedulePlanTransaction.Amount.ToString();
            DateTime? endDate = addSchedulePlanTransaction.EndDate;
            txtEndDate.Text = (endDate.HasValue ? endDate.Value.ToString(Constant.DateFormat) : string.Empty);
        }

        private void Number_TextChanged(object sender, EventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            txtBox.Text = Constant.NumberRegex.Match(txtBox.Text).Value;
            TxtChanged(sender, e);
        }

        private void Float_TextChanged(object sender, EventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            txtBox.Text = Constant.FloatRegex.Match(txtBox.Text).Value;
            TxtChanged(sender, e);
        }

        public AddSchedulePlan()
        {
            _tabbedStatus = UCTabbedStatus.SaveEnable | UCTabbedStatus.AllowTitleChange;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Execute();
        }
    }
}

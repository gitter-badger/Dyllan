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
using ImpossibleMission.Model;

namespace ImpossibleMission.Widget.File
{
    public partial class PlanManager : UCTabbedDocument
    {
        #region override
        public override string Title
        {
            get
            {
                return "Plan Manage";
            }
        }
        #endregion

        PlanTransaction _planTransaction = PlanTransaction.Instance;

        public PlanManager()
        {
            _tabbedStatus = UCTabbedStatus.Default;
            InitializeComponent();
            GetSource(false);
        }

        IEnumerable<Plan> _dataSource = null;

        private void GetSource(bool refresh)
        {
            if (refresh || _planTransaction.AllPlans == null)
            {
                Task task = Task.Run(new Action(_planTransaction.Execute));
                task.ContinueWith(GetSourceCallBack, _guiTaskScheduler);
            }
            else
            {
                GetSourceCallBack(null);
            }
        }

        private void GetSourceCallBack(Task task)
        {
            _dataSource = _planTransaction.AllPlans;
            LoadDataSource();
        }
        private void LoadDataSource()
        {
            lvMain.Items.Clear();
            foreach (var plan in _dataSource)
            {
                ListViewItem lvi = new ListViewItem(plan.ID.ToString());
                lvi.SubItems.Add(plan.Name);
                lvi.SubItems.Add(plan.StartDate.ToString(Constant.DateFormat));
                lvi.SubItems.Add(plan.EndDate.ToString(Constant.DateFormat));
                lvi.SubItems.Add(plan.GetType().Name);
                lvi.SubItems.Add(plan.Status.ToString());
                lvMain.Items.Add(lvi);
            }
        }

        private void stmiDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvMain.SelectedItems)
            {
                Guid tempId = Guid.Parse(item.Text);
                Plan plan = _dataSource.FirstOrDefault(p => p.ID == tempId);
                _planTransaction.DeletaPlan(plan);
                LoadDataSource();
            }
        }

        private void tsmiRefresh_Click(object sender, EventArgs e)
        {
            GetSource(true);
        }

        public override void SelfRefresh(bool fauseRefresh = true)
        {
            GetSource(fauseRefresh);
        }
    }
}

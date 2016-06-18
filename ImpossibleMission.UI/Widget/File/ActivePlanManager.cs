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
using System.Threading;
using Timer = System.Threading.Timer;

namespace ImpossibleMission.Widget.File
{
    public partial class ActivePlanManager : UCTabbedDocument
    {
        public override string Title
        {
            get
            {
                return "My Task";
            }
        }

        Timer _timer;
        ActivePlanTransaction _activePlanTransaction = ActivePlanTransaction.Instance;

        private ActivePlanOperatorContext _activePlanOpeContext = ActivePlanOperatorContext.Instance;
        List<Plan> _dataSource = null;
        private void LoadDataSource()
        {
            _timer = new Timer(Refresh, false, 0, Timeout.Infinite);
        }

        public ActivePlanManager()
        {
            _tabbedStatus = UCTabbedStatus.RefreshEnable;
            InitializeComponent();
            LoadDataSource();
        }

        private void GV_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int index = gv.ViewRowHandleToDataSourceIndex(e.FocusedRowHandle);
            if (index >= 0 && _dataSource.Count > index)
            {
                Plan plan = _dataSource[index];
                Control control = null;
                if (plan.CompletedPercent < 100)
                {
                    control = _activePlanOpeContext.GetDailyItemOperator(plan);
                }
                else
                {
                    control = _activePlanOpeContext.GetCompleteOperator(plan);
                }
                control.Dock = DockStyle.Fill;
                splitContainer.Panel2.Controls.Clear();
                if (control != null)
                    splitContainer.Panel2.Controls.Add(control);
            }
        }

        private DateTime _lastRefreshTime = DateTime.MinValue;
        private void Refresh(object state)
        {
            if ((bool)state || _activePlanTransaction.ActivePlans == null || _lastRefreshTime.Date < DateTime.Now.Date)
            {
                _activePlanTransaction.Execute();
                if (_activePlanTransaction.ActivePlans != null)
                {
                    _dataSource = _activePlanTransaction.ActivePlans;
                    if (gridControl1.InvokeRequired)
                    {
                        gridControl1.Invoke(new Action(RefreshUI));
                    }
                    else
                    {
                        RefreshUI();
                    }
                    _lastRefreshTime = DateTime.Now;
                }
            }
            _timer.Change(60 * 60 * 1000, Timeout.Infinite);
        }

        private void RefreshUI()
        {
            gridControl1.DataSource = _dataSource;
        }

        public override void SelfRefresh(bool fauseRefresh = true)
        {
            Task.Run(new Action(() => { Refresh(fauseRefresh); }));
        }
    }
}

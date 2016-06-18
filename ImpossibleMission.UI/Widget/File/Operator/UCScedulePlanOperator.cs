using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImpossibleMission.Model;
using ImpossibleMission.Controller.File;
using DevExpress.XtraCharts;

namespace ImpossibleMission.Widget.File
{
    public partial class UCScedulePlanOperator : UCDailyItemOperator
    {
        private readonly SchedulePlan _sPlan;
        private SchedulePlanOperatorTransaction _transaction;
        Series ActuralSeries { get { return chart.Series[0]; } }
        Series ExpectedSeries { get { return chart.Series[1]; } }
        Series PlanSeries { get { return chart.Series[2]; } }
        public UCScedulePlanOperator(SchedulePlan plan)
            : base(plan)
        {
            _tabbedStatus = UCTabbedStatus.SaveEnable;
            InitializeComponent();
            _sPlan = plan;
            _transaction = new SchedulePlanOperatorTransaction(_sPlan);
            InitialData();
        }

        private void InitialData()
        {
            SetMaxMinValueOfXYDiagram();
            ucTimer.CostTime = _transaction.CostTime;
            lblMsg.Text = string.Format(UIResource.SchedulePlanMsg, _sPlan.StartIndex, _sPlan.EndIndex);
            LoadControlData();
            LoadExpectedSeries();
            LoadPlanSeries();
            LoadActualSeries();
        }

        private void SetMaxMinValueOfXYDiagram()
        {
            XYDiagram diagram = chart.Diagram as XYDiagram;
            if (diagram != null && diagram.AxisY.WholeRange.Auto)
            {
                int x = (_sPlan.EndIndex - _sPlan.StartIndex) / _plan.EndDate.Subtract(_sPlan.StartDate).Days;
                diagram.AxisY.WholeRange.SideMarginsValue = 0;
                diagram.AxisY.WholeRange.SetMinMaxValues(_sPlan.StartIndex - x, _sPlan.EndIndex + x);
            }
        }

        private void LoadControlData()
        {
            txtCurrentIndex.Text = _sPlan.CurrentIndex.ToString();
            var item = _sPlan.TodayItem;
            if (item != null)
            {
                txtTodayIndex.Text = item.CurrentIndex.ToString();
                rtxNode.Text = item.Note;
            }
        }

        private void LoadExpectedSeries()
        {
            ExpectedSeries.Points.BeginUpdate();
            ExpectedSeries.Points.Clear();
            DateTime startDate = _sPlan.StartDate;
            float expectedIndex = _sPlan.StartIndex;
            float increment = (float)_sPlan.Amount / (float)(_sPlan.EndDate.Subtract(_sPlan.StartDate).Days);
            for (; startDate < _sPlan.EndDate; startDate = startDate.AddDays(1))
            {
                expectedIndex += increment;
                ExpectedSeries.Points.Add(new SeriesPoint(startDate, expectedIndex));
            }

            ExpectedSeries.Points.EndUpdate();
        }

        private void LoadPlanSeries()
        {
            PlanSeries.Points.BeginUpdate();
            PlanSeries.Points.Clear();
            DateTime startDate = _sPlan.StartDate;
            int currentIndex = _sPlan.StartIndex;
            for (; currentIndex < _sPlan.EndIndex; startDate = startDate.AddDays(1))
            {
                if (startDate.IsWeekDay())
                    currentIndex += _sPlan.WeekDayWorkload;
                else
                    currentIndex += _sPlan.WeekendWorkload;

                if (currentIndex > _sPlan.EndIndex)
                    currentIndex = _sPlan.EndIndex;
                PlanSeries.Points.Add(new SeriesPoint(startDate, currentIndex));
            }
            PlanSeries.Points.EndUpdate();
        }

        private void LoadActualSeries()
        {
            ActuralSeries.Points.BeginUpdate();
            ActuralSeries.Points.Clear();

            DateTime tempDate = _sPlan.StartDate.Date;
            int previousPoint = _sPlan.StartIndex;
            foreach (ScheduleItem item in _sPlan.Items)
            {
                while (item.ExecuteDate.Date > tempDate)
                {
                    ActuralSeries.Points.Add(new SeriesPoint(tempDate, previousPoint));
                    tempDate = tempDate.AddDays(1);
                }
                ActuralSeries.Points.Add(new SeriesPoint(item.ExecuteDate, item.CurrentIndex));
                previousPoint = item.CurrentIndex;
                tempDate = tempDate.AddDays(1);
            }

            while (tempDate <= DateTime.Now.Date)
            {
                ActuralSeries.Points.Add(new SeriesPoint(tempDate, previousPoint));
                tempDate = tempDate.AddDays(1);
            }
            ActuralSeries.Points.EndUpdate();
        }

        #region override

        public override void Execute()
        {
            if ((_tabbedStatus & UCTabbedStatus.SaveEnable) != UCTabbedStatus.SaveEnable)
            {
                return;
            }
            base.Execute();
            BindData();
            ucTimer.StopRecording();
            _tabbedStatus &= ~UCTabbedStatus.SaveEnable;
            this.Enabled = false;
            Task task = Task.Run(new Action(_transaction.Execute));
            task.ContinueWith(new Action<Task>(OnStatusChanged), _guiTaskScheduler);
        }

        private void OnStatusChanged(Task task)
        {
            _tabbedStatus |= UCTabbedStatus.SaveEnable;
            this.Enabled = true;
            LoadControlData();
            LoadActualSeries();
        }

        #endregion

        private void BindData()
        {
            _transaction.Note = rtxNode.Text;
            if (!string.IsNullOrEmpty(txtTodayIndex.Text))
            {
                _transaction.CurrentIndex = int.Parse(txtTodayIndex.Text);
            }
        }

        private void Number_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Execute();
        }

        private void ucTimer_StatusChanged(object sender, TimeSpan e)
        {
            _transaction.CostTime = e;
        }
    }
}

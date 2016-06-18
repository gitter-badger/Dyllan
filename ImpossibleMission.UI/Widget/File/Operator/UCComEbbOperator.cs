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
using DevExpress.XtraGauges.Base;
using DevExpress.XtraGauges.Core.Primitive;
using DevExpress.XtraGauges.Core.Model;
using DevExpress.XtraGauges.Win.Gauges.Linear;
using DevExpress.XtraCharts;

namespace ImpossibleMission.Widget.File
{
    public partial class UCComEbbOperator : UCDailyItemOperator
    {
        private readonly CommonEbbPlan _tPlan;
        private ComEbbOperatorTransaction _transaction;
        Series ActuralSeries { get { return chart.Series[0]; } }
        Series ExpectedSeries { get { return chart.Series[1]; } }

        public UCComEbbOperator(CommonEbbPlan plan)
            : base(plan)
        {
            InitializeComponent();
            _tPlan = plan;
            _transaction = new ComEbbOperatorTransaction(_tPlan);
            InitialData();
        }

        private IEnumerable<CommonEbbinghausItem> _dataSource;
        private void InitialData()
        {
            _tabbedStatus = UCTabbedStatus.SaveEnable;
            _dataSource = _transaction.GetSource();
            gc.DataSource = _dataSource;
            gv.ExpandAllGroups();
            ucTimer.CostTime = _transaction.CostTime;
            InitialScore();
            LoadSeries();
        }

        private void LoadSeries()
        {
            ExpectedSeries.Points.BeginUpdate();
            ExpectedSeries.Points.Clear();
            ActuralSeries.Points.BeginUpdate();
            ActuralSeries.Points.Clear();

            DateTime tempDate = _tPlan.StartDate.Date;
            double expectedPoint = new TimeSpan(2, 0, 0).TotalHours;
            foreach (CommonEbbinghausItem item in _tPlan.Items)
            {
                if (item.ExecuteDate > DateTime.Now.Date)
                    break;

                while (item.ExecuteDate.Date > tempDate)
                {
                    ExpectedSeries.Points.Add(new SeriesPoint(tempDate, expectedPoint));
                    tempDate = tempDate.AddDays(1);
                }
                if (item.ProcessStatus == ProgressStatusEnum.Completed)
                    ActuralSeries.Points.Add(new SeriesPoint(item.ExecuteDate, item.CostTime.TotalHours));
                else
                    ExpectedSeries.Points.Add(new SeriesPoint(item.ExecuteDate, expectedPoint));

                tempDate = tempDate.AddDays(1);
            }

            ActuralSeries.Points.EndUpdate();
            ExpectedSeries.Points.EndUpdate();
        }

        private void InitialScore()
        {
            ((LinearGauge)gaugeCtr.Gauges[0]).Scales[0].Value = _transaction.Score;
        }

        private void gaugeCtr_MouseDown(object sender, MouseEventArgs e)
        {
            _transaction.Score = (int)SetScore(e.Location);
        }

        private void gaugeCtr_MouseLeave(object sender, EventArgs e)
        {
            InitialScore();
        }

        private void gaugeCtr_MouseMove(object sender, MouseEventArgs e)
        {
            SetScore(e.Location);
        }

        private float SetScore(Point point)
        {
            float result = ((LinearGauge)gaugeCtr.Gauges[0]).Scales[0].Value;
            IGaugeContainer igc = gaugeCtr as IGaugeContainer;
            BasePrimitiveHitInfo hitInfo = igc.CalcHitInfo(point);
            if (hitInfo.Element != null)
            {
                BaseGaugeModel parent = BaseGaugeModel.Find(hitInfo.Element);
                if (parent != null)
                {
                    if (hitInfo.Element.Name == "Indicator4")
                        result = 5;
                    else if (hitInfo.Element.Name == "Indicator3")
                        result = 4;
                    else if (hitInfo.Element.Name == "Indicator2")
                        result = 3;
                    else if (hitInfo.Element.Name == "Indicator1")
                        result = 2;
                    else if (hitInfo.Element.Name == "Indicator0")
                        result = 1;
                }

                ((LinearGauge)gaugeCtr.Gauges[0]).Scales[0].Value = result;
            }
            return result;
        }

        private void ucTimer1_StatusChanged(object sender, TimeSpan e)
        {
            _transaction.CostTime = e;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((_tabbedStatus & UCTabbedStatus.SaveEnable) != UCTabbedStatus.SaveEnable)
            {
                return;
            }
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
            LoadSeries();
        }
    }
}

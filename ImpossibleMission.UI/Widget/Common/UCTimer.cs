using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ImpossibleMission.Widget.Common
{
    public partial class UCTimer : UserControl
    {
        public UCTimer()
        {
            InitializeComponent();
        }
        private TimeSpan _costTime = TimeSpan.Zero;
        public TimeSpan CostTime
        {
            set
            {
                if (!_started)
                {
                    _costTime = value;
                    timeSpanEdt.TimeSpan = value;
                    digitalGauge1.Text = _costTime.ToString(Constant.TimeFormat);
                }
            }
        }

        #region Timer
        private DateTime _startTime = DateTime.Now;
        private bool _started = false;
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!_started)
            {
                _started = true;
                _startTime = DateTime.Now;
                timer1.Start();
                btnStart.ImageIndex = 1;
            }
            else
            {
                StopRecording();
            }
        }

        public void StopRecording()
        {
            if (_started)
            {
                _started = false;
                CostTime = _costTime.Add(DateTime.Now.Subtract(_startTime));
                timer1.Stop();
                btnStart.ImageIndex = 0;
                if (StatusChanged != null)
                {
                    StatusChanged(this, _costTime);
                }
            }
        }

        private int _locker = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Interlocked.CompareExchange(ref _locker, 1, 0) == 0)
            {
                TimeSpan diff = DateTime.Now.Subtract(_startTime);
                digitalGauge1.Text = diff.Add(_costTime).ToString(Constant.TimeFormat);
                Interlocked.Exchange(ref _locker, 0);
            }
        }
        #endregion

        #region HandWriter

        private void timeSpanEdt_EditValueChanged(object sender, EventArgs e)
        {
            if (StatusChanged != null)
            {
                CostTime = timeSpanEdt.TimeSpan;
                StatusChanged(this, timeSpanEdt.TimeSpan);
            }
        }

        #endregion

        public event EventHandler<TimeSpan> StatusChanged;
    }
}

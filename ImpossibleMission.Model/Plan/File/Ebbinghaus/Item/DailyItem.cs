using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Model
{
    public abstract class DailyItem : IRefresh
    {
        protected Guid _planID;
        protected DateTime _executeDate;
        protected string _name;
        protected ProgressStatusEnum _progressStatus = ProgressStatusEnum.NotStarted;
        protected Guid _id;
        protected TimeSpan _costTime;

        public TimeSpan CostTime
        {
            get
            {
                return _costTime;
            }
            set
            {
                _costTime = value;
            }
        }
        public Guid ID
        {
            get
            {
                return _id;
            }
        }

        public DateTime ExecuteDate
        {
            get
            {
                return _executeDate;
            }
        }

        public ProgressStatusEnum ProcessStatus
        {
            get
            {
                return _progressStatus;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _name = value;
                }
            }
        }

        public Guid PlanID
        {
            get
            {
                return _planID;
            }
        }

        public abstract void Refresh();
    }
}

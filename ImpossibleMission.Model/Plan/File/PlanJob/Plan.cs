using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Model
{
    public enum ProgressStatusEnum
    {
        InProgress,
        Completed,
        NotStarted,
        Uncompleted,
    }

    public abstract class Plan : IRefresh
    {
        protected string _name;
        protected ProgressStatusEnum _planStatus = ProgressStatusEnum.NotStarted;
        protected DailyItemCollection _items;
        protected DateTime _startDate;
        protected DateTime _endDate;
        private Guid _id;
        private string _review;
        private string _details;
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

        public Guid ID
        {
            get
            {
                return _id;
            }
        }

        public string Review
        {
            get
            {
                return _review;
            }

            set
            {
                _review = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
        }

        public virtual DateTime EndDate
        {
            get
            {
                return _endDate;
            }
        }

        public string Details
        {
            get
            {
                return _details;
            }

            set
            {
                _details = value;
            }
        }

        public ProgressStatusEnum Status
        {
            get
            {
                return _planStatus;
            }
        }

        public DailyItemCollection Items
        {
            get
            {
                return _items;
            }
            internal set
            {
                _items = value;
            }
        }

        public Plan(DateTime startDate)
        {
            _id = Guid.NewGuid();
            _startDate = startDate;
            _endDate = startDate.AddDays(-1);
            _name = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Refresh();
        }

        internal Plan(Guid id, string name, DateTime startDate, DateTime endDate, string details, string review, ProgressStatusEnum status, DailyItemCollection items)
        {
            _id = id;
            Name = name;
            _startDate = startDate;
            _endDate = endDate;
            Details = details;
            Review = review;
            _items = items;
            _planStatus = status;
        }

        public abstract float CompletedPercent
        {
            get;
        }
        
        public void Refresh()
        {
            _planStatus = GetPlanProgressStatus();
        }

        public abstract void GenerateItem(string name);
        protected abstract ProgressStatusEnum GetPlanProgressStatus();

        public abstract string TypeName
        {
            get;
        }

        public abstract bool DailyUpdated { get; }
    }
}

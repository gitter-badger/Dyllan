using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Model
{
    public abstract class PlanBuilder
    {
        protected Plan _plan = null;
        public virtual Plan Plan
        {
            get
            {
                return _plan;
            }
        }
        public abstract Plan CreatePlan(Guid id, string name, DateTime startDate, DateTime endDate, string details, string review, ProgressStatusEnum status);

        public virtual bool AddDailyItem(DailyItem item)
        {
            bool isSuccess = false;
            if (_plan != null && _plan.Items != null)
            {
                _plan.Items.Add(item);
                isSuccess = true;
            }
            return isSuccess;
        }
    }
}

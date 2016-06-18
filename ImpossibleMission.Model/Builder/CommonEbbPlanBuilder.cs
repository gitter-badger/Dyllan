using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Model
{
    public sealed class CommonEbbPlanBuilder : PlanBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// If there are additionals fields that only belongs to CommonEddPlan, then these fields also should be 
        /// contained in CommonEbbPlanBuilder
        /// </remarks>
        public CommonEbbPlanBuilder()
        {
        }

        public override Plan CreatePlan(Guid id, string name, DateTime startDate, DateTime endDate, string details, string review, ProgressStatusEnum status)
        {
            _plan = new CommonEbbPlan(id, name, startDate, endDate, details, review, status);
            return _plan;
        }

        public override bool AddDailyItem(DailyItem item)
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

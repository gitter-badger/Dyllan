using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpossibleMission.Contract;
using ImpossibleMission.Model;

namespace ImpossibleMission.Dal.Sql
{
    public class PlanManager : IPlanManager
    {
        private PlanDal _planDal;
        private readonly Plan _plan;
        public PlanManager(Plan plan)
        {
            _plan = plan;
            if (plan is CommonEbbPlan)
            {
                _planDal = CommonEbbPlanDal.Instance;
            }
            else if (plan is SchedulePlan)
            {
                _planDal = SchedulePlanDal.Instance;
            }
            else
            {
                // TODO:
            }
        }

        public Plan CreatePlan(Plan mPlan)
        {
            if (mPlan == null)
                return null;

            _planDal.CreatePlan(mPlan);

            return mPlan;
        }

        public void DeletePlan(Guid id)
        {
            _planDal.DeletePlan(id);
        }

        public void UpdatePlan(Plan plan)
        {
            _planDal.UpdatePlan(plan);
        }
    }
}

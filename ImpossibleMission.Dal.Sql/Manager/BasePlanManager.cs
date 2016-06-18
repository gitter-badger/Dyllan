using ImpossibleMission.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpossibleMission.Model;

namespace ImpossibleMission.Dal.Sql
{
    public sealed class BasePlanManager : IBasePlanManager
    {
        private static BasePlanManager _instance = new BasePlanManager();
        public static BasePlanManager Instance
        {
            get
            {
                return _instance;
            }
        }
        private HashSet<PlanDal> _allPlanDals = new HashSet<PlanDal>();

        private BasePlanManager()
        {
            _allPlanDals.Add(CommonEbbPlanDal.Instance);
            _allPlanDals.Add(SchedulePlanDal.Instance);
        }

        public List<Plan> GetAllPlans()
        {
            List<Plan> result = new List<Plan>();
            foreach (PlanDal planDal in _allPlanDals)
            {
                foreach (Plan plan in planDal.GetAllPlans())
                {
                    result.Add(plan);
                }
            }
            return result;
        }

        public List<Plan> GetActivePlans()
        {
            List<Plan> result = new List<Plan>();
            foreach (PlanDal planDal in _allPlanDals)
            {
                foreach (Plan plan in planDal.GetActivePlans())
                {
                    result.Add(plan);
                }
            }
            return result;
        }
    }
}

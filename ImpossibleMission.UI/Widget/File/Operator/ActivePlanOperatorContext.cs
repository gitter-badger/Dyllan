using ImpossibleMission.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Widget.File
{
    public sealed class ActivePlanOperatorContext
    {
        private ActivePlanOperatorContext()
        { }

        private static ActivePlanOperatorContext _instance = new ActivePlanOperatorContext();
        public static ActivePlanOperatorContext Instance
        {
            get
            {
                return _instance;
            }
        }

        private HashSet<UCDailyItemOperator> dailyItemOperators = new HashSet<UCDailyItemOperator>();
        private HashSet<UCCompleteOperator> completeOperators = new HashSet<UCCompleteOperator>();

        public UCDailyItemOperator GetDailyItemOperator(Plan plan)
        {
            if (plan == null)
                return null;

            UCDailyItemOperator result = dailyItemOperators.FirstOrDefault(p => p.Plan == plan);

            if (result == null)
            {
                if (plan.GetType() == typeof(SchedulePlan))
                    result = new UCScedulePlanOperator((SchedulePlan)plan);
                else if (plan.GetType() == typeof(CommonEbbPlan))
                {
                    result = new UCComEbbOperator((CommonEbbPlan)plan);
                }
                else
                {
                    //
                }

                if (result != null)
                    dailyItemOperators.Add(result);
            }

            return result;
        }

        public UCCompleteOperator GetCompleteOperator(Plan plan)
        {
            if (plan == null)
                return null;

            UCCompleteOperator result = completeOperators.FirstOrDefault(p => p.Plan == plan);

            if (result == null)
            {
                result = new UCCompleteOperator(plan);
                completeOperators.Add(result);
            }

            return result;
        }
    }
}

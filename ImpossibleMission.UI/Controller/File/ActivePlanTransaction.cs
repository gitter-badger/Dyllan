using ImpossibleMission.Contract;
using ImpossibleMission.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Controller.File
{
    public class ActivePlanTransaction : Transaction
    {
        private static ActivePlanTransaction _instance = new ActivePlanTransaction();
        public static ActivePlanTransaction Instance
        {
            get
            {
                return _instance;
            }
        }

        private ActivePlanTransaction()
        { }

        public override void Execute()
        {
            try
            {
                IBasePlanManager basePlanManager = ManagerFactory.GetBasePlanManager();
                _activePlans = basePlanManager.GetActivePlans();
                AddMessage("Get active plans successed", MessageType.Information);
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message, MessageType.Error);
            }
        }

        private List<Plan> _activePlans;
        public List<Plan> ActivePlans
        {
            get
            {
                return _activePlans;
            }
        }
    }
}

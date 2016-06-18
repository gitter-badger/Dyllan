using ImpossibleMission.Contract;
using ImpossibleMission.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Controller.File
{
    public sealed class PlanTransaction : Transaction
    {
        private static PlanTransaction _instance = new PlanTransaction();
        public static PlanTransaction Instance
        {
            get
            {
                return _instance;
            }
        }

        private PlanTransaction()
        {
        }

        #region Implement ITransaction
        public override void Execute()
        {
            IBasePlanManager basePlanManager = ManagerFactory.GetBasePlanManager();
            _allPlans = basePlanManager.GetAllPlans();
        }
        #endregion

        private List<Plan> _allPlans;
        public List<Plan> AllPlans
        {
            get
            {
                return _allPlans;
            }
        }

        public void DeletaPlan(Plan plan)
        {
            try
            {
                IPlanManager planManager = ManagerFactory.GetPlanManager(plan);
                planManager.DeletePlan(plan.ID);
                AddMessage("Delete successed!", MessageType.Success);
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message, MessageType.Error);
            }
        }
    }
}

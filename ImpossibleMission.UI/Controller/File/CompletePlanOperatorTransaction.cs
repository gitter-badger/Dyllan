using ImpossibleMission.Contract;
using ImpossibleMission.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Controller.File
{
    public class CompletePlanOperatorTransaction : Transaction
    {
        private Plan _plan;
        public CompletePlanOperatorTransaction(Plan plan)
        {
            _plan = plan;
        }

        #region Implement ITransaction

        public override void Execute()
        {
            try
            {
                IPlanManager planManager = ManagerFactory.GetPlanManager(_plan);
                planManager.UpdatePlan(_plan);
                AddMessage("Update plan successful!", MessageType.Success);
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message, MessageType.Error);
            }
        }

        #endregion

        public string Review
        {
            get
            {
                return _plan.Review;
            }
            set
            {
                _plan.Review = value;
            }
        }
    }
}

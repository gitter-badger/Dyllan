using ImpossibleMission.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpossibleMission.Contract;

namespace ImpossibleMission.Controller.File
{
    public class SchedulePlanOperatorTransaction : Transaction
    {
        public SchedulePlanOperatorTransaction(SchedulePlan plan)
        {
            _plan = plan;
            if (_plan.TodayItem != null)
            {
                _costTime = _plan.TodayItem.CostTime;
            }
        }
        private readonly SchedulePlan _plan;

        #region Implement ITransaction
        public override void Execute()
        {
            try
            {
                _plan.GenerateItem(CurrentIndex, Note, CostTime);
                _plan.Refresh();
                IPlanManager planManager = ManagerFactory.GetPlanManager(_plan);
                planManager.UpdatePlan(_plan);
                AddMessage("Save successed!", MessageType.Success);
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message, MessageType.Error);
            }
        }

        #endregion

        #region Input

        public int CurrentIndex
        {
            get;
            set;
        }

        public string Note
        {
            get;
            set;
        }

        private TimeSpan _costTime = TimeSpan.Zero;
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

        #endregion

    }
}

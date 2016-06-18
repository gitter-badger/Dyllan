using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpossibleMission.Model;
using ImpossibleMission.Contract;

namespace ImpossibleMission.Controller.File
{
    public class ComEbbOperatorTransaction : Transaction
    {
        public ComEbbOperatorTransaction(CommonEbbPlan plan)
        {
            _plan = plan;
            _plan.Refresh();
        }
        private readonly CommonEbbPlan _plan;

        #region Implement ITransaction
        public override void Execute()
        {
            try
            {
                _plan.TodayItem.MarkCompleted();
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

        #region output

        public IEnumerable<CommonEbbinghausItem> GetSource()
        {
            foreach (CommonEbbinghausItem item in _plan.Items)
            {
                yield return item;
            }
        }

        #endregion

        #region Input

        public int Score
        {
            get
            {
                return _plan.TodayItem.Score;
            }
            set
            {
                _plan.TodayItem.Score = value;
            }
        }

        public TimeSpan CostTime
        {
            get
            {
                return _plan.TodayItem.CostTime;
            }
            set
            {
                _plan.TodayItem.CostTime = value;
            }
        }

        #endregion
    }
}

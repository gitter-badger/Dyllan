using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ImpossibleMission.Model;
using System.Data.SqlClient;
using Dyllan.Common.Utility;

namespace ImpossibleMission.Dal.Sql
{
    internal class CommonEbbPlanDal : PlanDal
    {
        protected override string Type
        {
            get
            {
                return Constant.COMMONEBBPLAN;
            }
        }
        private CommonEbbinghausItemDal _commonEbbinghausItemDal = CommonEbbinghausItemDal.Instance;

        private static CommonEbbPlanDal _instance = new CommonEbbPlanDal();
        public static CommonEbbPlanDal Instance
        {
            get
            {
                return _instance;
            }
        }

        #region

        protected override Dictionary<Guid, PlanBuilder> GetPlanBuilder(SqlDataReader reader)
        {
            Dictionary<Guid, PlanBuilder> result = new Dictionary<Guid, PlanBuilder>();
            while (reader.Read())
            {
                int i = 0;
                Guid id = reader.ReadGuid(i++);
                CommonEbbPlanBuilder builder = new CommonEbbPlanBuilder();
                result.Add(id, builder);
            }
            reader.NextResult();
            return result;
        }

        protected override ICollection<DailyItem> ConstructDailyItemCollection(SqlDataReader reader)
        {
            return _commonEbbinghausItemDal.ConstructDailyItems(reader);
        }

        protected override void CreatePlan(SqlConnection connection, SqlTransaction transaction, Plan plan)
        {
            base.CreatePlan(connection, transaction, plan);

            _connectionManager.RetryExecute(
                () =>
                {
                    SqlParameter[] parameters = new SqlParameter[] { new SqlParameter(Constant.ParameterID, plan.ID) };
                    SqlHelper.ExecuteNonQuery(connection, transaction, Constant.ProcCreateCommonEbbPlan, parameters);
                    _commonEbbinghausItemDal.InsertOrUpdateDailyItems(connection, transaction, plan.Items);
                });
        }

        protected override void UpdatePlan(SqlConnection connection, SqlTransaction transaction, Plan plan)
        {
            base.UpdatePlan(connection, transaction, plan);
            ConnectionManager.Instance.RetryExecute(
                () =>
                {
                    _commonEbbinghausItemDal.InsertOrUpdateDailyItems(connection, transaction, plan.Items);
                });
        }
        #endregion

        #region public methods

        #endregion
    }
}

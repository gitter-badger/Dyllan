using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpossibleMission.Model;
using Dyllan.Common.Utility;

namespace ImpossibleMission.Dal.Sql
{
    internal sealed class SchedulePlanDal : PlanDal
    {
        private SchedulePlanDal()
        {
        }

        private static SchedulePlanDal _instance = new SchedulePlanDal();
        public static SchedulePlanDal Instance
        {
            get
            {
                return _instance;
            }
        }

        private ScheduleItemDal _scheduleItemDal = ScheduleItemDal.Instance;

        protected override string Type
        {
            get
            {
                return Constant.SCHEDULEPLAN;
            }
        }

        protected override void CreatePlan(SqlConnection connection, SqlTransaction transaction, Plan plan)
        {
            base.CreatePlan(connection, transaction, plan);

            SchedulePlan tempPlan = plan as SchedulePlan;
            _connectionManager.RetryExecute(
                () =>
                {
                    SqlParameter[] parameters = ConstructParameters(tempPlan);
                    SqlHelper.ExecuteNonQuery(connection, transaction, Constant.ProcCreateSchedulePlan, parameters);
                });
        }

        protected override ICollection<DailyItem> ConstructDailyItemCollection(SqlDataReader reader)
        {
            return _scheduleItemDal.ConstructDailyItems(reader);
        }

        protected override Dictionary<Guid, PlanBuilder> GetPlanBuilder(SqlDataReader reader)
        {
            Dictionary<Guid, PlanBuilder> result = new Dictionary<Guid, PlanBuilder>();
            while (reader.Read())
            {
                int i = 0;
                Guid id = reader.ReadGuid(i ++);
                int startIndex = reader.ReadInteger(i ++);
                int endIndex = reader.ReadInteger(i++);
                int weekDayWorkload = reader.ReadInteger(i++);
                int weekendWorkload = reader.ReadInteger(i++);
                float buffer = reader.ReadFloat(i++);
                SchedulePlanBuilder builder = new SchedulePlanBuilder(startIndex, endIndex, weekDayWorkload, weekendWorkload, buffer);
                result.Add(id, builder);
            }
            reader.NextResult();
            return result;
        }

        protected override void UpdatePlan(SqlConnection connection, SqlTransaction transaction, Plan plan)
        {
            base.UpdatePlan(connection, transaction, plan);

            SchedulePlan tempPlan = plan as SchedulePlan;
            ConnectionManager.Instance.RetryExecute(
                () =>
                {
                    SqlParameter[] parameters = ConstructParameters(tempPlan);
                    SqlHelper.ExecuteNonQuery(connection, transaction, Constant.ProcUpdateSchedulePlan, parameters);

                    _scheduleItemDal.InsertOrUpdateScheduleItem(connection, transaction, tempPlan.TodayItem);
                });
        }

        private SqlParameter[] ConstructParameters(SchedulePlan plan)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter(Constant.ParameterID, plan.ID),
                        new SqlParameter(Constant.ParameterStartIndex, plan.StartIndex),
                        new SqlParameter(Constant.ParameterEndIndex, plan.EndIndex),
                        new SqlParameter(Constant.ParameterWeekDayWorkload, plan.WeekDayWorkload),
                        new SqlParameter(Constant.ParameterWeekendWorkload, plan.WeekendWorkload),
                        new SqlParameter(Constant.ParameterBuffer, plan.Buffer)};
            return parameters;
        }
    }
}

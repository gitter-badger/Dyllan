using Dyllan.Common.Utility;
using ImpossibleMission.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ImpossibleMission.Dal.Sql
{
    internal class ScheduleItemDal : DailyItemDal
    {
        private static ScheduleItemDal _instace = new ScheduleItemDal();
        private ScheduleItemDal() { }
        public static ScheduleItemDal Instance
        {
            get
            {
                return _instace;
            }
        }

        protected override string Type
        {
            get
            {
                return Constant.SCHEDULEITEM;
            }
        }

        protected override Dictionary<Guid, DailyItemBuilder> GetDailyItemBuilders(SqlDataReader reader)
        {
            Dictionary<Guid, DailyItemBuilder> result = new Dictionary<Guid, DailyItemBuilder>();
            while (reader.Read())
            {
                int i = 0;
                Guid id = reader.ReadGuid(i++);
                Guid planId = reader.ReadGuid(i ++);
                int currentIndex = reader.ReadInteger(i ++);
                string note = reader.ReadString(i ++);
                ScheduleItemBuilder builder = new ScheduleItemBuilder(currentIndex, note);
                result.Add(id, builder);
            }
            reader.NextResult();
            return result;
        }

        public void InsertOrUpdateScheduleItem(SqlConnection connection, SqlTransaction transaction, ScheduleItem item)
        {
            if (item == null)
                return;

            _connectionManager.RetryExecute(
                () =>
                {
                    SqlParameter[] parameters = new SqlParameter[] { new SqlParameter(Constant.ParameterID, item.ID),
                        new SqlParameter(Constant.ParameterPlanID, item.PlanID),
                        new SqlParameter(Constant.ParameterName, item.Name),
                        new SqlParameter(Constant.ParameterType, Type),
                        new SqlParameter(Constant.ParameterExecuteDate, item.ExecuteDate),
                        new SqlParameter(Constant.ParameterProgressStatus, item.ProcessStatus.ToString()),
                        new SqlParameter(Constant.ParameterCurrentIndex, item.CurrentIndex),
                        new SqlParameter(Constant.ParameterNote, item.Note),
                        new SqlParameter(Constant.ParameterCostTime, item.CostTime) { SqlDbType = SqlDbType.Time} };
                    SqlHelper.ExecuteNonQuery(connection, transaction, Constant.ProcCreateOrUpdateScheduleItem, parameters);
                });
        }
    }
}

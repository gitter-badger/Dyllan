using ImpossibleMission.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dyllan.Common.Utility;
using System.Collections.ObjectModel;
using System.Data;

namespace ImpossibleMission.Dal.Sql
{
    internal abstract class DailyItemDal
    {
        protected ConnectionManager _connectionManager = ConnectionManager.Instance;
        protected abstract string Type
        {
            get;
        }

        public virtual void InsertOrUpdateDailyItems(SqlConnection connection, SqlTransaction transaction, DailyItemCollection dailyItems)
        {
            _connectionManager.RetryExecute(() =>
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = ConstructParameter(dailyItems);
                SqlHelper.ExecuteNonQuery(connection, transaction, Constant.ProcCreateOrUpdateDailyItems, parameters);
            });
        }

        private SqlParameter ConstructParameter(IEnumerable<DailyItem> dailyItems)
        {
            DataTable dt = new DataTable(Constant.SqlTypeDailyItemType);
            dt.Columns.Add(new DataColumn(Constant.SqlColumnNameID, typeof(Guid)));
            dt.Columns.Add(new DataColumn(Constant.SqlColumnNamePlanID, typeof(Guid)));
            dt.Columns.Add(new DataColumn(Constant.SqlColumnNameExecuteDate, typeof(DateTime)));
            dt.Columns.Add(new DataColumn(Constant.SqlColumnNameName, typeof(string)));
            dt.Columns.Add(new DataColumn(Constant.SqlColumnNameType, typeof(string)));
            dt.Columns.Add(new DataColumn(Constant.SqlColumnNameProgressStatus, typeof(string)));
            dt.Columns.Add(new DataColumn(Constant.SqlColumnNameCostTime, typeof(TimeSpan)));
            foreach (DailyItem item in dailyItems)
            {
                DataRow row = dt.NewRow();
                row[Constant.SqlColumnNameID] = item.ID;
                row[Constant.SqlColumnNamePlanID] = item.PlanID;
                row[Constant.SqlColumnNameExecuteDate] = item.ExecuteDate;
                row[Constant.SqlColumnNameName] = item.Name;
                row[Constant.SqlColumnNameType]= Type;
                row[Constant.SqlColumnNameProgressStatus] = item.ProcessStatus.ToString();
                row[Constant.SqlColumnNameCostTime] = item.CostTime;
                dt.Rows.Add(row);
            }

            dt.AcceptChanges();
            SqlParameter parameter = new SqlParameter(Constant.ParameterDailyItems, dt);
            parameter.SqlDbType = SqlDbType.Structured;
            parameter.TypeName = Constant.SqlTypeDailyItemType;
            return parameter;
        }

        public virtual ICollection<DailyItem> ConstructDailyItems(SqlDataReader reader)
        {
            ICollection<DailyItem> items = new Collection<DailyItem>();
            Dictionary<Guid, DailyItemBuilder> itemBuilders = GetDailyItemBuilders(reader);
            while (reader.Read())
            {
                items.Add(ConstructDailyItem(reader, itemBuilders));
            }
            return items;
        }

        protected abstract Dictionary<Guid, DailyItemBuilder> GetDailyItemBuilders(SqlDataReader reader);

        private DailyItem ConstructDailyItem(SqlDataReader reader, Dictionary<Guid, DailyItemBuilder> builders)
        {
            int i = 0;
            Guid id = reader.ReadGuid(i++);
            Guid planId = reader.ReadGuid(i++);
            DateTime executeTime = reader.ReadDate(i++);
            string name = reader.ReadString(i++);
            ProgressStatusEnum progressStatus = reader.ReadEnum(i++, ProgressStatusEnum.Uncompleted);
            TimeSpan costTime = reader.ReadTimeSpan(i++);
            if (builders.ContainsKey(id))
            {
                return builders[id].CreateDailyItem(id, executeTime, name, planId, progressStatus, costTime);
            }
            return null;
        }
    }
}

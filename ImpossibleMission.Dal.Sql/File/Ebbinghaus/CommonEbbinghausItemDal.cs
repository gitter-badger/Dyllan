using Dyllan.Common.Utility;
using ImpossibleMission.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Dal.Sql
{
    internal sealed class CommonEbbinghausItemDal : DailyItemDal
    {
        private static CommonEbbinghausItemDal _instace = new CommonEbbinghausItemDal();
        private CommonEbbinghausItemDal() { }
        public static CommonEbbinghausItemDal Instance
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
                return Constant.COMMONEBBINGHAUSITEM;
            }
        }

        public override void InsertOrUpdateDailyItems(SqlConnection connection, SqlTransaction transaction, DailyItemCollection ebbinghausItems)
        {
            base.InsertOrUpdateDailyItems(connection, transaction, ebbinghausItems);

            ConnectionManager.Instance.RetryExecute(() =>
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = ConstructParameter(ebbinghausItems);
                SqlHelper.ExecuteNonQuery(connection, transaction, Constant.ProcCreateOrUpdateCommonEbbinghausItems, parameters);
            });
        }

        protected override Dictionary<Guid, DailyItemBuilder> GetDailyItemBuilders(SqlDataReader reader)
        {
            Dictionary<Guid, DailyItemBuilder> result = new Dictionary<Guid, DailyItemBuilder>();
            while (reader.Read())
            {
                int i = 0;
                Guid id = reader.ReadGuid(i++);
                Guid planId = reader.ReadGuid(i++);
                int score = reader.ReadInteger(i++);
                CommonEbbItemBuilder builder = new CommonEbbItemBuilder(score);
                result.Add(id, builder);
            }
            reader.NextResult();
            return result;
        }

        private SqlParameter ConstructParameter(IEnumerable<DailyItem> dailyItems)
        {
            DataTable dt = new DataTable(Constant.SqlTypeCommonEbbinghausItemType);
            dt.Columns.Add(new DataColumn(Constant.SqlColumnNameID, typeof(Guid)));
            dt.Columns.Add(new DataColumn(Constant.SqlColumnNameCommonEbbPlanID, typeof(Guid)));
            dt.Columns.Add(new DataColumn(Constant.SqlColumnNameScore, typeof(int)));
            foreach (CommonEbbinghausItem item in dailyItems)
            {
                DataRow row = dt.NewRow();
                row[Constant.SqlColumnNameID] = item.ID;
                row[Constant.SqlColumnNameCommonEbbPlanID] = item.PlanID;
                row[Constant.SqlColumnNameScore] = item.Score;
                dt.Rows.Add(row);
            }

            dt.AcceptChanges();
            SqlParameter parameter = new SqlParameter(Constant.ParameterCommonEbbinghausItems, dt);
            parameter.SqlDbType = SqlDbType.Structured;
            parameter.TypeName = Constant.SqlTypeCommonEbbinghausItemType;
            return parameter;
        }
    }
}

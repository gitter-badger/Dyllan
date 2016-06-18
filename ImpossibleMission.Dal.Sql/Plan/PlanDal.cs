using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using ImpossibleMission.Model;
using System.Data.SqlClient;
using Dyllan.Common.Utility;

namespace ImpossibleMission.Dal.Sql
{
    internal abstract class PlanDal
    {
        protected ConnectionManager _connectionManager = ConnectionManager.Instance;
        protected abstract string Type
        {
            get;
        }

        protected virtual void CreatePlan(SqlConnection connection,SqlTransaction transaction, Plan plan)
        {
            ConnectionManager.Instance.RetryExecute(
                () =>
                {
                    SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter(Constant.ParameterID, plan.ID),
                        new SqlParameter(Constant.ParameterName, plan.Name),
                        new SqlParameter(Constant.ParameterType, Type),
                        new SqlParameter(Constant.ParameterStartDate, plan.StartDate),
                        new SqlParameter(Constant.ParameterEndDate, plan.EndDate),
                        new SqlParameter(Constant.ParameterStatus, plan.Status.ToString()),
                        new SqlParameter(Constant.ParameterDetails, (object)plan.Details ?? DBNull.Value),
                        new SqlParameter(Constant.ParameterReview, (object)plan.Review ?? DBNull.Value) };
                    SqlHelper.ExecuteNonQuery(connection, transaction, Constant.ProcCreatePlan, parameters);
                });
        }

        protected virtual List<Plan> GetActivePlans(SqlConnection connection)
        {
            List<Plan> result = new List<Plan>();
            ConnectionManager.Instance.RetryExecute(
                () =>
                {
                    SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter(Constant.ParameterType, Type)};
                    using (SqlDataReader reader = SqlHelper.ReadData(connection, Constant.ProcGetActivePlans, parameters))
                    {
                        var planBuilders = ConstructPlan(reader);
                        if (reader.NextResult())
                        {
                            var items = ConstructDailyItemCollection(reader);
                            foreach (var item in items)
                            {
                                if (planBuilders.ContainsKey(item.PlanID))
                                {
                                    planBuilders[item.PlanID].AddDailyItem(item);
                                }
                            }
                        }

                        foreach (var builder in planBuilders.Values)
                        {
                            if (builder.Plan != null)
                                result.Add(builder.Plan);
                        }
                    }
                });
            return result;
        }

        protected virtual void DeletePlan(SqlConnection connection, SqlTransaction transaction, Guid id)
        {
            ConnectionManager.Instance.RetryExecute(
                () =>
                {
                    SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter(Constant.ParameterID, id) };
                    SqlHelper.ExecuteNonQuery(connection, transaction, Constant.ProcDeletePlan, parameters);
                });
        }

        protected virtual List<Plan> GetAllPlans(SqlConnection connection)
        {
            List<Plan> result = new List<Plan>();
            ConnectionManager.Instance.RetryExecute(
                () =>
                {
                    SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter(Constant.ParameterType, Type)};
                    using (SqlDataReader reader = SqlHelper.ReadData(connection, Constant.ProcGetAllPlans, parameters))
                    {
                        var planBuilders = ConstructPlan(reader);

                        foreach (var builder in planBuilders.Values)
                        {
                            if (builder.Plan != null)
                                result.Add(builder.Plan);
                        }
                    }
                });
            return result;
        }

        private Dictionary<Guid, PlanBuilder> ConstructPlan(SqlDataReader reader)
        {
            Dictionary<Guid, PlanBuilder> result = GetPlanBuilder(reader);
            while (reader.Read())
            {
                int i = 0;
                Guid id = reader.ReadGuid(i++);
                string name = reader.ReadString(i++);
                DateTime startDate = reader.ReadDate(i++);
                DateTime endDate = reader.ReadDate(i++);
                ProgressStatusEnum status = reader.ReadEnum<ProgressStatusEnum>(i ++, ProgressStatusEnum.NotStarted);
                string details = reader.ReadString(i++);
                string review = reader.ReadString(i++);
                if (result.ContainsKey(id))
                {
                    result[id].CreatePlan(id, name, startDate, endDate, details, review, status);
                }
            }
            return result;
        }

        protected abstract ICollection<DailyItem> ConstructDailyItemCollection(SqlDataReader reader);

        protected abstract Dictionary<Guid, PlanBuilder> GetPlanBuilder(SqlDataReader reader);

        protected virtual void UpdatePlan(SqlConnection connection, SqlTransaction transaction, Plan plan)
        {
            ConnectionManager.Instance.RetryExecute(
                () =>
                {
                    SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter(Constant.ParameterID, plan.ID),
                        new SqlParameter(Constant.ParameterName, plan.Name),
                        new SqlParameter(Constant.ParameterType, Type),
                        new SqlParameter(Constant.ParameterStartDate, plan.StartDate),
                        new SqlParameter(Constant.ParameterEndDate, plan.EndDate),
                        new SqlParameter(Constant.ParameterStatus, plan.Status.ToString()),
                        new SqlParameter(Constant.ParameterDetails, (object)plan.Details ?? DBNull.Value),
                        new SqlParameter(Constant.ParameterReview, (object)plan.Review ?? DBNull.Value) };
                    SqlHelper.ExecuteNonQuery(connection, transaction, Constant.ProcUpdatePlan, parameters);
                });
        }

        public virtual void CreatePlan(Plan plan)
        {
            try
            {
                var connection = _connectionManager.OpenConnection();
                var transaction = _connectionManager.BeginTransaction();
                CreatePlan(connection, transaction, plan);
                transaction.Commit();
            }
            finally
            {
                _connectionManager.CloseConnection();
            }
        }

        public virtual void DeletePlan(Guid id)
        {
            try
            {
                var connection = _connectionManager.OpenConnection();
                var transaction = _connectionManager.BeginTransaction();
                DeletePlan(connection, transaction, id);
                transaction.Commit();
            }
            finally
            {
                _connectionManager.CloseConnection();
            }
        }

        public virtual List<Plan> GetAllPlans()
        {
            List<Plan> result = null;
            try
            {
                var connection = _connectionManager.OpenConnection();
                result = GetAllPlans(connection);
            }
            finally
            {
                _connectionManager.CloseConnection();
            }
            return result;
        }

        public virtual List<Plan> GetActivePlans()
        {
            List<Plan> result = null;
            try
            {
                var connection = _connectionManager.OpenConnection();
                result = GetActivePlans(connection);
            }
            finally
            {
                _connectionManager.CloseConnection();
            }
            return result;
        }

        public virtual void UpdatePlan(Plan plan)
        {
            try
            {
                var connection = _connectionManager.OpenConnection();
                var transaction = _connectionManager.BeginTransaction();
                UpdatePlan(connection, transaction, plan);
                transaction.Commit();
            }
            finally
            {
                _connectionManager.CloseConnection();
            }
        }
    }
}

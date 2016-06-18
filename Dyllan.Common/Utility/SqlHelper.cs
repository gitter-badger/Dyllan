using System.Data;
using System.Data.SqlClient;

namespace Dyllan.Common.Utility
{
    public static class SqlHelper
    {
        #region Public Methods

        /// <summary>
        /// Read Data from SQL Server database.
        /// </summary>
        /// <param name="connection">Represents an open connection to a SQL Server database</param>
        /// <param name="commandType">Specifies how a command string is interpreted</param>
        /// <param name="commandText">the Transact-SQL statement, table name or 
        /// stored procedure to execute at the data source.</param>
        /// <param name="parameters">Represents a parameter to a System.Data.SqlClient.SqlCommand 
        /// and optionally its mapping to System.Data.DataSet columns</param>
        /// <returns>Return data that readed</returns>
        public static SqlDataReader ReadData(SqlConnection connection, CommandType commandType,
            string commandText, params SqlParameter[] parameters)
        {
            ParameterChecker.CheckParameter(connection, "connection");

            SqlCommand sCommand = ConstructCommand(connection, commandType, commandText, parameters);
            return sCommand.ExecuteReader();
        }

        public static SqlDataReader ReadData(SqlConnection connection, string sqlProcedureName, params SqlParameter[] parameters)
        {
            ParameterChecker.CheckParameter(connection, "connection");
            ParameterChecker.CheckParameter(sqlProcedureName, "sqlProcedureName");
            ParameterChecker.CheckCollection<SqlParameter>(parameters, "parameters");

            SqlDataReader dataReader = null;
            using (SqlCommand command = new SqlCommand(sqlProcedureName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
                dataReader = command.ExecuteReader();
            }

            return dataReader;
        }

        public static SqlDataReader ReadData(SqlConnection connection, string sqlProcedureName)
        {
            ParameterChecker.CheckParameter(connection, "connection");

            SqlCommand command = new SqlCommand(sqlProcedureName, connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlDataReader dataReader = command.ExecuteReader();

            return dataReader;
        }

        /// <summary>
        ///  Executes a Transact-SQL statement against the connection and returns 
        ///  the number of rows affected.
        /// </summary>
        /// <param name="connection">Represents an open connection to a SQL Server database</param>
        /// <param name="commandType">Specifies how a command string is interpreted</param>
        /// <param name="commandText">the Transact-SQL statement, table name or 
        /// stored procedure to execute at the data source.</param>
        /// <param name="parameters">Represents a parameter to a System.Data.SqlClient.SqlCommand 
        /// and optionally its mapping to System.Data.DataSet columns</param>
        /// <returns>The number of rows affected.</returns>
        public static int ExecuteNonQuery(SqlConnection connection, CommandType commandType,
            string commandText, params SqlParameter[] parameters)
        {
            ParameterChecker.CheckParameter(connection, "connection");

            SqlCommand sCommand = ConstructCommand(connection, commandType, commandText, parameters);
            return sCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Constuct a SqlCommand.
        /// </summary>
        /// <param name="connection">Represents an open connection to a 
        /// SQL Server database.</param>
        /// <param name="commandType">Specifies how a command string is interpreted</param>
        /// <param name="commandText">the Transact-SQL statement, table name or 
        /// stored procedure to execute at the data source.</param>
        /// <param name="parameters">Represents a parameter to a System.Data.SqlClient.SqlCommand 
        /// and optionally its mapping to System.Data.DataSet columns.</param>
        /// <returns>A SqlCommand object constructed.</returns>
        private static SqlCommand ConstructCommand(SqlConnection connection, CommandType commandType,
            string commandText, params SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = commandType;
            command.CommandText = commandText;
            command.Connection = connection;

            if (null != parameters)
            {
                command.Parameters.AddRange(parameters);
            }
            return command;
        }

        public static void ExecuteNonQuery(SqlConnection connection, SqlTransaction transaction, string sqlProcedureName, params SqlParameter[] parameters)
        {
            ParameterChecker.CheckParameter(connection, "connection");
            ParameterChecker.CheckParameter(transaction, "transaction");
            ParameterChecker.CheckParameter(sqlProcedureName, "sqlProcedureName");
            ParameterChecker.CheckCollection<SqlParameter>(parameters, "parameters");

            using (SqlCommand command = new SqlCommand(sqlProcedureName, connection, transaction))
            {
                command.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                command.ExecuteNonQuery();
            }
        }

        public static void ExecuteNonQuery(SqlConnection connection, SqlTransaction transaction, string sqlProcedureName)
        {
            ParameterChecker.CheckParameter(connection, "connection");
            ParameterChecker.CheckParameter(transaction, "transaction");
            ParameterChecker.CheckParameter(sqlProcedureName, "sqlProcedureName");

            using (SqlCommand command = new SqlCommand(sqlProcedureName, connection, transaction))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.ExecuteNonQuery();
            }
        }

        public static void ExecuteNonQuery(SqlConnection connection, string sqlProcedureName, params SqlParameter[] parameters)
        {
            ParameterChecker.CheckParameter(connection, "connection");
            ParameterChecker.CheckParameter(sqlProcedureName, "sqlProcedureName");
            ParameterChecker.CheckCollection<SqlParameter>(parameters, "parameters");

            using (SqlCommand command = new SqlCommand(sqlProcedureName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                command.ExecuteNonQuery();
            }
        }

        public static void ExecuteNonQuery(SqlConnection connection, string sqlProcedureName)
        {
            ParameterChecker.CheckParameter(connection, "connection");
            ParameterChecker.CheckParameter(sqlProcedureName, "sqlProcedureName");

            using (SqlCommand command = new SqlCommand(sqlProcedureName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.ExecuteNonQuery();
            }
        }

        #endregion Public Methods
    }
}

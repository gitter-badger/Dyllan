using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

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

        #region Attribute Support
        private static T GetSpecifiedObject<T>(object[] objects)
        {
            if (objects != null && objects.Length == 1 && objects[0] is T)
                return (T)objects[0];
            return default(T);
        }

        public static SqlParameter ConstructParameter<T>(IEnumerable<T> records, string variableName)
        {
            if (records == null || string.IsNullOrEmpty(variableName))
                return null;
            SqlParameter parameter = null;
            Type objectType = typeof(T);
            TableTypeAttribute tableTypeAttribute = GetSpecifiedObject<TableTypeAttribute>(objectType.GetCustomAttributes(typeof(TableTypeAttribute), false));

            if (tableTypeAttribute != null)
            {
                DataTable dt = new DataTable(tableTypeAttribute.TableName);
                Dictionary<string, PropertyInfo> colNamePropertyMapping = new Dictionary<string, PropertyInfo>();
                Dictionary<string, string> colNameMethodMapping = new Dictionary<string, string>();
                PropertyInfo[] propertyInfos = objectType.GetProperties();

                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    ColumnAttribute columnAttribute = GetSpecifiedObject<ColumnAttribute>(propertyInfo.GetCustomAttributes(typeof(ColumnAttribute), false));
                    if (columnAttribute != null)
                    {
                        dt.Columns.Add(new DataColumn(columnAttribute.ColumnName, columnAttribute.CustomType ?? propertyInfo.PropertyType));
                        colNamePropertyMapping.Add(columnAttribute.ColumnName, propertyInfo);
                        if (!string.IsNullOrEmpty(columnAttribute.FormatMethodName))
                        {
                            colNameMethodMapping.Add(columnAttribute.ColumnName, columnAttribute.FormatMethodName);
                        }
                    }
                }

                foreach (T record in records)
                {
                    DataRow row = dt.NewRow();
                    foreach (var colNameProperty in colNamePropertyMapping)
                    {
                        if (colNameMethodMapping.ContainsKey(colNameProperty.Key))
                        {
                            object target = colNameProperty.Value.GetValue(record);
                            row[colNameProperty.Key] = target.GetType().GetMethod(colNameMethodMapping[colNameProperty.Key], Type.EmptyTypes).Invoke(target, null);
                        }
                        else
                        {
                            row[colNameProperty.Key] = colNameProperty.Value.GetValue(record);
                        }
                    }
                    dt.Rows.Add(row);
                }
                dt.AcceptChanges();
                parameter = new SqlParameter(variableName, dt);
                parameter.SqlDbType = SqlDbType.Structured;
                parameter.TypeName = tableTypeAttribute.TableName;
            }

            return parameter;
        }
        #endregion
    }
}

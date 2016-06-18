using Dyllan.Common;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Douban.Dal
{
    public sealed class ConnectionManager
    {
        private Logger _log = LogManager.GetCurrentClassLogger();
        private Semaphore _connectionLimit;
        private string _connectionString;
        [ThreadStatic]
        private static SqlConnection _connection;
        [ThreadStatic]
        private static SqlTransaction _transaction;
        private ConnectionManager()
        {
            int limit = AppSettingHelper.GetInteger(Constant.Appsetting_MaxConnectionCount, Constant.Appsetting_MaxConnectionCount_Default);
            _connectionString = AppSettingHelper.GetConnectionString(Constant.Connection_Name, Constant.Connection_String_Default);
            _connectionLimit = new Semaphore(limit, limit);
        }

        public SqlConnection OpenConnection()
        {
            _connectionLimit.WaitOne();

            if (_connection == null)
                _connection = new SqlConnection(_connectionString);
            if (_connection.State != ConnectionState.Open)
                _connection.Open();
            return _connection;
        }

        public SqlTransaction BeginTransaction()
        {
            _transaction = _connection.BeginTransaction();
            return _transaction;
        }

        public void CloseConnection()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }
            if (_connection != null)
            {
                _connectionLimit.Release();
                if (_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                    _connection.Dispose();
                }
            }
            _transaction = null;
            _connection = null;
        }

        private static ConnectionManager instance = new ConnectionManager();
        public static ConnectionManager Instance
        {
            get
            {
                return instance;
            }
        }

        public void RetryExecute(Action action)
        {
            int retryTime = AppSettingHelper.GetInteger(Constant.Appsetting_RetryTime, Constant.Appsetting_RetryTime_Default);
            try
            {
                do
                {
                    try
                    {
                        action();
                        break;
                    }
                    catch (SqlException sqlEx)
                    {
                        if (retryTime <= 0)
                        {
                            _log.Error(sqlEx.Message, sqlEx);
                            throw;
                        }
                        else
                            _log.Warn(string.Format("Retring Time Remains: {0}", retryTime));

                    }
                }
                while ((retryTime--) > 0);
            }
            finally
            {
            }
        }
    }
}

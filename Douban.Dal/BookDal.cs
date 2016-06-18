using Douban.Model;
using Dyllan.Common.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Douban.Dal
{
    internal class BookDal
    {
        private BookDal() { }
        private static BookDal _instance = new BookDal();
        public static BookDal Instance
        {
            get
            {
                return _instance;
            }
        }

        #region Privite Methods

        private ConnectionManager _connectionManager = ConnectionManager.Instance;
        private void InsertOrUpdateBooks(SqlConnection connection, SqlTransaction transaction, IEnumerable<BookInfo> books)
        {
            _connectionManager.RetryExecute(
                () =>
                {
                    SqlParameter[] parameters = new SqlParameter[1];
                    parameters[0] = SqlHelper.ConstructParameter(books, "@BookInfos");
                    SqlHelper.ExecuteNonQuery(connection, transaction, Constant.ProcInsertOrUpdateBookInfos, parameters);
                });
        }

        private int GetMaxDownloadedNumer(SqlConnection connection)
        {
            int result = -1;
            _connectionManager.RetryExecute(
                () =>
                {
                    using (var dataReader = SqlHelper.ReadData(connection, Constant.ProcGetMaxDownloadedNumer))
                    {
                        if (dataReader.Read())
                            result = dataReader.ReadInteger(0);
                    }
                });
            return result;
        }

        #endregion

        public void InsertOrUpdateBooks(IEnumerable<BookInfo> books)
        {
            try
            {
                var connection = _connectionManager.OpenConnection();
                var transaction = _connectionManager.BeginTransaction();
                InsertOrUpdateBooks(connection, transaction, books);
                transaction.Commit();
            }
            finally
            {
                _connectionManager.CloseConnection();
            }
        }

        public int GetMaxDownloadedNumer()
        {
            int result = -1;
            try
            {
                var connection = _connectionManager.OpenConnection();
                result = GetMaxDownloadedNumer(connection);
            }
            finally
            {
                _connectionManager.CloseConnection();
            }
            return result;
        }
    }
}

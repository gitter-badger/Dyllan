using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpossibleMission.Model;
using System.Data.SqlClient;
using System.Data;
using Dyllan.Common.Utility;

namespace ImpossibleMission.Dal.Sql
{
    internal sealed class BookDal
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

        private void InsertBooks(SqlConnection connection, SqlTransaction transaction, IEnumerable<Book> books)
        {
            _connectionManager.RetryExecute(
                () =>
                {
                    SqlParameter[] parameters = new SqlParameter[1];
                    parameters[0] = ConstructParameter(books);
                    SqlHelper.ExecuteNonQuery(connection, transaction, Constant.ProcCreateOrUpdateBooks, parameters);
                });
        }

        private SqlParameter ConstructParameter(IEnumerable<Book> books)
        {
            DataTable dt = new DataTable(Constant.SqlTypeBookType);
            dt.Columns.Add(new DataColumn(Constant.SqlColumnNameWebUrl, typeof(string)));
            dt.Columns.Add(new DataColumn(Constant.SqlColumnNameHttpStatus, typeof(string)));
            dt.Columns.Add(new DataColumn(Constant.SqlColumnNameName, typeof(string)));
            dt.Columns.Add(new DataColumn(Constant.SqlColumnNamePublisher, typeof(string)));
            dt.Columns.Add(new DataColumn(Constant.SqlColumnNameAuthor, typeof(string)));
            dt.Columns.Add(new DataColumn(Constant.SqlColumnNameISBN, typeof(string)));
            dt.Columns.Add(new DataColumn(Constant.SqlColumnNamePublishTime, typeof(string)));
            dt.Columns.Add(new DataColumn(Constant.SqlColumnNamePage, typeof(string)));
            dt.Columns.Add(new DataColumn(Constant.SqlColumnNameLaguage, typeof(string)));
            dt.Columns.Add(new DataColumn(Constant.SqlColumnNameFileSize, typeof(string)));
            dt.Columns.Add(new DataColumn(Constant.SqlColumnNameFileFormat, typeof(string)));
            dt.Columns.Add(new DataColumn(Constant.SqlColumnNameDownloadUrl, typeof(string)));
            dt.Columns.Add(new DataColumn(Constant.SqlColumnNameTag, typeof(string)));
            dt.Columns.Add(new DataColumn(Constant.SqlColumnNameDescription, typeof(string)));
            dt.Columns.Add(new DataColumn(Constant.SqlColumnNameDownloaded, typeof(bool)));
            foreach (Book book in books)
            {
                DataRow row = dt.NewRow();
                row[Constant.SqlColumnNameWebUrl] = book.WebUrl;
                row[Constant.SqlColumnNameHttpStatus] = book.HttpStatus;
                row[Constant.SqlColumnNameName] = book.Name;
                row[Constant.SqlColumnNamePublisher] = book.Publisher;
                row[Constant.SqlColumnNameAuthor] = book.Author;
                row[Constant.SqlColumnNameISBN] = book.ISBN;
                row[Constant.SqlColumnNamePublishTime] = book.PublishTime;
                row[Constant.SqlColumnNamePage] = book.Page;
                row[Constant.SqlColumnNameLaguage] = book.Laguage;
                row[Constant.SqlColumnNameFileSize] = book.FileSize;
                row[Constant.SqlColumnNameFileFormat] = book.FileFormat;
                row[Constant.SqlColumnNameDownloadUrl] = book.DownloadUrl;
                row[Constant.SqlColumnNameTag] = book.Tag;
                row[Constant.SqlColumnNameDescription] = book.Description;
                row[Constant.SqlColumnNameDownloaded] = book.Downloaded;
                dt.Rows.Add(row);
            }

            dt.AcceptChanges();
            SqlParameter parameter = new SqlParameter(Constant.ParameterBooks, dt);
            parameter.SqlDbType = SqlDbType.Structured;
            parameter.TypeName = Constant.SqlTypeBookType;
            return parameter;
        }

        private int GetLastValidNumber(SqlConnection connection)
        {
            int result = 1;
            _connectionManager.RetryExecute(
                () =>
                {
                    using (var reader = SqlHelper.ReadData(connection, Constant.ProcGetLastValidUrlNumberForBooks))
                    {
                        if (reader.Read())
                            result = reader.ReadInteger(0);
                    }
                });

            return result;
        }

        private List<int> GetMissedUrlNumbers(SqlConnection connection, bool includeNonFound)
        {
            List<int> result = new List<int>();
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter(Constant.ParameterIncludeNotFound, includeNonFound),
            };
            _connectionManager.RetryExecute(
                () =>
                {
                    using (var reader = SqlHelper.ReadData(connection, Constant.ProcGetMissedUrlNumbers, parameters))
                    {
                        while (reader.Read())
                        {
                            result.Add(reader.ReadInteger(0));
                        }
                    }
                });

            return result;
        }

        private List<BasicBook> GetBasicBooksWithoutDownloadUrl(SqlConnection connection, int startNum, int endNum)
        {
            List<BasicBook> result = new List<BasicBook>();
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter(Constant.ParameterStartNumber, startNum),
                new SqlParameter(Constant.ParameterEndNumber, endNum),
            };
            _connectionManager.RetryExecute(
                () =>
                {
                    using (var reader = SqlHelper.ReadData(connection, Constant.ProcGetBasicBooksInfo, parameters))
                    {
                        while (reader.Read())
                        {
                            int i = 0;
                            string webUrl = reader.ReadString(i ++);
                            string downloadUrl = reader.ReadString(i++);
                            string name = reader.ReadString(i++);
                            result.Add(new BasicBook() { WebUrl = webUrl, DownloadUrl = downloadUrl, Name = name });
                        }
                    }
                });

            return result;
        }

        private void UpdateBasicBooksInfo(SqlConnection connection, SqlTransaction transaction, IEnumerable<BasicBook> books)
        {
            _connectionManager.RetryExecute(
                   () =>
                   {
                       SqlParameter[] parameters = new SqlParameter[1];
                       parameters[0] = ConstructParameter(books);
                       SqlHelper.ExecuteNonQuery(connection, transaction, Constant.ProcUpdateBooksBasicInfo, parameters);
                   });
        }

        private SqlParameter ConstructParameter(IEnumerable<BasicBook> books)
        {
            DataTable dt = new DataTable(Constant.SqlTypeBasicBookType);
            dt.Columns.Add(new DataColumn(Constant.SqlColumnNameWebUrl, typeof(string)));
            dt.Columns.Add(new DataColumn(Constant.SqlColumnNameDownloadUrl, typeof(string)));
            dt.Columns.Add(new DataColumn(Constant.SqlColumnNameName, typeof(string)));
            dt.Columns.Add(new DataColumn(Constant.SqlColumnNameDownloaded, typeof(bool)));
            foreach (BasicBook book in books)
            {
                DataRow row = dt.NewRow();
                row[Constant.SqlColumnNameWebUrl] = book.WebUrl;
                row[Constant.SqlColumnNameDownloadUrl] = book.DownloadUrl;
                row[Constant.SqlColumnNameName] = book.Name;
                row[Constant.SqlColumnNameDownloaded] = book.Downloaded;
                dt.Rows.Add(row);
            }

            dt.AcceptChanges();
            SqlParameter parameter = new SqlParameter(Constant.ParameterBasicBook, dt);
            parameter.SqlDbType = SqlDbType.Structured;
            parameter.TypeName = Constant.SqlTypeBasicBookType;
            return parameter;
        }

        #endregion

        #region Public Methods

        public void InsertBooks(IEnumerable<Book> books)
        {
            try
            {
                var connection = _connectionManager.OpenConnection();
                var transaction = _connectionManager.BeginTransaction();
                InsertBooks(connection, transaction, books);
                transaction.Commit();
            }
            finally
            {
                _connectionManager.CloseConnection();
            }
        }

        public int GetLastValidNumber()
        {
            int result = 1;
            try
            {
                var connection = _connectionManager.OpenConnection();
                result = GetLastValidNumber(connection);
            }
            finally
            {
                _connectionManager.CloseConnection();
            }
            return result;
        }

        public List<int> GetMissedUrlNumbers(bool includeNonFound)
        {
            List<int> result = null;
            try
            {
                var connection = _connectionManager.OpenConnection();
                result = GetMissedUrlNumbers(connection, includeNonFound);
            }
            finally
            {
                _connectionManager.CloseConnection();
            }
            return result;
        }

        public List<BasicBook> GetBasicBooksWithoutDownloadUrl(int startNum, int endNum)
        {
            List<BasicBook> books = null;
            try
            {
                var connection = _connectionManager.OpenConnection();
                books = GetBasicBooksWithoutDownloadUrl(connection, startNum, endNum);
            }
            finally
            {
                _connectionManager.CloseConnection();
            }
            return books;
        }

        public void UpdateBasicBooksInfo(IEnumerable<BasicBook> books)
        {
            try
            {
                var connection = _connectionManager.OpenConnection();
                var transaction = _connectionManager.BeginTransaction();
                UpdateBasicBooksInfo(connection, transaction, books);
                transaction.Commit();
            }
            finally
            {
                _connectionManager.CloseConnection();
            }
        }
        #endregion
    }
}

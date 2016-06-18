using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Douban.Dal
{
    public sealed class Constant
    {
        #region App setting parameter
        public const string Appsetting_RetryTime = "SqlConnection.RetryTime";
        public const string Appsetting_Timeout = "SqlConnection.Timeout";
        public const string Appsetting_MaxConnectionCount = "SqlConnection.MaxConnectionCount";
        public const string Connection_Name = "SqlConnection.Douban";
        #endregion

        #region Default App setting Value
        public const int Appsetting_RetryTime_Default = 5;
        public const int Appsetting_Timeout_Default = 5;
        public const int Appsetting_MaxConnectionCount_Default = 50;
        public const string Connection_String_Default = "Data Source=.;Initial Catalog=Douban;Integrated Security=True";
        #endregion

        #region SQL Procedure
        public const string ProcInsertOrUpdateBookInfos = "ProcInsertOrUpdateBookInfos";
        public const string ProcGetMaxDownloadedNumer = "ProcGetMaxDownloadedNumer";
        #endregion

    }
}

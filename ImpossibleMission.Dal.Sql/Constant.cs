using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Dyllan.Common;

namespace ImpossibleMission.Dal.Sql
{
    public static class Constant
    {
        public const string COMMONEBBPLAN = "COMMONEBBPLAN";
        public const string COMMONEBBINGHAUSITEM = "COMMONEBBINGHAUSITEM";
        public const string SCHEDULEPLAN = "SCHEDULEPLAN";
        public const string SCHEDULEITEM = "SCHEDULEITEM";

        #region App setting parameter
        public const string Appsetting_RetryTime = "SqlConnection.RetryTime";
        public const string Appsetting_Timeout = "SqlConnection.Timeout";
        public const string Appsetting_MaxConnectionCount = "SqlConnection.MaxConnectionCount";
        public const string Connection_Name = "MissionDal.Properties.Settings.ImpossibleMissionConnectionString";
        #endregion

        #region Default App setting Value
        public const int Appsetting_RetryTime_Default = 5;
        public const int Appsetting_Timeout_Default = 5;
        public const int Appsetting_MaxConnectionCount_Default = 50;
        public const string Connection_String_Default = "Data Source=.;Initial Catalog=ImpossibleMission;Integrated Security=True";
        #endregion

        #region SQL Procedure Name

        public const string ProcCreatePlan = "ProcCreatePlan";
        public const string ProcDeletePlan = "ProcDeletePlan";
        public const string ProcCreateCommonEbbPlan = "ProcCreateCommonEbbPlan";
        public const string ProcGetAllPlans = "ProcGetAllPlans";
        public const string ProcCreateOrUpdateDailyItems = "ProcCreateOrUpdateDailyItems";
        public const string ProcCreateOrUpdateCommonEbbinghausItems = "ProcCreateOrUpdateCommonEbbinghausItems";
        public const string ProcCreateSchedulePlan = "ProcCreateSchedulePlan";
        public const string ProcGetActivePlans = "ProcGetActivePlans";
        public const string ProcUpdatePlan = "ProcUpdatePlan";
        public const string ProcUpdateSchedulePlan = "ProcUpdateSchedulePlan";
        public const string ProcCreateOrUpdateScheduleItem = "ProcCreateOrUpdateScheduleItem";
        public const string ProcCreateOrUpdateBooks = "ProcCreateOrUpdateBooks";
        public const string ProcGetLastValidUrlNumberForBooks = "ProcGetLastValidUrlNumberForBooks";
        public const string ProcGetMissedUrlNumbers = "ProcGetMissedUrlNumbers";
        public const string ProcGetBasicBooksInfo = "ProcGetBasicBooksInfo";
        public const string ProcUpdateBooksBasicInfo = "ProcUpdateBooksBasicInfo";

        #endregion

        #region Parameter Name

        public const string ParameterID = "@ID";
        public const string ParameterPlanID = "@PlanID";
        public const string ParameterName = "@Name";
        public const string ParameterType = "@Type";
        public const string ParameterStartDate = "@StartDate";
        public const string ParameterEndDate = "@EndDate";
        public const string ParameterStatus = "@Status";
        public const string ParameterDetails = "@Details";
        public const string ParameterReview = "@Review";
        public const string ParameterDailyItems = "@dailyItems";
        public const string ParameterCommonEbbinghausItems = "@commonEbbinghausItems";
        public const string ParameterStartIndex = "@StartIndex";
        public const string ParameterEndIndex = "@EndIndex";
        public const string ParameterWeekDayWorkload = "@WeekDayWorkload";
        public const string ParameterWeekendWorkload = "@WeekendWorkload";
        public const string ParameterBuffer = "@Buffer";
        public const string ParameterExecuteDate = "@ExecuteDate";
        public const string ParameterProgressStatus = "@ProgressStatus";
        public const string ParameterNote = "@Note";
        public const string ParameterCurrentIndex = "@CurrentIndex";
        public const string ParameterCostTime = "@CostTime";
        public const string ParameterBooks = "@books";
        public const string ParameterIncludeNotFound = "@IncludeNotFound";
        public const string ParameterBasicBook = "@BasicBooks";
        public const string ParameterStartNumber = "@StartNumber";
        public const string ParameterEndNumber = "@EndNumber";

        #endregion

        #region Sql Data Type

        public const string SqlTypeDailyItemType = "dbo.DailyItemType";
        public const string SqlTypeCommonEbbinghausItemType = "dbo.CommonEbbinghausItemType";
        public const string SqlTypeBookType = "dbo.BookType";
        public const string SqlTypeBasicBookType = "dbo.BasicBookType";

        public const string SqlColumnNameID = "ID";
        public const string SqlColumnNamePlanID = "PlanID";
        public const string SqlColumnNameExecuteDate = "ExecuteDate";
        public const string SqlColumnNameName = "Name";
        public const string SqlColumnNameType = "Type";
        public const string SqlColumnNameProgressStatus = "ProgressStatus";
        public const string SqlColumnNameCommonEbbPlanID = "CommonEbbPlanID";
        public const string SqlColumnNameScore = "Score";
        public const string SqlColumnNameCostTime = "CostTime";

        public const string SqlColumnNameWebUrl = "WebUrl";
        public const string SqlColumnNameHttpStatus = "HttpStatus";
        public const string SqlColumnNamePublisher = "Publisher";
        public const string SqlColumnNameAuthor = "Author";
        public const string SqlColumnNameISBN = "ISBN";
        public const string SqlColumnNamePublishTime = "PublishTime";
        public const string SqlColumnNamePage = "Page";
        public const string SqlColumnNameLaguage = "Laguage";
        public const string SqlColumnNameFileSize = "FileSize";
        public const string SqlColumnNameFileFormat = "FileFormat";
        public const string SqlColumnNameDownloadUrl = "DownloadUrl";
        public const string SqlColumnNameTag = "Tag";
        public const string SqlColumnNameDescription = "Description";
        public const string SqlColumnNameDownloaded = "Downloaded";
        #endregion

        static TransactionOptions option;

        public static TransactionOptions Option
        {
            get
            {
                return option;
            }
        }

        static Constant()
        {
            option = new TransactionOptions();
            option.IsolationLevel = IsolationLevel.ReadCommitted;
            option.Timeout = new TimeSpan(0, AppSettingHelper.GetInteger(Appsetting_Timeout, Appsetting_Timeout_Default), 0);
        }
    }
}

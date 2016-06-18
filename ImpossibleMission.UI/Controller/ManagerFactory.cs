using ImpossibleMission.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpossibleMission.Model;
using Dyllan.Common;
using PlanManager = ImpossibleMission.Dal.Sql.PlanManager;
using BasePlanManager = ImpossibleMission.Dal.Sql.BasePlanManager;
using BookManager = ImpossibleMission.Dal.Sql.BookManager;

namespace ImpossibleMission
{
    public static class ManagerFactory
    {
        private const String SQL = "SQL";
        private static string DalEngine = AppSettingHelper.GetString("DalEngine", SQL);

        public static IPlanManager GetPlanManager(Plan plan)
        {
            IPlanManager result = null;
            switch (DalEngine)
            {
                case SQL:
                    result = new PlanManager(plan);
                    break;
                default:
                    break;
            }
            return result;
        }

        public static IBasePlanManager GetBasePlanManager()
        {
            IBasePlanManager result = null;
            switch (DalEngine)
            {
                case SQL:
                    result = BasePlanManager.Instance;
                    break;
                default:
                    break;
            }
            return result;
        }

        public static IBookManager GetBookManager()
        {
            IBookManager result = null;
            switch (DalEngine)
            {
                case SQL:
                    result = BookManager.Insatnce;
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}

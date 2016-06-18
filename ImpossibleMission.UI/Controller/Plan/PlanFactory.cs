using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using ImpossibleMission.Model;

namespace ImpossibleMission.Controller
{
    public static class PlanFactory
    {
        public static Plan CreatePlan(Type type, DateTime startDate, NameFormatter nameFormatter, FormatterArgs args)
        {
            Plan plan = (Plan)Activator.CreateInstance(type, startDate);
            var itemNames = nameFormatter.Format(args);

            foreach (string itemName in itemNames)
            {
                plan.GenerateItem(itemName);
            }

            return plan;
        }

    }
}

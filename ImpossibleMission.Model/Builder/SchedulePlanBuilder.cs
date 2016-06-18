using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Model
{
    public class SchedulePlanBuilder : PlanBuilder
    {
        private int _weekDayWorkload;
        private int _weekendWorkload;
        private int _startIndex;
        private int _endIndex;
        private float _buffer;

        public SchedulePlanBuilder(int startIndex, int endIndex, int weekDayWorkload, int weekendWorkload, float buffer)
        {
            _startIndex = startIndex;
            _endIndex = endIndex;
            _weekDayWorkload = weekDayWorkload;
            _weekendWorkload = weekendWorkload;
            _buffer = buffer;
        }

        public override Plan CreatePlan(Guid id, string name, DateTime startDate, DateTime endDate, string details, string review, ProgressStatusEnum status)
        {
            SchedulePlan tempPlan = new SchedulePlan(id, name, startDate, endDate, details, review, status);
            tempPlan.SetParameter(_startIndex, _endIndex, _weekDayWorkload, _weekendWorkload, _buffer);
            _plan = tempPlan;
            return _plan;
        }
    }
}

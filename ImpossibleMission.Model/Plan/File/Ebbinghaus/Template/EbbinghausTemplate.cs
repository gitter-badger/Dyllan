using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Model
{
    public enum ReviewEnum
    {
        A,
        B,
        C,
    }

    public abstract class EbbinghausTemplate
    {
        protected List<int> _periods = new List<int>();

        //public virtual void AddPeriod(int day)
        //{
        //    lock (_periods)
        //    { 
        //        if (day < 1 || _periods.Contains(day) || day > 700)
        //            return;
        //        _periods.Add(day);
        //    }
        //}

        //public virtual bool RemovePeriod(int day)
        //{
        //    lock (_periods)
        //    {
        //        return _periods.Remove(day);
        //    }
        //}

        public string Description
        {
            get;
        }

        public List<int> Periods
        {
            get
            {
                List<int> newPeriod = new List<int>(_periods);
                return newPeriod;
            }
        }
    }
}

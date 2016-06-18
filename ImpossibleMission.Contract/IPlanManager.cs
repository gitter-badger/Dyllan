using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpossibleMission.Model;

namespace ImpossibleMission.Contract
{
    public interface IPlanManager
    {
        Plan CreatePlan(Plan plan);
        void DeletePlan(Guid id);
        void UpdatePlan(Plan plan);
    }
}

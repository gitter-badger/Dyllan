using ImpossibleMission.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Contract
{
    public interface IBasePlanManager
    {
        List<Plan> GetAllPlans();
        List<Plan> GetActivePlans();
    }
}

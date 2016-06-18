using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Model
{
    public sealed class CommonEbbinghausTemplate : EbbinghausTemplate
    {
        private CommonEbbinghausTemplate()
        {
            _periods.Add(1);
            _periods.Add(5);
            _periods.Add(13);
            _periods.Add(28);
        }

        private static CommonEbbinghausTemplate _instance = new CommonEbbinghausTemplate();
        public static CommonEbbinghausTemplate Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}

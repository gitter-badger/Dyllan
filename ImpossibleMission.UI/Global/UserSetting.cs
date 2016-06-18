using ImpossibleMission.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission
{
    public static class UserSetting
    {
        private static EbbinghausTemplate _default;
        public static EbbinghausTemplate Default
        {
            get
            {
                return _default;
            }
        }

        static UserSetting()
        {
            // TODO: Get the default Ebbinghaus from user setting
            _default = CommonEbbinghausTemplate.Instance;
        }
    }
}

using System;
using System.Diagnostics;
using System.Security.Principal;

namespace Dyllan.Common
{
    public static class ProcessHelper
    {
        private static bool? isAdminPermission;
        private static EventLog eventLog;

        public static bool IsAdministratorPermission
        {
            get
            {
                if (!isAdminPermission.HasValue)
                {
                    WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
                    isAdminPermission = principal.IsInRole(WindowsBuiltInRole.Administrator);
                }

                return isAdminPermission.Value;
            }
        }

        public static EventLog EventLog
        {
            get 
            {
                if (eventLog == null)
                {
                    eventLog = new EventLog(AppDomain.CurrentDomain.FriendlyName, Environment.MachineName, AppDomain.CurrentDomain.FriendlyName);
                }
                return eventLog;
            }
        }
    }
}

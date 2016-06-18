using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyllan.Common.Config
{
    public static class FileConfig
    {
        private const string MaxFileSizeKey = "MaxFileSize";

        private static int? maxFileSize;

        /// <summary>
        /// Size in magabyte
        /// </summary>
        public static int MaxFileSize
        {
            get
            {
                if (!maxFileSize.HasValue) 
                {
                    maxFileSize = AppSettingHelper.GetInteger(MaxFileSizeKey, 10);
                }
                return maxFileSize.Value;
            }
        }
    }
}

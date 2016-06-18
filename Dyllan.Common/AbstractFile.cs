using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Dyllan.Common.Config;

namespace Dyllan.Common
{
    public abstract class AbstractFile
    {
        protected string fileName;

        protected virtual string FileName
        {
            get
            {
                return fileName;
            }
        }

        public AbstractFile(string fileName)
        {
            this.fileName = fileName;

            CheckFileExistOrCreate(fileName);
        }

        protected bool CheckFileExistOrCreate(string fileName)
        {
            bool isExist = true;

            if (!File.Exists(fileName))
            {
                isExist = false;
                string directoryName = Path.GetDirectoryName(fileName);
                if (!string.IsNullOrEmpty(directoryName) && !Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }

                using (File.Create(fileName)) { }
            }

            return isExist;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Model
{
    public class BasicBook
    {
        public string WebUrl { get; set; }
        public bool Downloaded { get; set; }
        public string DownloadUrl { get; set; }
        public string RealDownloadUrl { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(string.Format("WebUrl: {0}", WebUrl));
            str.AppendLine(string.Format("DownloadUrl: {0}", DownloadUrl));
            str.AppendLine(string.Format("Downloaded: {0}", Downloaded));

            return str.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpossibleMission.Model
{
    public class Book
    {
        public Guid ID { get; set; }
        public string WebUrl { get; set; }
        public string HttpStatus { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set;}
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string PublishTime { get; set; }
        public string Page { get; set; }
        public string Laguage { get; set; }
        public string FileSize { get; set; }
        public string FileFormat { get; set; }
        public string DownloadUrl { get; set; }
        public string Tag { get; set; }
        public string Description { get; set; }
        public bool Downloaded { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(string.Format("WebUrl:{0}", WebUrl));
            str.AppendLine(string.Format("HttpStatus:{0}", HttpStatus));
            str.AppendLine(string.Format("Name:{0}", Name));
            str.AppendLine(string.Format("Publisher:{0}", Publisher));
            str.AppendLine(string.Format("Author:{0}", Author));
            str.AppendLine(string.Format("ISBN:{0}", ISBN));
            str.AppendLine(string.Format("PublishTime:{0}", PublishTime));
            str.AppendLine(string.Format("Page:{0}", Page));
            str.AppendLine(string.Format("Laguage:{0}", Laguage));
            str.AppendLine(string.Format("FileSize:{0}", FileSize));
            str.AppendLine(string.Format("FileFormat:{0}", FileFormat));
            str.AppendLine(string.Format("DownloadUrl:{0}", DownloadUrl));
            str.AppendLine(string.Format("Tag:{0}", Tag));
            str.AppendLine(string.Format("Description:{0}", Description));
            return str.ToString();
        }
    }
}

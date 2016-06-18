using Douban.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Douban.Contract
{
    public interface IDoubanManager
    {
        void InsertOrUpdateBooks(IEnumerable<BookInfo> books);

        IEnumerable<int> GetDownloadFailedBooks(int topNum);

        int GetMaxDownloadedNumer();
    }
}

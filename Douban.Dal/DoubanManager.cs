using Douban.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Douban.Model;

namespace Douban.Dal
{
    public class DoubanManager : IDoubanManager
    {
        private BookDal _bookDal = BookDal.Instance;

        public IEnumerable<int> GetDownloadFailedBooks(int topNum)
        {
            throw new NotImplementedException();
        }

        public int GetMaxDownloadedNumer()
        {
            return _bookDal.GetMaxDownloadedNumer();
        }

        public void InsertOrUpdateBooks(IEnumerable<BookInfo> books)
        {
            _bookDal.InsertOrUpdateBooks(books);
        }
    }
}

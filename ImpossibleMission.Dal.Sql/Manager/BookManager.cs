using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpossibleMission.Contract;
using ImpossibleMission.Model;

namespace ImpossibleMission.Dal.Sql
{
    public sealed class BookManager : IBookManager
    {
        private static BookManager _instance = new BookManager();
        public static BookManager Insatnce
        {
            get
            {
                return _instance;
            }
        }
        private BookDal _bookDal = BookDal.Instance;
        private BookManager()
        { }

        public void InsertBooks(IEnumerable<Book> books)
        {
            _bookDal.InsertBooks(books);
        }

        public int GetLastValidNumber()
        {
            return _bookDal.GetLastValidNumber();
        }

        public List<int> GetMissedUrlNumbers(bool includeNonFound)
        {
            return _bookDal.GetMissedUrlNumbers(includeNonFound);
        }

        public List<BasicBook> GetBasicBooksWithoutDownloadUrl(int startNum, int endNum)
        {
            return _bookDal.GetBasicBooksWithoutDownloadUrl(startNum, endNum);
        }

        public void UpdateBasicBooksInfo(IEnumerable<BasicBook> books)
        {
            _bookDal.UpdateBasicBooksInfo(books);
        }
    }
}

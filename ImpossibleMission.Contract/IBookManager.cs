using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpossibleMission.Model;

namespace ImpossibleMission.Contract
{
    public interface IBookManager
    {
        void InsertBooks(IEnumerable<Book> books);
        int GetLastValidNumber();
        List<int> GetMissedUrlNumbers(bool includeNonFound);

        List<BasicBook> GetBasicBooksWithoutDownloadUrl(int startNum, int endNum);
        void UpdateBasicBooksInfo(IEnumerable<BasicBook> books);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Douban.Contract
{
    public interface ISpider
    {
        void Restart();
        void Run();
        void Stop();
        event EventHandler<int> OnProceed;
        event EventHandler OnCompleted;
    }
}

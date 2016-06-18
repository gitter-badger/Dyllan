using Douban.Spider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Douban.Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(RefreshUI);
            t.Start();
            BookSpider bookSpider = new BookSpider(10000000, 100000000, 1000);
            bookSpider.OnProceed += BookSpider_OnProceed;
            bookSpider.OnCompleted += BookSpider_OnCompleted;
            bookSpider.Run();

            Console.Read();
        }

        private static int completed = 0;
        private static void BookSpider_OnProceed(object sender, int e)
        {
            Interlocked.Add(ref completed, e);
        }

        private static void RefreshUI()
        {
            while (true)
            {
                Console.CursorLeft = 0;
                Console.Write("Downloaded {0}", completed);
                Thread.Sleep(1000);
            }
        }

        private static void BookSpider_OnCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Done!");
        }

    }
}

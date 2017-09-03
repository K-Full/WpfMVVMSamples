using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RxSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = new Subject<int>();

            source.Throttle(TimeSpan.FromMilliseconds(500))
                .Subscribe(i => Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff} {i}"));

            foreach(var i in Enumerable.Range(1,10))
            {
                Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff} OnNext({i})");
                source.OnNext(i);
                Thread.Sleep(100);
            }

            Console.WriteLine($"{DateTime.Now:HH:mm:ss:fff} Sleep(2000)");
            Thread.Sleep(2000);

            foreach (var i in Enumerable.Range(1, 5))
            {
                Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff} OnNext({i})");
                source.OnNext(i);
                Thread.Sleep(100);
            }

            Console.WriteLine($"{DateTime.Now:HH:mm:ss:fff} Sleep(2000)");
            Thread.Sleep(2000);

        }
    }
}

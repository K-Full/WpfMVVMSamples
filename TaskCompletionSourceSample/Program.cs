using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCompletionSourceSample
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
            var task = tcs.Task;

            ThreadPool.QueueUserWorkItem(_ =>
            {
                Thread.Sleep(1000);
                tcs.SetResult(123);
            });

            Console.WriteLine("waiting...");
            // waitはなくてもResultに値が入るまで待ってくれる
            task.Wait();
            Console.WriteLine("running...");
            Console.WriteLine($"task computed {task.Result}");
        }
    }
}

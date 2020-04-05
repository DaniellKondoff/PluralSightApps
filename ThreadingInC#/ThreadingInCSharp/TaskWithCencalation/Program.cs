using System;
using System.Threading;

namespace TaskWithCencalation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Method Thred ID: " + Thread.CurrentThread.ManagedThreadId);
            Worker worker = new Worker();
            System.Timers.Timer tmr = new System.Timers.Timer();
            tmr.Interval = 5000;
            tmr.Elapsed += worker.tmr_Elapsed;
            tmr.Start();
            Console.ReadLine();
            tmr.Stop();
            Console.WriteLine("After Main Method Thred ID: " + Thread.CurrentThread.ManagedThreadId);
        }
    }
}

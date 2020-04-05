using System;
using System.Threading;

namespace TimersProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Threding.Timer
            ThreadingTimer();

            System.Timers.Timer tmr = new System.Timers.Timer();       // Doesn't require any args
            tmr.Interval = 5000;
            tmr.Elapsed += tmr_Elapsed;    // Uses an event instead of a delegate
            tmr.Start();                   // Start the timer
            Console.ReadLine();
            tmr.Stop();                    // Stop the timer
            Console.ReadLine();
            tmr.Start();                   // Restart the timer
            Console.ReadLine();
            tmr.Dispose();

        }

        private static void ThreadingTimer()
        {
            Console.WriteLine(DateTime.Now);
            Timer tmr = new Timer(Tick, "tick...", 5000, 1000);
            Console.ReadLine();
            tmr.Dispose();
        }

        static void Tick(object data)
        {
            Console.WriteLine(DateTime.Now);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);     
            Console.WriteLine(data);
        }

        static void tmr_Elapsed(object sender, EventArgs e)
        {
            Console.WriteLine("Tick, Current date is: " + DateTime.Now);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }
    }
}

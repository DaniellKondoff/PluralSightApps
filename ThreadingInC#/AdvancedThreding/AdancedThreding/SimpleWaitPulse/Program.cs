using System;
using System.Threading;

namespace SimpleWaitPulse
{
    class Program
    {
        static readonly object _locker = new object();
        static bool _go;

        static void Main(string[] args)
        {
            new Thread(WaithTimeout).Start();     // because _go==false.

            Console.ReadLine();            // Wait for user to hit Enter

            lock (_locker)                 // Let's now wake up the thread by
            {                              // setting _go=true and pulsing.
                _go = true;
                Monitor.Pulse(_locker);
            }
            Console.WriteLine("Released");
        }

        static void Work()
        {
            lock (_locker)
                while (!_go)
                    Monitor.Wait(_locker);     // Lock is released while we’re waiting

            Console.WriteLine("Woken!!!");
        }

        static void WaithTimeout()
        {
            lock (_locker)
                while (!_go)
                    Monitor.Wait(_locker, 1000);

            Console.WriteLine("Woken!!!");
        }
    }
}

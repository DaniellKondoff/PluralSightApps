using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Locking
{
    public class SemaphoreSlimExample
    {
        static SemaphoreSlim _sem = new SemaphoreSlim(3);    // Capacity of 3

        public static void Enter(object id)
        {
            Console.WriteLine(id + " wants to enter");
            _sem.Wait();
            Console.WriteLine(id + " is in!");           // Only three threads
            Thread.Sleep(1000 * (int)id);               // can be here at
            Console.WriteLine(id + " is leaving");       // a time.
            _sem.Release();
        }
    }
}

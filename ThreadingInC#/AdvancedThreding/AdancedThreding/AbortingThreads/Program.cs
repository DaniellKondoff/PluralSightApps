using System;
using System.Threading;

namespace AbortingThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(Work);
            t.Start();
            Thread.Sleep(1000); 
            t.Abort();
            Thread.Sleep(1000); 
            t.Abort();
            Thread.Sleep(1000); 
            t.Abort();
        }

        static void Work()
        {
            while (true)
            {
                try { 
                    while (true) ; 
                }
                catch (ThreadAbortException) 
                { 
                    Thread.ResetAbort(); 
                }
                Console.WriteLine("I will not die!");
            }
        }
    }
}

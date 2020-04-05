using System;
using System.Threading;

namespace EventWaitHandles
{
    class Program
    {
        static void Main(string[] args)
        {
            new Thread(AutoResetEventExample.Waiter).Start();
            Console.ReadKey();
            AutoResetEventExample.WakeUp();


            for (int i = 1; i <= 2; i++)
            {
                new Thread(CountdownEventExample.SaySomething).Start("I am thred " + i);
            }
            CountdownEventExample.Wait();

            Console.ReadKey();
        }
    }
}

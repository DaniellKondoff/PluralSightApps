using System;
using System.Threading;

namespace EventWaitHandles
{
    public class CountdownEventExample
    {
        static CountdownEvent _countdown = new CountdownEvent(3);

        public static void Wait()
        {
            _countdown.Wait();   // Blocks until Signal has been called 3 times
            Console.WriteLine("All threads have finished speaking!");
        }

        public static void SaySomething(object thing)
        {
            Thread.Sleep(1000);
            Console.WriteLine(thing);
            _countdown.Signal();
            Console.WriteLine("After Signal: " + thing);
        }
    }
}

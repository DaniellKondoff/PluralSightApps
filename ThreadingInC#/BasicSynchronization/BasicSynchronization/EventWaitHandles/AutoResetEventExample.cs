using System;
using System.Threading;

namespace EventWaitHandles
{
    public class AutoResetEventExample
    {
        static EventWaitHandle _waitHandle = new AutoResetEvent(false);


        public static void WakeUp()
        {
            _waitHandle.Set();
        }

        public static void Waiter()
        {
            Console.WriteLine("Waiting...");
            _waitHandle.WaitOne();                // Wait for notification
            Console.WriteLine("Notified");
        }
    }
}

using System;
using System.Threading;

namespace EventWaitHandles
{
    //[Synchronization]
    public class SynchronizationContextExample : ContextBoundObject
    {
        public void Demo()
        {
            Console.Write("Start...");
            Thread.Sleep(1000);           // We can't be preempted here
            Console.WriteLine("end");     // thanks to automatic locking!
        }
    }
}

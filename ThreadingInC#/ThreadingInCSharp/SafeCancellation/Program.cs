using System;
using System.Threading;

namespace SafeCancellation
{
    class Program
    {
        static void Main(string[] args)
        {
            var canceler = new RulyCanceler();

            new Thread(() =>
            {
                try 
                { 
                    Work(canceler); 
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Canceled!");
                }
            }).Start();

            Console.ReadKey();
            canceler.Cancel(); // Safely cancel worker.
        }

        static void Work(RulyCanceler c)
        {
            while (true)
            {
                c.ThrowIfCancellationRequested();
                // ...
                try 
                { 
                    OtherMethod(c); 
                }
                finally { /* any required cleanup */ }
            }
        }

        static void OtherMethod(RulyCanceler c)
        {
            Console.WriteLine("Other Method Called");
            c.ThrowIfCancellationRequested();
        }
    }
}

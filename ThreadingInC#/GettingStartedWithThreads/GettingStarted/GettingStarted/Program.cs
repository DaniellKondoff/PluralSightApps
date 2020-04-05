using System;
using System.Threading;

namespace GettingStarted
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        private static void NamingThreads()
        {
            Thread.CurrentThread.Name = "main";
            Thread worker = new Thread(GoNaming);
            worker.Name = "worker";
            worker.Start();
            GoNaming();
        }

        private static void PassingDataToRhread()
        {
            Thread t = new Thread(() => Print("Hello from t!"));
            t.Start();

            new Thread(() =>
            {
                Console.WriteLine("I'm running on another thread!");
                Console.WriteLine("This is so easy!");
            }).Start();

            Thread t2 = new Thread(Print);
            t.Start("Hello from t!");
        }

        private static Thread ThreadStart()
        {
            Thread t = new Thread(Hello);

            t.Start();      // Run Go() on the new thread.
            Hello();        // Simultaneously run Go() in the main thread.
            return t;
        }

        private static void JoinThread()
        {
            Thread t = new Thread(Go);
            t.Start();
            t.Join();
            Console.WriteLine();
            Console.WriteLine("Thread t has ended!");
        }

        static void Go()
        {
            for (int i = 0; i < 1000; i++) Console.Write("y");
        }

        static void Hello()
        {
            Console.WriteLine("hello!");
        }

        static void Print(string message)
        {
            Console.WriteLine(message);
        }

        static void Print(object messageObj)
        {
            string message = (string)messageObj;   // We need to cast here
            Console.WriteLine(message);
        }

        static void GoNaming()
        {
            Console.WriteLine("Hello from " + Thread.CurrentThread.Name + " with Id: " + Thread.CurrentThread.ManagedThreadId);
        }
    }
}

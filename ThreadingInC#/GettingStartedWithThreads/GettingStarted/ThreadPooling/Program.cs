using System;
using System.Threading;

namespace ThreadPooling
{
    class Program
    {
        static void Main(string[] args)
        {
            //QueueUserWorkItemWay();

            Func<string, int> method = Work;
            IAsyncResult cookie = method.BeginInvoke("test", Done, method);
            //
            // ... here's where we can do other work in parallel...
            //
            int result = method.EndInvoke(cookie);
            Console.WriteLine("String length is: " + result);
        }
        static int Work(string s) 
        { 
            return s.Length; 
        }

        static void Done(IAsyncResult cookie)
        {
            var target = (Func<string, int>)cookie.AsyncState;
            int result = target.EndInvoke(cookie);
            Console.WriteLine("String length is: " + result);
        }

        private static void QueueUserWorkItemWay()
        {
            ThreadPool.QueueUserWorkItem(Go);
            ThreadPool.QueueUserWorkItem(Go, 123);
            Console.ReadLine();
        }

        static void Go(object data)   // data will be null with the first call.
        {
            Console.WriteLine("Hello from the thread pool! " + data);
        }
    }
}

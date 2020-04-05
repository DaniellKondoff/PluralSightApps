using System;
using System.Threading;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Thread(Go);

            t.Start();

            try
            {
                new Thread(Go).Start();
            }
            catch (Exception ex)
            {
                // We'll never get here!
                Console.WriteLine("Exception in main method!");
            }
           
        }

        static void Go()
        {
            try
            {
               
                throw null;    // The NullReferenceException will get caught below
                               // ...
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Thread Method catched");
            }
        }
    }
}

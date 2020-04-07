using System;
using System.Threading;

namespace TheBarrier
{
    class Program
    {
        static Barrier _barrier = new Barrier(3, _barrier => Console.WriteLine(""));

        static void Main(string[] args)
        {
            new Thread(Speak).Start();
            new Thread(Speak).Start();
            new Thread(Speak).Start();
        }

        static void Speak()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write(i + " ");
                _barrier.SignalAndWait();
            }
        }
    }
}

using System;
using System.Threading;

namespace Locking
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(SemaphoreSlimExample.Enter).Start(i);
            }
        }
    }
}

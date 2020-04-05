using System;
using System.Threading;

namespace CancellationTokens
{
    class Program
    {
        static void Main(string[] args)
        {
            var cancelSource = new CancellationTokenSource(1000);

            var t = new Thread(() => Work(cancelSource.Token));

            t.Start();
        }

        static void Work(CancellationToken cancelToken)
        {
            for (int i = 0; i < 10000; i++)
            {
                if (cancelToken.IsCancellationRequested)
                {
                    Console.WriteLine("Cancellation Token Requsted");
                    return;
                }
                Console.WriteLine(i);
            }
        }
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace TaskWithCencalation
{
    public class Worker
    {
        private int counter = 0;
        private readonly object locker = new object();

        public async Task StartWorker()
        {
            
            try
            {
                Console.WriteLine("In StartWorker Thred ID: " + Thread.CurrentThread.ManagedThreadId);
                var cancelSource = new CancellationTokenSource(1000);
                bool isReplaying = true;


                await Task.Run(() =>
                {
                    Console.WriteLine("In Task Thred ID: " + Thread.CurrentThread.ManagedThreadId);
                    while (isReplaying)
                    {
                        if (cancelSource.IsCancellationRequested)
                        {
                            Console.WriteLine("Enough!: " + Thread.CurrentThread.ManagedThreadId);
                            break;
                        }

                        lock(locker)
                            counter++;
                        Console.WriteLine(counter);
                    }
                }, cancelSource.Token);

                Console.WriteLine("After StartWorker Thred ID: " + Thread.CurrentThread.ManagedThreadId);
               
            }
            catch(Exception ex)
            {

            }
        }

        public async void tmr_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("In tmr_Elapsed Thred ID: " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine($"Thred with ID: {Thread.CurrentThread.ManagedThreadId} is trying enter");

            await StartWorker();

            Console.WriteLine("After tmr_Elapsed Thred ID: " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("End Cycle with Thred ID: "+ +Thread.CurrentThread.ManagedThreadId);
        }
    }
}

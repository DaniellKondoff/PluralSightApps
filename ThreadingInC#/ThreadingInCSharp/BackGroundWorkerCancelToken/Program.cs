using System;
using System.Threading;
using System.Timers;

namespace BackGroundWorkerCancelToken
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Timers.Timer tmr = new System.Timers.Timer();
            tmr.Interval = 5000;
            tmr.Elapsed += tmr_Elapsed;
            tmr.Start(); 
            Console.ReadLine();
            tmr.Stop();
            //StartWorker();

            //Console.ReadLine();
        }

        private static void tmr_Elapsed(object sender, ElapsedEventArgs e)
        {
            StartWorker();
        }

        private static void StartWorker()
        {
            var cancelSource = new CancellationTokenSource(1000);
            var worker = new Worker();
            worker.DoWork += worker.bw_DoWork;
            worker.ProgressChanged += worker.bw_ProgressChanged;
            worker.RunWorkerCompleted += worker.bw_RunWorkerCompleted;

            worker.RunWorkerAsync(cancelSource.Token);
        }
    }
}

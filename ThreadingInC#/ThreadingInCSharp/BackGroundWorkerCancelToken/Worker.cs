using System;
using System.ComponentModel;
using System.Threading;

namespace BackGroundWorkerCancelToken
{
    public class Worker : BackgroundWorker
    {
        public Worker()
        {
            this.WorkerSupportsCancellation = true;
            this.WorkerReportsProgress = true;
        }


        public void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("Worker Started at: " + DateTime.Now);
            CancellationToken cancellationToken = (CancellationToken)e.Argument;
            cancellationToken.Register(bw_CancellAction);

            for (int i = 0; i <= 100000; i += 1)
            {
                if (this.CancellationPending)
                {
                    e.Cancel = true;
                    Console.WriteLine("Cancellation Token Requsted");
                    return;
                }

                //if (cancellationToken.IsCancellationRequested)
                //{
                //    Console.WriteLine("Cancellation Token Requsted");
                //    return;
                //}
                Console.WriteLine(i);
            }                           

            //e.Result = 123;    // This gets passed to RunWorkerCompleted
        }

        public void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                Console.WriteLine("You canceled at: " + DateTime.Now);
            else if (e.Error != null)
                Console.WriteLine("Worker exception: " + e.Error.ToString());
            else
                Console.WriteLine("Complete: " + e.Result);      // from DoWork
        }

        public void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine("Reached " + e.ProgressPercentage + "%");
        }

        private void bw_CancellAction()
        {
            if (this.IsBusy)
                this.CancelAsync();
        }

        public void bw_Test(object sender, CancellationTokenEventArgs e)
        {

        }
    }
}

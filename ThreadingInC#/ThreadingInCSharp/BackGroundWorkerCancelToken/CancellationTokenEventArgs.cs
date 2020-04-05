using System.ComponentModel;
using System.Threading;

namespace BackGroundWorkerCancelToken
{
    public class CancellationTokenEventArgs : DoWorkEventArgs
    {
        public CancellationToken cancellationToken;

        public CancellationTokenEventArgs(object argument) : base(argument)
        {
        }
    }
}

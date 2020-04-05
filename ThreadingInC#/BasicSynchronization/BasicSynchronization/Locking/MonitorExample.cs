using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Locking
{
    public class MonitorExample
    {
        static readonly object _locker = new object();
        static int _val1, _val2;

        public static void Go()
        {
            bool lockTacken = false;
            try
            {
                Monitor.Enter(_locker, ref lockTacken);

                if (_val2 != 0)
                    Console.WriteLine(_val1 / _val2);

                _val2 = 0;
            }
            finally
            {
                if (lockTacken)
                    Monitor.Exit(_locker);
            }
        }
    }
}

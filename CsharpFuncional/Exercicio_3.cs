using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CsharpFuncional
{

    public static class TimerHelper
    {
        public static void Timer(Action f, Action<long> w)
        {
            var watch = Stopwatch.StartNew();
            f();
            watch.Stop();
            w(watch.ElapsedMilliseconds);
        }

    }

}

using UnityEngine;
using System.Collections;
using System;
using System.Diagnostics;

namespace Game
{
    public class TimerWatch : IDisposable
    {
        public TimerWatch(string tag)
        {
            _tag = tag;
            _stopWatch = Stopwatch.StartNew();
        }

        public void Dispose()
        {
            _stopWatch.Stop();
            GameInput.Log("'{0}' exec time: {1:0.000} (ms)", _tag, ((double)_stopWatch.ElapsedTicks / (double)Stopwatch.Frequency) * 1000);
        }

        string _tag;
        Stopwatch _stopWatch;

        private void Test()
        {
    
        }
    }

}
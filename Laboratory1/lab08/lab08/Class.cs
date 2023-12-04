using System;
using System.Threading;

namespace lab08
{
    public class CustomTimer
    {
        private Timer timer;

        public event Action timeElapsed;
        public event Action<Exception> onError;

        public CustomTimer()
        {
            timer = new Timer(TimerCallback, null, Timeout.Infinite, Timeout.Infinite);
        }

        public void Start(int interval)
        {
            timer.Change(0, interval);
        }

        public void Stop()
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        private void TimerCallback(object state)
        {
            try
            {
                timeElapsed?.Invoke();
            }
            catch (Exception ex)
            {
                onError?.Invoke(ex);
            }
        }
    }
}
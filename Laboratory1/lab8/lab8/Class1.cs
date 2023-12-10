using System;
using System.Threading;
using System.Threading.Tasks;

namespace lab8
{
    public class CustomTimer
    {
        private readonly int interval;
        private bool isRunning;
        private CancellationTokenSource cts;

        public event Action timeElapsed;
        public event Action<Exception> onError;

        public CustomTimer(int interval)
        {
            this.interval = interval;
            isRunning = false;
        }

        public void Start()
        {
            if (!isRunning)
            {
                isRunning = true;
                cts = new CancellationTokenSource();

                Task.Run(() => TimerLoop(cts.Token), cts.Token);
            }
        }

        public void Stop()
        {
            if (isRunning)
            {
                cts.Cancel();
                isRunning = false;
            }
        }

        private async void TimerLoop(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(interval, cancellationToken);
                    OnTimeElapsed();
                }
            }
            catch (Exception ex)
            {
                OnError(ex);
            }
        }

        private void OnTimeElapsed()
        {
            if (timeElapsed != null)
            {
                try
                {
                    timeElapsed.Invoke();
                }
                catch (Exception ex)
                {
                    OnError(ex);
                }
            }
        }

        private void OnError(Exception ex)
        {
            if (onError != null)
            {
                onError.Invoke(ex);
            }
        }
    }
}
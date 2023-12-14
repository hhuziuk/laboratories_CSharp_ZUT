using System;
using System.Threading;
using System.Threading.Tasks;

namespace CMH
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

                ThreadPool.QueueUserWorkItem(state => TimerLoop(cts.Token));
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

        private void TimerLoop(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    Thread.Sleep(interval);
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
            timeElapsed?.Invoke();
        }

        private void OnError(Exception ex)
        {
            onError?.Invoke(ex);
        }
    }

    public class CustomBackgroundWorker
    {
        private Task workerTask;

        public event Action<int> ProgressChanged;
        public event Action<Exception> Error;

        public void RunWorkerAsync(object argument)
        {
            workerTask = Task.Run(() => DoWork(argument));
        }

        public void ReportProgress(int progressPercentage)
        {
            ProgressChanged?.Invoke(progressPercentage);
        }

        private void DoWork(object argument)
        {
            try
            {
                for (int i = 0; i <= 100; i += 10)
                {
                    ReportProgress(i);
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                Error?.Invoke(ex);
            }
        }
    }
}

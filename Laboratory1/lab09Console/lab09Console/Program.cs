using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomLibrary
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
        private int matrixSize = 1000;
        private int[,] matrixA;
        private int[,] matrixB;
        private int[,] resultMatrix;

        public event Action<int> ProgressChanged;
        public event Action Completion;

        public void RunWorkerAsync()
        {
            InitializeMatrices();
            Task.Run(() => MultiplyMatrices()).ContinueWith(_ => Completion?.Invoke());
        }

        public void ReportProgress(int progressPercentage)
        {
            ProgressChanged?.Invoke(progressPercentage);
        }

        private void InitializeMatrices()
        {
            matrixA = new int[matrixSize, matrixSize];
            matrixB = new int[matrixSize, matrixSize];
            resultMatrix = new int[matrixSize, matrixSize];

            Random rand = new Random();

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    matrixA[i, j] = rand.Next(1, 10);
                    matrixB[i, j] = rand.Next(1, 10);
                }
            }
        }

        private void MultiplyMatrices()
        {
            int matrixSize = matrixA.GetLength(0);
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < matrixSize; k++)
                    {
                        sum += matrixA[i, k] * matrixB[k, j];
                    }
                    resultMatrix[i, j] = sum;

                    int progressPercentage = (int)(((i * matrixSize) + j + 1) / (double)(matrixSize * matrixSize) * 100);
                    ReportProgress(progressPercentage);
                }
            }
        }
    }

    class Program
    {
        private static readonly object consoleLock = new object();
        private static bool isMatrixMultiplicationCompleted = false;

        static void Main(string[] args)
        {
            var customTimer = new CustomTimer(100000);
            customTimer.timeElapsed += TimerElapsedHandler;
            customTimer.Start();

            Console.WriteLine("Press Enter to simulate matrix multiplication progress.");
            Console.ReadLine();

            SimulateMatrixMultiplication();

            customTimer.Stop();
            
            while (!isMatrixMultiplicationCompleted)
            {
                Thread.Sleep(100); 
            }
        }

        private static void TimerElapsedHandler()
        {
            Console.WriteLine("Timer elapsed!");
        }

        private static void SimulateMatrixMultiplication()
        {
            var customBackgroundWorker = new CustomBackgroundWorker();
            customBackgroundWorker.ProgressChanged += MatrixWorker_ProgressChanged;
            customBackgroundWorker.Completion += MatrixWorker_Completion;

            Console.Write("Matrix Multiplication Progress: \n");

            customBackgroundWorker.RunWorkerAsync();

            Console.ReadLine(); 
        }

        private static void MatrixWorker_ProgressChanged(int progressPercentage)
        {
            int barLength = 20;
            int numBlocks = barLength * progressPercentage / 100;
            string progressBar = "|" + new string('*', numBlocks) + new string(' ', barLength - numBlocks) + "|";

            lock (consoleLock)
            {
                Console.Write($"\r{progressBar} {progressPercentage}%");

                if (progressPercentage == 100)
                {
                    Console.WriteLine(); 
                }
            }
        }

        private static void MatrixWorker_Completion()
        {
            Console.WriteLine("\nMatrix Multiplication complete.");
            isMatrixMultiplicationCompleted = true;
        }
    }
}
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace lab7
{
    public partial class Form1 : Form
    {
        private BackgroundWorker matrixWorker;
        private int matrixSize = 1000;
        private int[,] matrixA;
        private int[,] matrixB;
        private int[,] resultMatrix;

        public Form1()
        {
            InitializeComponent();
            InitializeMatrices();
            matrixWorker = new BackgroundWorker();
            matrixWorker.WorkerReportsProgress = true;
            matrixWorker.DoWork += MatrixWorker_DoWork;
            matrixWorker.ProgressChanged += MatrixWorker_ProgressChanged;
            matrixWorker.RunWorkerCompleted += MatrixWorker_RunWorkerCompleted;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!matrixWorker.IsBusy)
            {
                matrixWorker.RunWorkerAsync();
            }
        }

        private void MatrixWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            MultiplyMatrices(worker, e);
        }

        private void MatrixWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void MatrixWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(e.Error != null ? "OOPS: " + e.Error.Message : "multiplying is over!");
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

        private void MultiplyMatrices(BackgroundWorker worker, DoWorkEventArgs e)
        {
            int progressPercentage = 0;
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
                    progressPercentage = (int)(((i * matrixSize) + j) / (double)(matrixSize * matrixSize) * 100);
                }
                worker.ReportProgress(progressPercentage);
            }
        }

        private void progressBar1_Click(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }
    }
}

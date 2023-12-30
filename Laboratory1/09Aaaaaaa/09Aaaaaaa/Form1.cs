using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using CMH;

namespace lab8
{
    public partial class Form1 : Form
    {
        private CustomTimer customTimer;
        private int matrixSize = 500;
        private int[,] matrixA;
        private int[,] matrixB;
        private int[,] resultMatrix;

        public Form1()
        {
            InitializeComponent();
            customTimer = new CustomTimer(5000);
            customTimer.timeElapsed += TimerElapsedHandler;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            customTimer.Start();
        }

        private void TimerElapsedHandler()
        {
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            customTimer.Stop();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var customBackgroundWorker = new CustomBackgroundWorker();
            customBackgroundWorker.ProgressChanged += MatrixWorker_ProgressChanged;
            customBackgroundWorker.Error += MatrixWorker_Error;

            InitializeMatrices();

            await Task.Run(() => MultiplyMatrices(matrixA, matrixB, resultMatrix));
            MessageBox.Show("Matrix Multiplication was done");
        }

        private void MatrixWorker_ProgressChanged(int progressPercentage)
        {
            progressBar1.Invoke((MethodInvoker)(() => progressBar1.Value = progressPercentage));
        }

        private void MatrixWorker_Error(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void MultiplyMatrices(int[,] matrixA, int[,] matrixB, int[,] resultMatrix)
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

                    int progressPercentage = (int)(((i * matrixSize) + j) / (double)(matrixSize * matrixSize) * 100);
                    MatrixWorker_ProgressChanged(progressPercentage);
                }
            }
        }

    }
}

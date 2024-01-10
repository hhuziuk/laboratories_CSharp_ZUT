using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();
        private int maxWidth;
        private int maxHeight;
        private int score, highScore;
        private bool gameOverFlag = false;
        private Timer gameTimer = new Timer();
        private PictureBox picCanvas = new PictureBox();
        private TextBox txtScore = new TextBox();

        public Form1()
        {
            InitializeComponent();
            InitializeGame();

            picCanvas.Size = new Size(maxWidth * Settings.Width, maxHeight * Settings.Height);
            picCanvas.Location = new Point(0, 0);
            Controls.Add(picCanvas);
            picCanvas.Paint += picCanvas_Paint;
            gameTimer.Interval = 100;
            gameTimer.Tick += gameTimer_Tick;
            gameTimer.Start();
        }

        private void InitializeGame()
        {
            maxWidth = 20;
            maxHeight = 20;
            Snake.Add(new Circle { X = 5, Y = 5 });
            score = 0;
            SpawnFood();
        }

        private void SpawnFood()
        {
            Random rand = new Random();
            food = new Circle { X = rand.Next(0, maxWidth), Y = rand.Next(0, maxHeight) };
        }

        private void UpdateGame()
        {
            MoveSnake();
            CheckCollision();
            CheckFoodCollision();
            picCanvas.Invalidate();
        }

        private void MoveSnake()
        {
            List<Circle> newSnake = new List<Circle>();
            Circle head = new Circle();
            switch (Settings.directions)
            {
                case "left":
                    head = new Circle { X = Snake[0].X - 1, Y = Snake[0].Y };
                    break;
                case "right":
                    head = new Circle { X = Snake[0].X + 1, Y = Snake[0].Y };
                    break;
                case "down":
                    head = new Circle { X = Snake[0].X, Y = Snake[0].Y + 1 };
                    break;
                case "up":
                    head = new Circle { X = Snake[0].X, Y = Snake[0].Y - 1 };
                    break;
            }

            newSnake.Add(head);
            for (int i = 1; i < Snake.Count; i++)
            {
                newSnake.Add(Snake[i - 1]);
            }
            Snake = newSnake;
            CheckBoundaries();
        }


        private void CheckBoundaries()
        {
            if (Snake[0].X < 0)
                Snake[0].X = maxWidth - 1;

            if (Snake[0].X >= maxWidth)
                Snake[0].X = 0;

            if (Snake[0].Y < 0)
                Snake[0].Y = maxHeight - 1;

            if (Snake[0].Y >= maxHeight)
                Snake[0].Y = 0;
        }

        private void CheckCollision()
        {
            for (int i = 1; i < Snake.Count; i++)
            {
                if (Snake[0].X == Snake[i].X && Snake[0].Y == Snake[i].Y)
                {
                    GameOver();
                    return;
                }
            }

            if (Snake[0].X < 0 || Snake[0].X >= maxWidth || Snake[0].Y < 0 || Snake[0].Y >= maxHeight)
            {
                GameOver();
            }
        }

        private void CheckFoodCollision()
        {
            if (Snake[0].X == food.X && Snake[0].Y == food.Y)
            {
                EatFood();
            }
        }

        private void EatFood()
        {
            score++;
            txtScore.Text = "Score: " + score;

            // Determine the position for the new circle based on the direction of the last segment
            int newX = Snake[Snake.Count - 1].X;
            int newY = Snake[Snake.Count - 1].Y;

            switch (Settings.directions)
            {
                case "left":
                    newX++;
                    break;
                case "right":
                    newX--;
                    break;
                case "down":
                    newY--;
                    break;
                case "up":
                    newY++;
                    break;
            }

            Snake.Add(new Circle { X = newX, Y = newY });
            if (Snake[0].X == food.X && Snake[0].Y == food.Y)
            {
                SpawnFood();
            }
            else
            {
                Snake.RemoveAt(Snake.Count - 1);
            }

            label1.Text = "Score: " + score;
        }



        private void GameOver()
        {
            gameTimer.Stop();
            MessageBox.Show("Game Over! Your score is: " + score, "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (score > highScore)
            {
                highScore = score;
            }
            gameOverFlag = true;
            InitializeGame();
        }

        private void DrawGame(Graphics canvas)
        {
            foreach (var segment in Snake)
            {
                canvas.FillEllipse(Brushes.Black, segment.X * Settings.Width, segment.Y * Settings.Height, Settings.Width, Settings.Height);
            }

            canvas.FillEllipse(Brushes.Red, food.X * Settings.Width, food.Y * Settings.Height, Settings.Width, Settings.Height);
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            DrawGame(e.Graphics);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (!gameOverFlag)
            {
                UpdateGame();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    Settings.directions = "left";
                    break;
                case Keys.Right:
                    Settings.directions = "right";
                    break;
                case Keys.Up:
                    Settings.directions = "up";
                    break;
                case Keys.Down:
                    Settings.directions = "down";
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings.directions = "up";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Settings.directions = "down";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Settings.directions = "left";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Settings.directions = "right";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!gameTimer.Enabled)
            {
                gameTimer.Start();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            gameTimer.Stop();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            gameOverFlag = false;
            score = 0;
            highScore = 0;
            Snake.Clear();
            gameTimer.Stop();
            InitializeGame();
            gameTimer.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }

    public class Settings
    {
        public static int Width { get; } = 16;
        public static int Height { get; } = 16;
        public static string directions { get; set; } = "right";
    }

    public class Circle
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}

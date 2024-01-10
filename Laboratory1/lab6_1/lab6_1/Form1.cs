using System;
using System.Windows.Forms;

namespace lab6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Змінюємо час при кліці на label1
            label1.Text = "Дата: " + DateTime.Now.ToLongDateString();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Змінюємо час при кліці на label2
            label2.Text = "Час: " + DateTime.Now.ToLongTimeString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Оновлюємо час автоматично кожної секунди
            DateTime now = DateTime.Now;
            label1.Text = "Дата: " + now.ToLongDateString();
            label2.Text = "Час: " + now.ToLongTimeString();
        }
    }
}

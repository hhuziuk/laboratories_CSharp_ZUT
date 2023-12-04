using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab08
{
    public partial class Form1 : Form
    {
        private CustomTimer customTimer;

        public Form1()
        {
            InitializeComponent();
            customTimer = new CustomTimer();
            customTimer.timeElapsed += CustomTimer_TimeElapsed;
            customTimer.onError += CustomTimer_OnError;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            customTimer.Start(5000); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            customTimer.Stop();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CustomTimer_TimeElapsed()
        {
            MessageBox.Show("Time Elapsed!");
        }

        private void CustomTimer_OnError(Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
        }
    }
}

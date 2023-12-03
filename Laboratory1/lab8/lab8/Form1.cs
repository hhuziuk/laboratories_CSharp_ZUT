using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab8
{
    public partial class Form1 : Form
    {
        private CustomTimer customTimer;
        public Form1()
        {
            InitializeComponent();
            customTimer = new CustomTimer(10000); 
            customTimer.timeElapsed += CustomTimer_TimeElapsed;
            customTimer.onError += CustomTimer_OnError;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            customTimer.Start();
        }

        private void CustomTimer_TimeElapsed()
        {
            Invoke(new Action(() =>
            {
                textBox1.AppendText("Time Elapsed!\r\n");
            }));
        }

        private void CustomTimer_OnError(Exception ex)
        {
            Invoke(new Action(() =>
            {
                textBox1.AppendText($"Error: {ex.Message}\r\n");
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customTimer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            customTimer.Stop();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            customTimer.Stop();
        }
    }
}

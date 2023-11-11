using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4b_1
{
    public partial class Form1 : Form
    {
        private string currentInput = string.Empty;
        private double result = 0;
        private char lastOperation;
        private double memory = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void AppendToInput(string value)
        {
            currentInput += value;
            textBox1.Text = currentInput;
        }

        private void PerformOperation(char operation)
        {
            if (double.TryParse(currentInput, out double inputNumber))
            {
                switch (lastOperation)
                {
                    case '+':
                        result += inputNumber;
                        break;
                    case '-':
                        result -= inputNumber;
                        break;
                    case '*':
                        result *= inputNumber;
                        break;
                    case '/':
                        if (inputNumber != 0)
                            result /= inputNumber;
                        else
                            MessageBox.Show("Ділення на нуль не дозволено.");
                        break;
                    default:
                        result = inputNumber;
                        break;
                }

                currentInput = string.Empty;
                lastOperation = operation;

                if (operation == '=')
                {
                    textBox1.Text = result.ToString();
                }
            }
            else
            {
                MessageBox.Show("Некоректний ввід.");
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            AppendToInput("1");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AppendToInput("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AppendToInput("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AppendToInput("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AppendToInput("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AppendToInput("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AppendToInput("9");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput) && !currentInput.StartsWith("-"))
            {
                currentInput = "-" + currentInput;
                textBox1.Text = currentInput;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AppendToInput("0");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            AppendToInput(",");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            PerformOperation('+');
        }

        private void button15_Click(object sender, EventArgs e)
        {
            PerformOperation('-');
        }

        private void button16_Click(object sender, EventArgs e)
        {
            PerformOperation('*');
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (double.TryParse(currentInput, out double inputNumber))
            {
                double reciprocal = 1 / inputNumber;
                currentInput = reciprocal.ToString();
                textBox1.Text = currentInput;
            }
            else
            {
                MessageBox.Show("Некоректний ввід.");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (double.TryParse(currentInput, out double inputNumber))
            {
                double square = Math.Pow(inputNumber, 2);
                currentInput = square.ToString();
                textBox1.Text = currentInput;
            }
            else
            {
                MessageBox.Show("Некоректний ввід.");
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (double.TryParse(currentInput, out double inputNumber))
            {
                double squareRoot = Math.Sqrt(inputNumber);
                currentInput = squareRoot.ToString();
                textBox1.Text = currentInput;
            }
            else
            {
                MessageBox.Show("Некоректний ввід.");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            PerformOperation('/');
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (double.TryParse(currentInput, out double inputNumber))
            {
                inputNumber /= 100;
                currentInput = inputNumber.ToString();
                textBox1.Text = currentInput;
            }
            else
            {
                MessageBox.Show("Некоректний ввід.");
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            currentInput = string.Empty;
            textBox1.Text = "0";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            currentInput = string.Empty;
            result = 0;
            lastOperation = '\0';
            textBox1.Text = "0";
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (currentInput.Length > 0)
            {
                currentInput = currentInput.Substring(0, currentInput.Length - 1);
                textBox1.Text = currentInput;
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (double.TryParse(currentInput, out double inputNumber))
            {
                memory = inputNumber;
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (double.TryParse(currentInput, out double inputNumber))
            {
                memory += inputNumber;
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (double.TryParse(currentInput, out double inputNumber))
            {
                memory -= inputNumber;
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            currentInput = memory.ToString();
            textBox1.Text = currentInput;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            memory = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AppendToInput("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AppendToInput("3");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            PerformOperation('=');
            currentInput = result.ToString();
        }
    }
}

using System;
using System.Linq;
using System.Windows.Forms;

namespace lab10
{
    public partial class Form1 : Form
    {
        private InvoiceContext _context;

        public Form1()
        {
            InitializeComponent();
            _context = new InvoiceContext();
            RefreshListBox();

            textBox1.TextChanged += TextBox1_TextChanged;
            textBox2.TextChanged += TextBox2_TextChanged;
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
        }

        private void RefreshListBox()
        {
            // Read and display invoices in the listbox
            listBox1.Items.Clear();
            var invoices = _context.Invoices.ToList();
            foreach (var invoice in invoices)
            {
                listBox1.Items.Add(invoice);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create
            if (!string.IsNullOrEmpty(textBox1.Text) && decimal.TryParse(textBox2.Text, out decimal value))
            {
                var invoice = new Invoice { Number = textBox1.Text, Value = value };
                _context.Invoices.Add(invoice);
                _context.SaveChanges();
                RefreshListBox();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshListBox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Update
            if (listBox1.SelectedIndex != -1)
            {
                var selectedInvoice = (Invoice)listBox1.SelectedItem;

                // Update values based on input in textBox1 and textBox2
                selectedInvoice.Number = textBox1.Text;
                if (decimal.TryParse(textBox2.Text, out decimal updatedValue))
                {
                    selectedInvoice.Value = updatedValue;
                }
                else
                {
                    MessageBox.Show("Invalid value for update.");
                    return;
                }

                _context.SaveChanges();
                RefreshListBox();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Delete
            if (listBox1.SelectedIndex != -1)
            {
                var selectedInvoice = (Invoice)listBox1.SelectedItem;
                _context.Invoices.Remove(selectedInvoice);
                _context.SaveChanges();
                RefreshListBox();
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            // Handle the TextBox1.TextChanged event
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            // Handle the TextBox2.TextChanged event
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle the ListBox1.SelectedIndexChanged event
            if (listBox1.SelectedIndex != -1)
            {
                var selectedInvoice = (Invoice)listBox1.SelectedItem;
                textBox1.Text = selectedInvoice.Number;
                textBox2.Text = selectedInvoice.Value.ToString();
            }
        }
    }
}

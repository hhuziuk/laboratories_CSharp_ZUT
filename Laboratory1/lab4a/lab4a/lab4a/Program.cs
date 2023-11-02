using System;
using System.IO;
using System.Windows.Forms;

namespace lab4a
{
    static class Program
    {
        static TextBox inputTextBox;
        static TextBox outputTextBox;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form form = new Form();
            form.Text = "CSV to HTML Converter";

            Label inputLabel = new Label();
            inputLabel.Text = "Input CSV File:";
            inputLabel.Location = new System.Drawing.Point(10, 20);

            inputTextBox = new TextBox();
            inputTextBox.Location = new System.Drawing.Point(120, 20);
            inputTextBox.Width = 200;

            Button inputFileButton = new Button();
            inputFileButton.Text = "Browse";
            inputFileButton.Location = new System.Drawing.Point(330, 20);
            inputFileButton.Click += new EventHandler(InputFileButton_Click);

            Label outputLabel = new Label();
            outputLabel.Text = "Output HTML File:";
            outputLabel.Location = new System.Drawing.Point(10, 50);

            outputTextBox = new TextBox();
            outputTextBox.Location = new System.Drawing.Point(120, 50);
            outputTextBox.Width = 200;

            Button outputFileButton = new Button();
            outputFileButton.Text = "Browse";
            outputFileButton.Location = new System.Drawing.Point(330, 50);
            outputFileButton.Click += new EventHandler(OutputFileButton_Click);

            Button convertButton = new Button();
            convertButton.Text = "Convert";
            convertButton.Location = new System.Drawing.Point(150, 80);
            convertButton.Click += new EventHandler(ConvertButton_Click);

            form.Controls.Add(inputLabel);
            form.Controls.Add(inputTextBox);
            form.Controls.Add(inputFileButton);
            form.Controls.Add(outputLabel);
            form.Controls.Add(outputTextBox);
            form.Controls.Add(outputFileButton);
            form.Controls.Add(convertButton);

            Application.Run(form);
        }

        private static void InputFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                inputTextBox.Text = openFileDialog.FileName;
                outputTextBox.Text = Path.ChangeExtension(openFileDialog.FileName, "html");
            }
        }

        private static void OutputFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "HTML files (*.html)|*.html|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                outputTextBox.Text = saveFileDialog.FileName;
            }
        }

        private static void ConvertButton_Click(object sender, EventArgs e)
        {
            string csvFilePath = inputTextBox.Text;
            string htmlFilePath = outputTextBox.Text;
            convertCsvToHtml(csvFilePath, htmlFilePath);
        }

        static void convertCsvToHtml(string csvFilePath, string htmlFilePath)
        {
            string[] lines = File.ReadAllLines(csvFilePath);
            using (StreamWriter HTMLFile = new StreamWriter(htmlFilePath))
            {
                HTMLFile.WriteLine("<html>" +
                                   "<head>" +
                                   "<style>\ntable {\n  font-family: arial, sans-serif;\n  border-collapse: collapse;\n  width: 100%;\n}\n\ntd, th {\n  border: 1px solid #dddddd;\n  text-align: left;\n  padding: 8px;\n}\n\ntr:nth-child(even) {\n  background-color: #dddddd;\n}" +
                                   "</style>" +
                                   "<title>CSV to HTML</title>" +
                                   "</head>" +
                                   "<body>" +
                                   "<table border=\"1\">" +
                                   "<tr>");
                string[] headers = lines[0].Split(",");
                foreach (var header in headers)
                {
                    HTMLFile.WriteLine("<th>" + header + "</th>");
                }
                HTMLFile.WriteLine("</tr>");

                for (int i = 1; i < lines.Length; i++)
                {
                    HTMLFile.WriteLine("<tr>");
                    string[] parts = lines[i].Split(",");
                    foreach (var part in parts)
                    {
                        HTMLFile.WriteLine("<td>" + part + "</td>");
                    }
                    HTMLFile.WriteLine("</tr>");
                }

                HTMLFile.WriteLine(
                    "</table>" +
                    "</body>" +
                    "</html>"
                );
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace lab5
{
    public partial class Form1 : Form
    {
        private BindingList<Person> people = new BindingList<Person>();
        private BindingSource bindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            InitializeBindings();
        }

        private void InitializeBindings()
        {
            bindingSource.DataSource = people;
            listBox1.DataSource = bindingSource;
            listBox1.DisplayMember = "FullName";
            comboBox1.Items.AddRange(new[] { "Male", "Female" });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstName = textBox1.Text;
            string lastName = textBox2.Text;
            string birthDate = textBox3.Text;
            string gender = comboBox1.SelectedItem as string;

            if (TryGetPersonFromInput(firstName, lastName, birthDate, gender, out Person newPerson))
            {
                people.Add(newPerson);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;
            if (selectedIndex != -1)
            {
                people.RemoveAt(selectedIndex);
            }
            else
            {
                ShowErrorMessage("Select a person to delete.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;
            if (selectedIndex != -1)
            {
                if (TryGetPersonFromInput(textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.SelectedItem as string, out Person updatedPerson))
                {
                    people[selectedIndex] = updatedPerson;
                }
            }
            else
            {
                ShowErrorMessage("Select a person to update.");
            }
        }

        private bool TryGetPersonFromInput(string firstName, string lastName, string birthDate, string gender, out Person person)
        {
            if (ValidateInput(firstName, lastName, birthDate, gender) && DateTime.TryParse(birthDate, out DateTime birthDateTime))
            {
                person = new Person(firstName, lastName, birthDateTime, gender);
                return true;
            }

            person = null;
            ShowErrorMessage("Invalid input. Please check all fields.");
            return false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;
            if (selectedIndex != -1)
            {
                DisplayPersonData(people[selectedIndex]);
            }
        }

        private void DisplayPersonData(Person person)
        {
            textBox1.Text = person.FirstName;
            textBox2.Text = person.LastName;
            textBox3.Text = person.BirthDate.ToString("yyyy-MM-dd");
            comboBox1.SelectedItem = person.Gender;
        }

        private bool ValidateInput(params string[] values)
        {
            foreach (string value in values)
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    return false;
                }
            }
            return true;
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public class Person
    {
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime BirthDate { get; }
        public string Gender { get; }

        public string FullName => $"{FirstName} {LastName}";

        public Person(string firstName, string lastName, DateTime birthDate, string gender)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Gender = gender;
        }
    }
}

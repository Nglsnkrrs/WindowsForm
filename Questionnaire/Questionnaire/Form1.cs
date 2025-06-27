using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Questionnaire
{
    public partial class Form1 : Form
    {
        private BindingList<User> users = new BindingList<User>();
        private User selectedUser = null;
        private const string DefaultTextFilePath = "users_data.txt";
        private const string DefaultXmlFilePath = "users_data.xml";

        public Form1()
        {
            InitializeComponent();
            listBox_Info.DataSource = users;

        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_Name.Text) ||
                string.IsNullOrWhiteSpace(textBox_Surname.Text) ||
                string.IsNullOrWhiteSpace(textBox_Email.Text) ||
                string.IsNullOrWhiteSpace(textBox_Phone.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены!");
                return;
            }

            Regex regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

            if (!regex.IsMatch(textBox_Email.Text))
            {
                MessageBox.Show("Введите корректный email адрес!");
                return;
            }
            var user = new User
            {
                Name = textBox_Name.Text,
                Surname = textBox_Surname.Text,
                Email = textBox_Email.Text,
                Phone = textBox_Phone.Text
            };

            users.Add(user);
            ClearInputs();

        }
        private void ClearInputs()
        {
            textBox_Name.Clear();
            textBox_Surname.Clear();
            textBox_Email.Clear();
            textBox_Phone.Clear();
        }
        private void listBox_Info_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_Info.SelectedIndex != -1)
            {
                selectedUser = (User)listBox_Info.SelectedItem;
                textBox_Name.Text = selectedUser.Name;
                textBox_Surname.Text = selectedUser.Surname;
                textBox_Email.Text = selectedUser.Email;
                textBox_Phone.Text = selectedUser.Phone;
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (listBox_Info.SelectedIndex != -1)
            {
                users.RemoveAt(listBox_Info.SelectedIndex);
                ClearInputs();
            }
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            if (selectedUser != null)
            {
                selectedUser.Name = textBox_Name.Text;
                selectedUser.Surname = textBox_Surname.Text;
                selectedUser.Email = textBox_Email.Text;
                selectedUser.Phone = textBox_Phone.Text;

                users.ResetItem(listBox_Info.SelectedIndex);
                ClearInputs();
            }
        }

        private void button_ExpotTXT_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(DefaultTextFilePath))
                {
                    foreach (User user in users)
                    {
                        writer.WriteLine($"Name: {user.Name}");
                        writer.WriteLine($"Surname: {user.Surname}");
                        writer.WriteLine($"Email: {user.Email}");
                        writer.WriteLine($"Phone: {user.Phone}");
                        writer.WriteLine(new string('-', 30));
                    }
                }
                MessageBox.Show($"Данные успешно экспортированы в файл: {DefaultTextFilePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте данных: {ex.Message}");
            }

        }

        private void button_ImportTXT_Click(object sender, EventArgs e)
        {
            if (!File.Exists(DefaultTextFilePath))
            {
                MessageBox.Show($"Файл {DefaultTextFilePath} не найден!");
                return;
            }

            try
            {
                users.Clear();
                using (StreamReader reader = new StreamReader(DefaultTextFilePath))
                {
                    User user = new User();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("Name:"))
                            user.Name = line.Substring(5).Trim();
                        else if (line.StartsWith("Surname:"))
                            user.Surname = line.Substring(8).Trim();
                        else if (line.StartsWith("Email:"))
                            user.Email = line.Substring(6).Trim();
                        else if (line.StartsWith("Phone:"))
                            user.Phone = line.Substring(6).Trim();
                        else if (line.StartsWith("---"))
                        {
                            users.Add(user);
                            user = new User();
                        }
                    }
                }
                MessageBox.Show($"Данные успешно импортированы из файла: {DefaultTextFilePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при импорте данных: {ex.Message}");
            }
        }

        private void button_ExpotXML_Click(object sender, EventArgs e)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(BindingList<User>));
                using (FileStream stream = new FileStream(DefaultXmlFilePath, FileMode.Create))
                {
                    serializer.Serialize(stream, users);
                }
                MessageBox.Show($"Данные успешно экспортированы в файл: {DefaultXmlFilePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте данных: {ex.Message}");
            }
        }

        private void button_ImportXML_Click(object sender, EventArgs e)
        {
            if (!File.Exists(DefaultXmlFilePath))
            {
                MessageBox.Show($"Файл {DefaultXmlFilePath} не найден!");
                return;
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(BindingList<User>));
                using (FileStream stream = new FileStream(DefaultXmlFilePath, FileMode.Open))
                {
                    BindingList<User> importedUsers = (BindingList<User>)serializer.Deserialize(stream);
                    users.Clear();
                    foreach (User user in importedUsers)
                    {
                        users.Add(user);
                    }
                }
                MessageBox.Show($"Данные успешно импортированы из файла: {DefaultXmlFilePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при импорте данных: {ex.Message}");
            }
        }
    }
}

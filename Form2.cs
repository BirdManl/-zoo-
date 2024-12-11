using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using АИС_зоопарк;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // Обработчик кнопки входа
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text; // Поле для ввода логина
            string password = textBox2.Text; // Поле для ввода пароля

            // Проверка логина и пароля в базе данных
            if (AuthenticateUser(username, password))
            {
                MessageBox.Show("Вход выполнен успешно!");

                Form nextForm;
                // Проверка, является ли пользователь администратором
                if (username.ToLower() == "admin")
                {
                    // Создаем форму администратора
                    nextForm = new AdminForm();
                }
                else
                {
                    // Создаем форму для обычного пользователя
                    nextForm = new UserForm();
                }

                // Открываем следующую форму и закрываем текущую
                this.Hide(); // Скрываем текущую форму перед открытием новой

                nextForm.ShowDialog(); // Открываем следующую форму как модальное окно
                this.Close(); // Закрываем текущую форму после закрытия новой
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль.");
            }
        }

        // Метод для проверки пользователя в базе данных
        private bool AuthenticateUser(string username, string password)
        {
            string dbPath = @"D:\sqlite\Databases\zoo.db"; // Путь к вашей базе данных
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Запрос для проверки логина и пароля
                    string query = "SELECT COUNT(1) FROM users WHERE username = @username AND password = @password";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        // Подставляем значения параметров
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        // Выполняем запрос
                        int userExists = Convert.ToInt32(command.ExecuteScalar());

                        return userExists > 0; // Если существует, возвращаем true
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при подключении к базе данных: " + ex.Message);
                return false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Этот метод можно оставить пустым, если он не нужен
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Этот метод можно оставить пустым, если он не нужен
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {

        }
    }
}

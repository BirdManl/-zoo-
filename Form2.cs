using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using АИС_зоопарк;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            // Увеличиваем шрифт в текстовых полях
            textBox1.Font = new Font("Arial", 14); // Логин
            textBox2.Font = new Font("Arial", 14); // Пароль
            buttonLogin.BackColor = Color.CornflowerBlue; // Устанавливаем яркий фон кнопки
            buttonLogin.ForeColor = Color.White; // Цвет текста
            buttonLogin.FlatStyle = FlatStyle.Flat; // Убираем объемный стиль
            buttonLogin.Font = new Font("Arial", 14, FontStyle.Bold); // Увеличиваем шрифт и делаем его жирным

            // Добавляем эффект при наведении
            buttonLogin.MouseEnter += (s, e) =>
            {
                buttonLogin.BackColor = Color.DodgerBlue; // Цвет при наведении
            };

            buttonLogin.MouseLeave += (s, e) =>
            {
                buttonLogin.BackColor = Color.CornflowerBlue; // Возвращаем оригинальный цвет
            };
        }

        // Обработчик кнопки входа
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text; // Поле для ввода логина
            string password = textBox2.Text; // Поле для ввода пароля

            // Проверка логина и пароля в базе данных
            if (AuthenticateUser(username, password))
            {
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

                // Скрываем текущую форму
                this.Hide();

                // Открываем следующую форму как модальное окно
                nextForm.ShowDialog();

                // Закрываем текущую форму после закрытия следующей формы
                this.Close();
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
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Пример закругления кнопки
            Rectangle buttonRect = buttonLogin.ClientRectangle;
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(buttonRect.Left, buttonRect.Top, 20, 20, 180, 90);
                path.AddArc(buttonRect.Right - 20, buttonRect.Top, 20, 20, 270, 90);
                path.AddArc(buttonRect.Right - 20, buttonRect.Bottom - 20, 20, 20, 0, 90);
                path.AddArc(buttonRect.Left, buttonRect.Bottom - 20, 20, 20, 90, 90);
                path.CloseFigure();
                buttonLogin.Region = new Region(path);
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

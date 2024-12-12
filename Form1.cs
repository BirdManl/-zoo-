using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace АИС_зоопарк
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Настройка кнопки "Войти как администратор"
            admin.BackColor = Color.DarkBlue; // Фон кнопки
            admin.ForeColor = Color.White;    // Цвет текста
            admin.FlatStyle = FlatStyle.Flat; // Убираем стандартный объемный стиль
            admin.Font = new Font("Arial", 12, FontStyle.Bold); // Настраиваем шрифт

            // Настройка кнопки "Войти как пользователь"
            user.BackColor = Color.DarkGreen; // Фон кнопки
            user.ForeColor = Color.White;     // Цвет текста
            user.FlatStyle = FlatStyle.Flat;  // Убираем стандартный объемный стиль
            user.Font = new Font("Arial", 12, FontStyle.Bold); // Настраиваем шрифт

            // Добавление эффекта при наведении на "Войти как администратор"
            admin.MouseEnter += (s, e) =>
            {
                admin.BackColor = Color.Blue; // Цвет кнопки при наведении
            };
            admin.MouseLeave += (s, e) =>
            {
                admin.BackColor = Color.DarkBlue; // Возвращаем цвет
            };

            // Добавление эффекта при наведении на "Войти как пользователь"
            user.MouseEnter += (s, e) =>
            {
                user.BackColor = Color.Green; // Цвет кнопки при наведении
            };
            user.MouseLeave += (s, e) =>
            {
                user.BackColor = Color.DarkGreen; // Возвращаем цвет
            };
        }

        // Обработчик кнопки "Войти как администратор"
        private void admin_Click(object sender, EventArgs e)
        {
            Form2 adminForm = new Form2(); // Создаем форму для администратора
            adminForm.ShowDialog(); // Открываем форму
        }

        // Обработчик кнопки "Войти как пользователь"
        private void user_Click(object sender, EventArgs e)
        {
            // Создаем и открываем форму пользователя
            UserForm userForm = new UserForm();
            this.Hide(); // Скрываем форму логина
            userForm.ShowDialog(); // Открываем форму пользователя как модальное окно
            this.Show(); // Возвращаем форму логина после закрытия формы пользователя
        }
        // Метод, вызываемый при загрузке формы
        private void Form1_Load(object sender, EventArgs e)
        {
            // Здесь можно добавить логику инициализации формы
        }
    }
}

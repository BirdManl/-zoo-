using System;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace АИС_зоопарк
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
            LoadServices();    // Загружаем доступные услуги
            LoadAnimals();     // Загружаем список животных
            checkedListBoxServices.ItemCheck += checkedListBoxServices_ItemCheck; // Подключаем обработчик выбора
            UpdateTotalCost(); // Инициализируем общую стоимость
        }

        // Метод для загрузки услуг
        private void LoadServices()
        {
            string dbPath = @"D:\sqlite\Databases\zoo.db";
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT [Номер услуги], Название, Цена FROM Услуги";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string serviceName = reader["Название"].ToString();
                            decimal servicePrice = Convert.ToDecimal(reader["Цена"]);
                            checkedListBoxServices.Items.Add(new ServiceItem(serviceName, servicePrice));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке услуг: " + ex.Message);
            }
        }
        private void checkedListBoxServices_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Используем `BeginInvoke`, чтобы дождаться завершения изменения состояния элемента
            BeginInvoke(new Action(UpdateTotalCost));
        }
        // Метод для загрузки животных в ComboBox
        private void LoadAnimals()
        {
            string dbPath = @"D:\sqlite\Databases\zoo.db";
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT [Номер ветеринарной карты], Название FROM Животные";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int animalId = Convert.ToInt32(reader["Номер ветеринарной карты"]);
                            string animalName = reader["Название"].ToString();
                            comboBoxAnimals.Items.Add(new AnimalItem(animalId, animalName));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке животных: " + ex.Message);
            }
        }

        // Вспомогательный класс для хранения данных о животных
        private class AnimalItem
        {
            public int Id { get; }
            public string Name { get; }

            public AnimalItem(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        // Обработчик для кнопки "Узнать информацию о животном"
        private void buttonViewAnimalInfo_Click(object sender, EventArgs e)
        {
            if (comboBoxAnimals.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите животное.");
                return;
            }

            AnimalItem selectedAnimal = (AnimalItem)comboBoxAnimals.SelectedItem;
            string dbPath = @"D:\sqlite\Databases\zoo.db";
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Масса, Высота, Возраст, Пол, [Страна обитания] FROM Животные WHERE [Номер ветеринарной карты] = @animalId";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@animalId", selectedAnimal.Id);
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                decimal weight = reader.GetDecimal(reader.GetOrdinal("Масса"));
                                decimal height = reader.GetDecimal(reader.GetOrdinal("Высота"));
                                int age = reader.GetInt32(reader.GetOrdinal("Возраст"));
                                string gender = reader["Пол"].ToString();
                                string country = reader["Страна обитания"].ToString();

                                // Отображаем информацию в label1
                                labelAnimalInfo.Text = $"Название: {selectedAnimal.Name}\n" +
                                                       $"Масса: {weight} кг\n" +
                                                       $"Высота: {height} см\n" +
                                                       $"Возраст: {age} лет\n" +
                                                       $"Пол: {gender}\n" +
                                                       $"Страна обитания: {country}";
                            }
                            else
                            {
                                labelAnimalInfo.Text = "Информация о животном не найдена.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке информации о животном: " + ex.Message);
            }
        }

        // Вспомогательный класс для хранения данных об услугах
        private class ServiceItem
        {
            public string Name { get; }
            public decimal Price { get; }

            public ServiceItem(string name, decimal price)
            {
                Name = name;
                Price = price;
            }

            public override string ToString()
            {
                return $"{Name} - {Price:C}";
            }
        }

        // Метод для расчета и обновления общей стоимости выбранных услуг
        private void UpdateTotalCost()
        {
            decimal totalCost = 0;

            foreach (var item in checkedListBoxServices.CheckedItems)
            {
                ServiceItem service = (ServiceItem)item;
                totalCost += service.Price;
            }

            labelTotalCost.Text = $"Общая стоимость: {totalCost:C}";
        }

        // Обработчик для кнопки покупки
        private void buttonPurchase_Click(object sender, EventArgs e)
        {
            if (checkedListBoxServices.CheckedItems.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите хотя бы одну услугу.");
                return;
            }

            string selectedServices = string.Join(", ", checkedListBoxServices.CheckedItems.Cast<ServiceItem>().Select(item => item.Name));
            decimal totalCost = checkedListBoxServices.CheckedItems.Cast<ServiceItem>().Sum(item => item.Price);

            string dbPath = @"D:\sqlite\Databases\zoo.db";
            string connectionString = $"Data Source={dbPath};Version=3;";
            string purchaseDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Билеты (Услуги, [Суммарная стоимость], [Дата покупки]) " +
                                   "VALUES (@services, @totalCost, @purchaseDate)";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@services", selectedServices);
                        command.Parameters.AddWithValue("@totalCost", totalCost);
                        command.Parameters.AddWithValue("@purchaseDate", purchaseDate);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Покупка успешно завершена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при завершении покупки: " + ex.Message);
            }
        }
    }
}

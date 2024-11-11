using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace АИС_зоопарк
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            InitializeGenderComboBox();
            LoadWorkers();
        }

        // Метод для инициализации comboBoxGender
        private void InitializeGenderComboBox()
        {
            comboBoxGender.Items.Add("Самец");
            comboBoxGender.Items.Add("Самка");
            comboBoxGender.SelectedIndex = 0;
        }

        // Метод для загрузки списка сотрудников в comboBoxWorker
        private void LoadWorkers()
        {
            comboBoxWorker.Items.Clear();

            string dbPath = @"D:\sqlite\Databases\zoo.db";
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT [ID Работника], ФИО FROM Сотрудники";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string workerName = reader["ФИО"].ToString();
                            int workerId = Convert.ToInt32(reader["ID Работника"]);
                            comboBoxWorker.Items.Add(new ComboBoxItem(workerName, workerId));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке сотрудников: " + ex.Message);
            }
        }

        // Обработчик кнопки добавления животного
        private void buttonAddAnimal_Click(object sender, EventArgs e)
        {
            string name = textBoxAnimalName.Text.Trim();
            string family = textBoxFamily.Text.Trim();
            string species = textBoxSpecies.Text.Trim();
            string country = textBoxCountry.Text.Trim();
            string gender = comboBoxGender.SelectedItem?.ToString();
            string workerId = (comboBoxWorker.SelectedItem as ComboBoxItem)?.Id.ToString();

            int age;
            float weight;
            float height;
            int lifetime;

            // Проверка полей на корректность
            bool ageParsed = int.TryParse(textBoxAge.Text, out age);
            bool weightParsed = float.TryParse(textBoxWeight.Text, out weight);
            bool heightParsed = float.TryParse(textBoxHeight.Text, out height);
            bool lifetimeParsed = int.TryParse(textBoxLifetime.Text, out lifetime);

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(family) || string.IsNullOrWhiteSpace(species) ||
                string.IsNullOrWhiteSpace(country) || string.IsNullOrWhiteSpace(gender) || string.IsNullOrWhiteSpace(workerId) ||
                !ageParsed || !weightParsed || !heightParsed || !lifetimeParsed)
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля в корректном формате. Проверьте, что:\n" +
                                "- Возраст, масса, высота и продолжительность жизни указаны числовыми значениями без единиц измерения.\n" +
                                "- Пол и сотрудник выбраны из выпадающих списков.", "Ошибка ввода данных");
                return;
            }

            try
            {
                AddAnimalToDatabase(name, family, species, age, gender, country, weight, height, lifetime, workerId);
                MessageBox.Show("Новое животное добавлено успешно!");
                ClearAnimalFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении животного: " + ex.Message);
            }
        }

        // Обработчик кнопки добавления сотрудника
        private void buttonAddEmployee_Click(object sender, EventArgs e)
        {
            string name = textBoxEmployeeName.Text;
            int age;
            bool ageParsed = int.TryParse(textBoxEmployeeAge.Text, out age);
            int experience;
            bool experienceParsed = int.TryParse(textBoxEmployeeExperience.Text, out experience);
            decimal salary;
            bool salaryParsed = decimal.TryParse(textBoxEmployeeSalary.Text, out salary);
            string specialty = textBoxEmployeeSpecialty.Text;

            // Проверка на корректность заполнения полей
            if (string.IsNullOrWhiteSpace(name) || !ageParsed || !experienceParsed || !salaryParsed || string.IsNullOrWhiteSpace(specialty))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.");
                return;
            }

            try
            {
                AddEmployeeToDatabase(name, age, experience, salary, specialty);
                MessageBox.Show("Новый сотрудник успешно добавлен!");
                ClearEmployeeFields();
                LoadWorkers(); // Обновляем список сотрудников
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении сотрудника: " + ex.Message);
            }
        }

        // Метод для добавления животного в базу данных
        public static void AddAnimalToDatabase(string name, string family, string species, int age, string gender,
                                               string country, float weight, float height, int lifetime, string workerId)
        {
            string dbPath = @"D:\sqlite\Databases\zoo.db";
            string connectionString = $"Data Source={dbPath};Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Животные (Название, Семейство, Класс, Возраст, Пол, [Страна обитания], Масса, Высота, [Продолжительность жизни], [Сотрудник ответственный за животное]) " +
                               "VALUES (@name, @family, @species, @age, @gender, @country, @weight, @height, @lifetime, @workerId)";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@family", family);
                    command.Parameters.AddWithValue("@species", species);
                    command.Parameters.AddWithValue("@age", age);
                    command.Parameters.AddWithValue("@gender", gender);
                    command.Parameters.AddWithValue("@country", country);
                    command.Parameters.AddWithValue("@weight", weight);
                    command.Parameters.AddWithValue("@height", height);
                    command.Parameters.AddWithValue("@lifetime", lifetime);
                    command.Parameters.AddWithValue("@workerId", workerId);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Метод для добавления сотрудника в базу данных
        public static void AddEmployeeToDatabase(string name, int age, int experience, decimal salary, string specialty)
        {
            string dbPath = @"D:\sqlite\Databases\zoo.db";
            string connectionString = $"Data Source={dbPath};Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Сотрудники (ФИО, Возраст, [Стаж работы], Зарплата, Должность) " +
               "VALUES (@name, @age, @experience, @salary, @specialty)";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@age", age);
                    command.Parameters.AddWithValue("@experience", experience);
                    command.Parameters.AddWithValue("@salary", salary);
                    command.Parameters.AddWithValue("@specialty", specialty);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Очистка полей после добавления животного
        private void ClearAnimalFields()
        {
            textBoxAnimalName.Clear();
            textBoxFamily.Clear();
            textBoxSpecies.Clear();
            textBoxAge.Clear();
            comboBoxGender.SelectedIndex = 0;
            textBoxCountry.Clear();
            textBoxWeight.Clear();
            textBoxHeight.Clear();
            textBoxLifetime.Clear();
            comboBoxWorker.SelectedIndex = -1;
        }

        // Очистка полей после добавления сотрудника
        private void ClearEmployeeFields()
        {
            textBoxEmployeeName.Clear();
            textBoxEmployeeAge.Clear();
            textBoxEmployeeExperience.Clear();
            textBoxEmployeeSalary.Clear();
            textBoxEmployeeSpecialty.Clear();
        }

        // Вспомогательный класс для отображения сотрудников в comboBoxWorker
        private class ComboBoxItem
        {
            public string Name { get; }
            public int Id { get; }

            public ComboBoxItem(string name, int id)
            {
                Name = name;
                Id = id;
            }

            public override string ToString()
            {
                return Name;
            }
        }
    }
}

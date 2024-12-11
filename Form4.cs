using System;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace АИС_зоопарк
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            InitializeGenderComboBox();
            LoadWorkers();
            LoadAnimals();
            LoadEmployees();
            InitializeEnclosureTypeComboBox(); // Инициализация списка для выбора типа вольера
            LoadEnclosures(); // Загрузка данных о вольерах
            LoadServices(); // Вызов метода здесь должен работать, если метод определен внутри класса AdminForm
            LoadTickets(); // Вызываем метод загрузки билетов 
            dataGridViewAnimals.CellEndEdit += dataGridViewAnimals_CellEndEdit;
            LoadArchivedTickets();

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
            comboBoxEnclosureWorker.Items.Clear(); // Очищаем comboBoxEnclosureWorker

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

                            // Создаем объект ComboBoxItem для каждого сотрудника
                            ComboBoxItem workerItem = new ComboBoxItem(workerName, workerId);

                            // Добавляем сотрудника в оба ComboBox
                            comboBoxWorker.Items.Add(workerItem);
                            comboBoxEnclosureWorker.Items.Add(workerItem);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке сотрудников: " + ex.Message);
            }
        }


        // Метод для загрузки данных о животных в DataGridView
        private void LoadAnimals()
        {
            string dbPath = @"D:\sqlite\Databases\zoo.db";
            string connectionString = $"Data Source={dbPath};Version=3;";

            // Очищаем comboBoxEnclosureAnimal перед загрузкой данных
            comboBoxEnclosureAnimal.Items.Clear();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Запрос для загрузки данных о животных
                    string query = "SELECT [Номер ветеринарной карты], Название, Семейство, Класс, Возраст, Пол, [Страна обитания], Масса, Высота, [Продолжительность жизни], [Сотрудник ответственный за животное] FROM Животные";
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridViewAnimals.DataSource = dataTable;
                    }

                    // Загружаем животных в comboBoxEnclosureAnimal
                    string animalQuery = "SELECT [Номер ветеринарной карты], Название FROM Животные";
                    using (SQLiteCommand command = new SQLiteCommand(animalQuery, connection))
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string animalName = reader["Название"].ToString();
                            int animalId = Convert.ToInt32(reader["Номер ветеринарной карты"]);

                            // Добавляем животное в comboBoxEnclosureAnimal с использованием ComboBoxItem
                            comboBoxEnclosureAnimal.Items.Add(new ComboBoxItem(animalName, animalId));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных о животных: " + ex.Message);
            }
        }


        private void InitializeEnclosureTypeComboBox()
        {
            comboBoxEnclosureType.Items.Add("Травоядное");
            comboBoxEnclosureType.Items.Add("Хищник");
            comboBoxEnclosureType.Items.Add("Всеядное");
            comboBoxEnclosureType.SelectedIndex = 0; // Установим первый элемент по умолчанию
        }

        private void ClearServiceFields()
        {
            textBoxServiceName.Clear();
            textBoxServiceDescription.Clear();
            textBoxServicePrice.Clear();
        }


        private void LoadEnclosures()
        {
            string dbPath = @"D:\sqlite\Databases\zoo.db";
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    // Обновленный запрос с учетом правильных имен столбцов
                    string query = "SELECT [Номер вольера], [Вид вольера], [Корм нужный в вольере], [Сотрудник ответственный за вольер], [Животное в вольере] FROM Вольеры";
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridViewEnclosures.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных о вольерах: " + ex.Message);
            }
        }


        // Обработчик события CellEndEdit для сохранения изменений в базе данных после редактирования ячейки
        private void dataGridViewAnimals_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadEmployees()
        {
            string dbPath = @"D:\sqlite\Databases\zoo.db";
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Запрос для заполнения DataGridView
                    string queryForGridView = "SELECT [ID Работника], ФИО, Возраст, [Стаж работы], Зарплата, Должность FROM Сотрудники";
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(queryForGridView, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridViewEmployees.DataSource = dataTable;
                    }

                    // Запрос для загрузки сотрудников в ComboBox
                    string queryForComboBox = "SELECT ФИО FROM Сотрудники";
                    using (SQLiteCommand command = new SQLiteCommand(queryForComboBox, connection))
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        comboBoxEmployee.Items.Clear(); // Очищаем ComboBox перед заполнением

                        while (reader.Read())
                        {
                            comboBoxEmployee.Items.Add(reader["ФИО"].ToString()); // Добавляем ФИО сотрудников
                        }

                        if (comboBoxEmployee.Items.Count > 0)
                        {
                            comboBoxEmployee.SelectedIndex = 0; // Устанавливаем первый элемент по умолчанию
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных о сотрудниках: " + ex.Message);
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
            bool heightParsed = float.TryParse(textBoxLifetime.Text, out height);
            bool lifetimeParsed = int.TryParse(textBoxHeight.Text, out lifetime);

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(family) || string.IsNullOrWhiteSpace(species) ||
                string.IsNullOrWhiteSpace(country) || string.IsNullOrWhiteSpace(gender) || string.IsNullOrWhiteSpace(workerId) ||
                !ageParsed || !weightParsed || !heightParsed || !lifetimeParsed)
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля в корректном формате.");
                return;
            }

            try
            {
                AddAnimalToDatabase(name, family, species, age, gender, country, weight, height, lifetime, workerId);
                MessageBox.Show("Новое животное добавлено успешно!");
                ClearAnimalFields();
                LoadAnimals(); // Обновляем таблицу в DataGridView после добавления
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
                LoadWorkers(); // Обновляем список сотрудников в comboBox
                LoadEmployees(); // Обновляем таблицу сотрудников
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
            textBoxLifetime.Clear();
            textBoxHeight.Clear();
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

        private void buttonDeleteAnimal_Click(object sender, EventArgs e)
        {
            // Проверяем, выбрана ли строка для удаления
            if (dataGridViewAnimals.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите животное для удаления.");
                return;
            }

            // Получаем значение идентификатора из выбранной строки
            var selectedRow = dataGridViewAnimals.SelectedRows[0];
            var animalId = selectedRow.Cells["Номер ветеринарной карты"].Value;

            // Подтверждение удаления
            var confirmResult = MessageBox.Show("Вы уверены, что хотите удалить выбранное животное?",
                                                 "Подтверждение удаления",
                                                 MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
            {
                return;
            }

            string dbPath = @"D:\sqlite\Databases\zoo.db";
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Животные WHERE [Номер ветеринарной карты] = @animalId";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@animalId", animalId);
                        command.ExecuteNonQuery();
                    }
                }

                // Обновляем DataGridView после удаления
                LoadAnimals();
                MessageBox.Show("Животное успешно удалено.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении животного: " + ex.Message);
            }
        }

        private void buttonDeleteEmployee_Click(object sender, EventArgs e)
        {
            // Проверка на выбор строки для удаления
            if (dataGridViewEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите сотрудника для удаления.");
                return;
            }

            // Получаем идентификатор сотрудника из выбранной строки
            var selectedRow = dataGridViewEmployees.SelectedRows[0];
            var employeeId = selectedRow.Cells["ID Работника"].Value;

            // Подтверждение удаления
            var confirmResult = MessageBox.Show("Вы уверены, что хотите удалить выбранного сотрудника?",
                                                 "Подтверждение удаления",
                                                 MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
            {
                return;
            }

            string dbPath = @"D:\sqlite\Databases\zoo.db";
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Сотрудники WHERE [ID Работника] = @employeeId";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@employeeId", employeeId);
                        command.ExecuteNonQuery();
                    }
                }

                // Обновляем таблицу сотрудников после удаления
                LoadEmployees();
                MessageBox.Show("Сотрудник успешно удален.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении сотрудника: " + ex.Message);
            }
        }

        private void LoadServices()
        {
            string dbPath = @"D:\sqlite\Databases\zoo.db";
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT [Номер услуги], Название, Описание, Цена FROM Услуги";
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridViewServices.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных об услугах: " + ex.Message);
            }
        }

        private void buttonAddEnclosure_Click(object sender, EventArgs e)
        {
            string enclosureType = comboBoxEnclosureType.SelectedItem?.ToString();
            string food = textBoxEnclosureFood.Text.Trim();
            string workerId = (comboBoxEnclosureWorker.SelectedItem as ComboBoxItem)?.Id.ToString();
            string animalInEnclosure = (comboBoxEnclosureAnimal.SelectedItem as ComboBoxItem)?.Name;

            if (string.IsNullOrWhiteSpace(enclosureType) || string.IsNullOrWhiteSpace(food) || string.IsNullOrWhiteSpace(workerId) || string.IsNullOrWhiteSpace(animalInEnclosure))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.");
                return;
            }

            string dbPath = @"D:\sqlite\Databases\zoo.db";
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Вольеры ([Вид вольера], [Корм нужный в вольере], [Сотрудник ответственный за вольер], [Животное в вольере]) " +
                                   "VALUES (@enclosureType, @food, @workerId, @animalInEnclosure)";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@enclosureType", enclosureType);
                        command.Parameters.AddWithValue("@food", food);
                        command.Parameters.AddWithValue("@workerId", workerId);
                        command.Parameters.AddWithValue("@animalInEnclosure", animalInEnclosure); // Добавляем животное в запрос

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Новый вольер успешно добавлен!");
                LoadEnclosures(); // Обновляем таблицу вольеров после добавления
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении вольера: " + ex.Message);
            }
        }
        private void LoadTickets()
        {
            string dbPath = @"D:\sqlite\Databases\zoo.db"; // Укажите путь к базе данных
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    // Обновленный SQL-запрос с добавлением столбцов "Имя" и "Фамилия"
                    string query = @"
                SELECT 
                    [ID Билета], 
                    Услуги, 
                    [Суммарная стоимость], 
                    [Дата покупки], 
                    [Сотрудник, выдавший билет],
                    Имя AS 'Имя покупателя',
                    Фамилия AS 'Фамилия покупателя'
                FROM Билеты";

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridViewTickets.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных о билетах: " + ex.Message);
            }
        }

        private void buttonAddService_Click(object sender, EventArgs e)
        {
            string serviceName = textBoxServiceName.Text.Trim();
            string serviceDescription = textBoxServiceDescription.Text.Trim();
            decimal servicePrice;

            if (string.IsNullOrWhiteSpace(serviceName) || string.IsNullOrWhiteSpace(serviceDescription) ||
                !decimal.TryParse(textBoxServicePrice.Text, out servicePrice))
            {
                MessageBox.Show("Пожалуйста, заполните все поля корректно.");
                return;
            }

            string dbPath = @"D:\sqlite\Databases\zoo.db";
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Услуги (Название, Описание, Цена) VALUES (@name, @description, @price)";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", serviceName);
                        command.Parameters.AddWithValue("@description", serviceDescription);
                        command.Parameters.AddWithValue("@price", servicePrice);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Услуга успешно добавлена!");
                LoadServices();       // Обновляем список услуг
                ClearServiceFields(); // Очищаем поля после добавления
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении услуги: " + ex.Message);
            }
        }

        private void buttonDeleteService_Click(object sender, EventArgs e)
        {
            // Проверяем, выбрана ли строка для удаления
            if (dataGridViewServices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите услугу для удаления.");
                return;
            }

            // Получаем ID услуги из выбранной строки
            var selectedRow = dataGridViewServices.SelectedRows[0];
            var serviceId = selectedRow.Cells["Номер услуги"].Value;

            // Подтверждение удаления
            var confirmResult = MessageBox.Show("Вы уверены, что хотите удалить выбранную услугу?",
                                                 "Подтверждение удаления",
                                                 MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
            {
                return;
            }

            string dbPath = @"D:\sqlite\Databases\zoo.db";
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Услуги WHERE [Номер услуги] = @serviceId";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@serviceId", serviceId);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Услуга успешно удалена.");
                LoadServices(); // Обновляем таблицу услуг после удаления
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении услуги: " + ex.Message);
            }
        }
        // Метод для загрузки данных из архива в DataGridView
        private void LoadArchivedTickets()
        {
            string dbPath = @"D:\sqlite\Databases\zoo.db"; // Убедитесь, что путь правильный
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT [ID Билета], Услуги, [Суммарная стоимость], [Дата покупки], Имя, Фамилия, [Дата удаления] FROM Архив";

                    using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        // Проверка: если DataTable пустая
                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Нет данных в архиве.");
                        }

                        // Привязываем данные к DataGridView
                        dataGridViewArchive.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных из архива: " + ex.Message);
            }
        }




        private void buttonDeleteTicket_Click(object sender, EventArgs e)
        {
            // Проверяем, выбрана ли строка для удаления
            if (dataGridViewTickets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите билет для удаления.");
                return;
            }

            // Получаем ID билета из выбранной строки
            var selectedRow = dataGridViewTickets.SelectedRows[0];
            var ticketId = selectedRow.Cells["ID Билета"].Value;

            // Подтверждение удаления
            var confirmResult = MessageBox.Show("Вы уверены, что хотите удалить выбранный билет? Билет будет перемещен в архив.",
                                                 "Подтверждение удаления",
                                                 MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
            {
                return;
            }

            string dbPath = @"D:\sqlite\Databases\zoo.db";
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Запрос для копирования данных в архив
                    string queryArchive = "INSERT INTO Архив ([ID Билета], Услуги, [Суммарная стоимость], [Дата покупки], Имя, Фамилия, [Дата удаления]) " +
                                          "SELECT [ID Билета], Услуги, [Суммарная стоимость], [Дата покупки], Имя, Фамилия, CURRENT_TIMESTAMP " +
                                          "FROM Билеты WHERE [ID Билета] = @ticketId";

                    using (SQLiteCommand commandArchive = new SQLiteCommand(queryArchive, connection))
                    {
                        commandArchive.Parameters.AddWithValue("@ticketId", ticketId);
                        commandArchive.ExecuteNonQuery(); // Копируем запись в архив
                    }

                    // Запрос для удаления билета из таблицы Билеты
                    string queryDelete = "DELETE FROM Билеты WHERE [ID Билета] = @ticketId";

                    using (SQLiteCommand commandDelete = new SQLiteCommand(queryDelete, connection))
                    {
                        commandDelete.Parameters.AddWithValue("@ticketId", ticketId);
                        commandDelete.ExecuteNonQuery(); // Удаляем билет
                    }
                }

                MessageBox.Show("Билет успешно перемещен в архив и удален из таблицы.");

                // Обновляем таблицу билетов и таблицу архива
                LoadTickets();          // Обновляем таблицу билетов
                LoadArchivedTickets();  // Обновляем таблицу архива
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении билета: " + ex.Message);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim(); // Получаем текст из текстового поля

            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Введите название животного для поиска!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dbPath = @"D:\sqlite\Databases\zoo.db"; // Укажите путь к базе данных
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // SQL-запрос с COLLATE NOCASE для игнорирования регистра
                    string query = @"
                SELECT *
                FROM Животные
                WHERE Название LIKE @searchTerm COLLATE NOCASE";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        // Добавляем параметр поиска
                        command.Parameters.AddWithValue("@searchTerm", $"%{searchTerm}%");

                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                        DataTable results = new DataTable();
                        adapter.Fill(results);

                        // Обновляем DataGridView с результатами
                        dataGridViewAnimals.DataSource = results;

                        if (results.Rows.Count == 0)
                        {
                            MessageBox.Show("Животное с таким названием не найдено.", "Результаты поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewAnimals.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите строку в таблице!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем выбранную строку
            DataGridViewRow selectedRow = dataGridViewAnimals.SelectedRows[0];

            // Заполняем текстовые поля данными из выбранной строки
            textBoxAnimalName.Text = selectedRow.Cells["Название"].Value?.ToString() ?? "";
            textBoxFamily.Text = selectedRow.Cells["Семейство"].Value?.ToString() ?? "";
            textBoxSpecies.Text = selectedRow.Cells["Класс"].Value?.ToString() ?? "";
            textBoxAge.Text = selectedRow.Cells["Возраст"].Value?.ToString() ?? "";
            textBoxCountry.Text = selectedRow.Cells["Страна обитания"].Value?.ToString() ?? "";
            textBoxWeight.Text = selectedRow.Cells["Масса"].Value?.ToString() ?? "";
            textBoxHeight.Text = selectedRow.Cells["Высота"].Value?.ToString() ?? "";
            textBoxLifetime.Text = selectedRow.Cells["Продолжительность жизни"].Value?.ToString() ?? "";
        }
        private void RefreshDataGridView()
        {
            string dbPath = @"D:\sqlite\Databases\zoo.db"; // Путь к базе данных
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Запрос для загрузки данных
                    string query = "SELECT * FROM Животные";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                        DataTable results = new DataTable();
                        adapter.Fill(results);

                        // Обновляем DataGridView
                        dataGridViewAnimals.DataSource = results;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении таблицы: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            if (dataGridViewAnimals.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите строку для изменения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем ID записи из выбранной строки
            DataGridViewRow selectedRow = dataGridViewAnimals.SelectedRows[0];
            int id = Convert.ToInt32(selectedRow.Cells["Номер ветеринарной карты"].Value); // Предполагается, что это первичный ключ

            // Проверка на заполненность текстовых полей
            if (string.IsNullOrEmpty(textBoxAnimalName.Text) || string.IsNullOrEmpty(textBoxFamily.Text) ||
                string.IsNullOrEmpty(textBoxSpecies.Text) || string.IsNullOrEmpty(textBoxAge.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dbPath = @"D:\sqlite\Databases\zoo.db"; // Укажите путь к базе данных
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Обновляем запись в базе данных
                    string query = @"
                UPDATE Животные
                SET Название = @name,
                    Семейство = @family,
                    Класс = @species,
                    Возраст = @age,
                    [Страна обитания] = @country,
                    Масса = @weight,
                    Высота = @height,
                    [Продолжительность жизни] = @lifetime
                WHERE [Номер ветеринарной карты] = @id";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", textBoxAnimalName.Text);
                        command.Parameters.AddWithValue("@family", textBoxFamily.Text);
                        command.Parameters.AddWithValue("@species", textBoxSpecies.Text);
                        command.Parameters.AddWithValue("@age", Convert.ToInt32(textBoxAge.Text));
                        command.Parameters.AddWithValue("@country", textBoxCountry.Text);
                        command.Parameters.AddWithValue("@weight", Convert.ToDouble(textBoxWeight.Text));
                        command.Parameters.AddWithValue("@height", Convert.ToDouble(textBoxHeight.Text));
                        command.Parameters.AddWithValue("@lifetime", Convert.ToInt32(textBoxLifetime.Text));
                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                    }
                }

                // Обновляем DataGridView после изменений
                MessageBox.Show("Изменения успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении изменений: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetSearch_Click(object sender, EventArgs e)
        {
            string dbPath = @"D:\sqlite\Databases\zoo.db"; // Укажите путь к вашей базе данных
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // SQL-запрос для загрузки всех данных
                    string query = "SELECT * FROM Животные";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                        DataTable results = new DataTable();
                        adapter.Fill(results);

                        // Обновляем DataGridView с полным набором данных
                        dataGridViewAnimals.DataSource = results;
                    }
                }

                // Очищаем текстовое поле поиска (если используется)
                txtSearch.Text = "";

                MessageBox.Show("Поиск сброшен. Отображена полная таблица.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сбросе поиска: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonEditEmployee_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewEmployees.SelectedRows[0];

                try
                {
                    // Перенос данных из выбранной строки в текстбоксы
                    textBoxEmployeeName.Text = selectedRow.Cells["ФИО"].Value?.ToString() ?? "";
                    textBoxEmployeeAge.Text = selectedRow.Cells["Возраст"].Value?.ToString() ?? "";
                    textBoxEmployeeExperience.Text = selectedRow.Cells["Стаж работы"].Value?.ToString() ?? "";
                    textBoxEmployeeSalary.Text = selectedRow.Cells["Зарплата"].Value?.ToString() ?? "";
                    textBoxEmployeeSpecialty.Text = selectedRow.Cells["Должность"].Value?.ToString() ?? "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке данных сотрудника: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите сотрудника для изменения данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewEmployees.SelectedRows[0];

                try
                {
                    // Обновление данных в DataGridView
                    selectedRow.Cells["ФИО"].Value = textBoxEmployeeName.Text;
                    selectedRow.Cells["Возраст"].Value = textBoxEmployeeAge.Text;
                    selectedRow.Cells["Стаж работы"].Value = textBoxEmployeeExperience.Text;
                    selectedRow.Cells["Зарплата"].Value = textBoxEmployeeSalary.Text;
                    selectedRow.Cells["Должность"].Value = textBoxEmployeeSpecialty.Text;

                    // Сообщение об успешном обновлении
                    MessageBox.Show("Данные сотрудника успешно обновлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите сотрудника для сохранения изменений.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void buttonSearchEmploye_Click(object sender, EventArgs e)
        {
            // Получаем введённую фамилию из текстового поля
            string lastName = textBoxSearch.Text.Trim();

            if (string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("Введите фамилию для поиска!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Создаем новую таблицу, в которой будут только найденные сотрудники
            DataTable filteredTable = new DataTable();

            // Копируем структуру исходной таблицы DataGridView
            foreach (DataGridViewColumn column in dataGridViewEmployees.Columns)
            {
                filteredTable.Columns.Add(column.Name, column.ValueType);
            }

            // Проходим по всем строкам DataGridView
            foreach (DataGridViewRow row in dataGridViewEmployees.Rows)
            {
                if (row.Cells["ФИО"].Value != null)
                {
                    string fullName = row.Cells["ФИО"].Value.ToString().Trim();

                    // Проверяем, совпадает ли фамилия (первая часть ФИО)
                    string[] fullNameParts = fullName.Split(' '); // Разделяем ФИО на части
                    if (fullNameParts.Length > 0 && fullNameParts[0].Equals(lastName, StringComparison.OrdinalIgnoreCase))
                    {
                        // Если совпадает, добавляем строку в новую таблицу
                        DataRow newRow = filteredTable.NewRow();
                        for (int i = 0; i < dataGridViewEmployees.Columns.Count; i++)
                        {
                            newRow[i] = row.Cells[i].Value;
                        }
                        filteredTable.Rows.Add(newRow);
                    }
                }
            }

            // Если нашлись подходящие строки, обновляем DataGridView
            if (filteredTable.Rows.Count > 0)
            {
                dataGridViewEmployees.DataSource = filteredTable;
            }
            else
            {
                MessageBox.Show("Сотрудники с такой фамилией не найдены.", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Если ничего не найдено, очищаем DataGridView
                dataGridViewEmployees.DataSource = null;
            }
        }

        private void ResetEmployeeSearch_Click(object sender, EventArgs e)
        {
            string dbPath = @"D:\sqlite\Databases\zoo.db"; // Укажите путь к вашей базе данных
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // SQL-запрос для загрузки всех данных из таблицы сотрудников
                    string query = "SELECT * FROM Сотрудники";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                        DataTable results = new DataTable();
                        adapter.Fill(results);

                        // Обновляем DataGridView с полным набором данных
                        dataGridViewEmployees.DataSource = results;
                    }
                }

                // Очищаем текстовое поле поиска (если используется)
                textBoxSearch.Text = "";

                MessageBox.Show("Поиск сброшен. Отображена полная таблица сотрудников.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сбросе поиска: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonFinishEditing_Click(object sender, EventArgs e)
        {
            {
                if (comboBoxEmployee.SelectedItem != null)
                {
                    string selectedEmployee = comboBoxEmployee.SelectedItem.ToString();
                    MessageBox.Show("Выбранный сотрудник: " + selectedEmployee);

                    // Используйте selectedEmployee для дальнейших действий (например, сохранение в базу)
                }
                else
                {
                    MessageBox.Show("Выберите сотрудника.");
                }
            }
        }

        private void dataGridViewTickets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Проверка на допустимый индекс строки
            {
                DataGridViewRow row = dataGridViewTickets.Rows[e.RowIndex];

                // Перенос данных в текстовые поля
                txtServices.Text = row.Cells["Услуги"]?.Value?.ToString();
                txtTotalCost.Text = row.Cells["Суммарная стоимость"]?.Value?.ToString();
                txtPurchaseDate.Text = row.Cells["Дата покупки"]?.Value?.ToString();
                txtFirstName.Text = row.Cells["Имя Покупателя"]?.Value?.ToString(); // Проверка на пустое значение
                txtLastName.Text = row.Cells["Фамилия Покупателя"]?.Value?.ToString();

                // Установка значения ComboBox для сотрудника
                string employee = row.Cells["Сотрудник, выдавший билет"]?.Value?.ToString();
                if (!string.IsNullOrEmpty(employee))
                {
                    foreach (var item in comboBoxEmployee.Items)
                    {
                        if (item.ToString() == employee)
                        {
                            comboBoxEmployee.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
        }

        private void SearchByDate_Click(object sender, EventArgs e)
        {
            string searchDate = txtSearchDate.Text.Trim(); // Получаем введенное число

            if (string.IsNullOrWhiteSpace(searchDate))
            {
                MessageBox.Show("Пожалуйста, введите число для поиска.");
                return;
            }

            string dbPath = @"D:\sqlite\Databases\zoo.db";
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // SQL-запрос для поиска по числу в дате
                    string query = "SELECT [ID Билета], Услуги, [Суммарная стоимость], [Дата покупки], [Сотрудник, выдавший билет], [Имя], [Фамилия] " +
                                   "FROM Билеты WHERE strftime('%d', [Дата покупки]) = @day";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        // Добавляем параметр числа
                        command.Parameters.AddWithValue("@day", searchDate.PadLeft(2, '0')); // Добавляем ведущий ноль, если число меньше 10

                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Отображаем результаты в DataGridView
                            dataGridViewTickets.DataSource = dataTable;

                            if (dataTable.Rows.Count == 0)
                            {
                                MessageBox.Show("Билеты на указанное число не найдены.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при поиске: " + ex.Message);
            }
        }
        private void ClearInputFields()
        {
            txtServices.Text = string.Empty;
            txtTotalCost.Text = string.Empty;
            txtPurchaseDate.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
        }

        private void buttonCreateTicket_Click(object sender, EventArgs e)
        {
            // Получаем данные из текстовых полей
            string services = txtServices.Text.Trim();
            string totalCost = txtTotalCost.Text.Trim();
            string purchaseDate = txtPurchaseDate.Text.Trim();
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();

            // Проверяем, что все необходимые поля заполнены
            if (string.IsNullOrWhiteSpace(services) ||
                string.IsNullOrWhiteSpace(totalCost) ||
                string.IsNullOrWhiteSpace(purchaseDate) ||
                string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Пожалуйста, заполните все поля для создания билета.");
                return;
            }

            string dbPath = @"D:\sqlite\Databases\zoo.db";
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // SQL-запрос для вставки нового билета
                    string query = "INSERT INTO Билеты (Услуги, [Суммарная стоимость], [Дата покупки], Имя, Фамилия) " +
                                   "VALUES (@services, @totalCost, @purchaseDate, @firstName, @lastName)";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        // Передаем параметры в запрос
                        command.Parameters.AddWithValue("@services", services);
                        command.Parameters.AddWithValue("@totalCost", totalCost);
                        command.Parameters.AddWithValue("@purchaseDate", purchaseDate);
                        command.Parameters.AddWithValue("@firstName", firstName);
                        command.Parameters.AddWithValue("@lastName", lastName);

                        // Выполняем запрос
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Билет успешно создан!");
                            ClearInputFields(); // Очистка текстовых полей
                        }
                        else
                        {
                            MessageBox.Show("Не удалось создать билет. Попробуйте еще раз.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании билета: " + ex.Message);
            }
        }

        private void btnSearchAnimal_Click(object sender, EventArgs e)
        {
            string searchAnimal = txtSearchAnimal.Text.Trim(); // Получаем введенное имя животного

            if (string.IsNullOrWhiteSpace(searchAnimal))
            {
                MessageBox.Show("Пожалуйста, введите имя животного для поиска.");
                return;
            }

            string dbPath = @"D:\sqlite\Databases\zoo.db";
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // SQL-запрос для поиска по имени животного
                    string query = "SELECT [Номер вольера], [Вид вольера], [Корм нужный в вольере], " +
                                   "[Сотрудник ответственный за вольер], [Животное в вольере] " +
                                   "FROM Вольеры WHERE [Животное в вольере] LIKE @animal";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        // Используем LIKE для поиска совпадений
                        command.Parameters.AddWithValue("@animal", "%" + searchAnimal + "%");

                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Отображаем результаты в DataGridView
                            dataGridViewEnclosures.DataSource = dataTable;

                            if (dataTable.Rows.Count == 0)
                            {
                                MessageBox.Show("Вольеры с указанным животным не найдены.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при поиске: " + ex.Message);
            }
        }

        private void buttonResetFilters_Click(object sender, EventArgs e)
        {
            string dbPath = @"D:\sqlite\Databases\zoo.db";
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // SQL-запрос для загрузки всех данных
                    string query = "SELECT [Номер вольера], [Вид вольера], [Корм нужный в вольере], " +
                                   "[Сотрудник ответственный за вольер], [Животное в вольере] " +
                                   "FROM Вольеры";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Отображаем все данные в DataGridView
                            dataGridViewEnclosures.DataSource = dataTable;
                        }
                    }
                }

                // Очищаем поле поиска
                txtSearchAnimal.Text = string.Empty;

                MessageBox.Show("Фильтр сброшен, отображены все данные.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сбросе фильтра: " + ex.Message);
            }
        }

        private void buttonreset_Click(object sender, EventArgs e)
        {
            string dbPath = @"D:\sqlite\Databases\zoo.db";
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // SQL-запрос для загрузки всех билетов
                    string query = "SELECT [ID Билета], Услуги, [Суммарная стоимость], [Дата покупки], " +
                                   "[Сотрудник, выдавший билет], Имя, Фамилия " +
                                   "FROM Билеты";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Отображаем все данные в DataGridView
                            dataGridViewTickets.DataSource = dataTable;
                        }
                    }
                }

                // Очищаем поле поиска
                txtSearchDate.Text = string.Empty;

                MessageBox.Show("Фильтр сброшен, отображены все данные.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сбросе фильтра: " + ex.Message);
            }
        }

        private void buttonRefreshArchive_Click(object sender, EventArgs e)
        {
            LoadArchivedTickets(); // Обновляем архив
        }




        private void buttonPoisk_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName1.Text.Trim();
            string lastName = txtLastName1.Text.Trim();

            // Проверка, что поля не пустые
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("Введите имя и фамилию для поиска.");
                return;
            }

            // Проверка, что введены только буквы
            if (!IsValidName(firstName) || !IsValidName(lastName))
            {
                MessageBox.Show("Имя и фамилия могут содержать только буквы.");
                return;
            }

            decimal totalSpent = 0;
            int visitCount = 0;

            foreach (DataGridViewRow row in dataGridViewTickets.Rows)
            {
                if (row.Cells["Имя Покупателя"].Value != null && row.Cells["Фамилия Покупателя"].Value != null)
                {
                    string rowFirstName = row.Cells["Имя Покупателя"].Value.ToString();
                    string rowLastName = row.Cells["Фамилия Покупателя"].Value.ToString();

                    if (rowFirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                        rowLastName.Equals(lastName, StringComparison.OrdinalIgnoreCase))
                    {
                        visitCount++;
                        if (decimal.TryParse(row.Cells["Суммарная стоимость"].Value?.ToString(), out decimal cost))
                        {
                            totalSpent += cost;
                        }
                    }
                }
            }

            lblResults.Text = $"Посещений: {visitCount}, Потрачено: {totalSpent:C}";
        }

        // Проверка корректности имени (только буквы)
        private bool IsValidName(string name)
        {
            foreach (char c in name)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                {
                    return false;
                }
            }
            return true;
        }

        private void buttonEditData_Click(object sender, EventArgs e)
        {
            // Проверяем, что хотя бы одна строка выбрана в DataGridView
            if (dataGridViewServices.SelectedRows.Count > 0)
            {
                // Получаем выбранную строку
                DataGridViewRow selectedRow = dataGridViewServices.SelectedRows[0];

                // Заполняем текстовые поля данными из выбранной строки
                textBoxServiceName.Text = selectedRow.Cells["Название"].Value?.ToString();
                textBoxServiceDescription.Text = selectedRow.Cells["Описание"].Value?.ToString();
                textBoxServicePrice.Text = selectedRow.Cells["Цена"].Value?.ToString();
            }
            else
            {
                // Если строка не выбрана, показываем сообщение
                MessageBox.Show("Пожалуйста, выберите строку для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void LoadData()
        {
            string dbPath = @"D:\sqlite\Databases\zoo.db";  // Путь к вашей базе данных
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Запрос для получения всех данных из таблицы Услуги
                    string query = "SELECT [Номер услуги], [Название], [Описание], [Цена] FROM [Услуги]";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Привязываем полученные данные к DataGridView
                        dataGridViewServices.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при работе с базой данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button1save_Click(object sender, EventArgs e)
        {
            // Проверяем, что строка выбрана в DataGridView
            if (dataGridViewServices.SelectedRows.Count > 0)
            {
                // Получаем выбранную строку
                DataGridViewRow selectedRow = dataGridViewServices.SelectedRows[0];

                // Проверка на пустые значения в текстовых полях
                if (string.IsNullOrEmpty(textBoxServiceName.Text) ||
                    string.IsNullOrEmpty(textBoxServiceDescription.Text) ||
                    string.IsNullOrEmpty(textBoxServicePrice.Text))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Проверка на корректность цены
                if (!decimal.TryParse(textBoxServicePrice.Text, out decimal price))
                {
                    MessageBox.Show("Введите корректную цену.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Обновляем данные в строке DataGridView
                selectedRow.Cells["Название"].Value = textBoxServiceName.Text;
                selectedRow.Cells["Описание"].Value = textBoxServiceDescription.Text;
                selectedRow.Cells["Цена"].Value = price;

                // Получаем Номер услуги из выбранной строки
                int id = Convert.ToInt32(selectedRow.Cells["Номер услуги"].Value);

                // Путь к базе данных SQLite
                string dbPath = @"D:\sqlite\Databases\zoo.db";  // Путь к базе данных
                string connectionString = $"Data Source={dbPath};Version=3;";

                try
                {
                    // Обновляем запись в базе данных
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();

                        // Запрос для обновления данных в таблице Услуги
                        string query = @"
            UPDATE [Услуги]
            SET [Название] = @name,
                [Описание] = @description,
                [Цена] = @price
            WHERE [Номер услуги] = @id"; // Используем столбец "Номер услуги" для уникальной идентификации записи

                        using (SQLiteCommand command = new SQLiteCommand(query, connection))
                        {
                            // Добавляем параметры для запроса
                            command.Parameters.AddWithValue("@name", textBoxServiceName.Text);
                            command.Parameters.AddWithValue("@description", textBoxServiceDescription.Text);
                            command.Parameters.AddWithValue("@price", price);
                            command.Parameters.AddWithValue("@id", id);  // Номер услуги из выбранной строки

                            // Выполняем запрос
                            command.ExecuteNonQuery();
                        }
                    }

                    // Сообщение об успешном обновлении
                    MessageBox.Show("Данные успешно обновлены в базе данных!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Обновляем данные в DataGridView
                    LoadData(); // Загружаем актуальные данные из базы данных
                }
                catch (Exception ex)
                {
                    // В случае ошибки
                    MessageBox.Show($"Ошибка при обновлении базы данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Если строка не выбрана
                MessageBox.Show("Выберите строку для изменения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
    




















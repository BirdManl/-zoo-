using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace АИС_зоопарк
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();

            // Инициализация ComboBox и загрузка данных
            
            InitializeGenderComboBox();
            LoadWorkers();
            LoadAnimals();
            LoadEmployees();
            InitializeEnclosureTypeComboBox();
            LoadEnclosures();
            LoadServices();
            LoadTickets();
            LoadArchivedTickets();
            LoadPositions();
            dataGridViewEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            comboBoxEnclosureType.DropDownStyle = ComboBoxStyle.DropDownList;
            textBoxAnimalName.KeyPress += textBoxAnimalName_KeyPress;
            textBoxAge.KeyPress += textBoxAge_KeyPress;
            textBoxCountry.KeyPress += textBoxCountry_KeyPress;
            textBoxEmployeeName.KeyPress += textBoxEmployeeName_KeyPress;
            txtSearchDay.KeyPress += txtSearchDate_KeyPress;
            textBoxWeight.KeyPress += textBoxWeight_KeyPress;
            textBoxHeight.KeyPress += textBoxHeight_KeyPress;
            textBoxLifetime.KeyPress += textBoxLifetime_KeyPress;
            txtFirstName.KeyPress += txtFirstName_KeyPress;
            txtLastName.KeyPress += txtLastName_KeyPress;
            textBoxEmployeeAge.KeyPress += textBoxEmployeeAge_KeyPress;
            textBoxEnclosureFood.KeyPress += textBoxEnclosureFood_KeyPress;
            textBoxEmployeeExperience.KeyPress += textBoxEmployeeExperience_KeyPress;
            dataGridViewEnclosures.SelectionChanged += dataGridViewEnclosures_SelectionChanged;
            dataGridViewServices.SelectionChanged += dataGridViewServices_SelectionChanged;
            textBoxEmployeeSalary.KeyPress += textBoxEmployeeSalary_KeyPress;
            this.Load += Form_Load;

            // Инициализация семейства
            textBoxFamily.Items.AddRange(familyToClassesMap.Keys.ToArray());
            if (textBoxFamily.Items.Count > 0)
            {
                isUpdating = true;
                textBoxFamily.SelectedIndex = 0;
                isUpdating = false;
            }

            // Привязка событий
            textBoxFamily.SelectedIndexChanged += textBoxFamily_SelectedIndexChanged;
            textBoxSpecies.SelectedIndexChanged += textBoxSpecies_SelectedIndexChanged;
            dataGridViewAnimals.CellEndEdit += dataGridViewAnimals_CellEndEdit;
        }

        private void ButtonFinishEditing_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            // Заполняем ComboBox "Семейство" (textBoxFamily)
            if (textBoxFamily != null)
            {
                textBoxFamily.Items.Clear();
                textBoxFamily.Items.AddRange(new string[]
                {
            "Кошачьи",
            "Собачьи",
            "Грызуновые",
            "Приматы",
            "Парнокопытные",
            "Птицы",
            "Рептилии",
            "Рыбы",
            "Насекомые",
            "Млекопитающие",
            "Земноводные",
            "Членистоногие"
                });

                if (textBoxFamily.Items.Count > 0)
                {
                    textBoxFamily.SelectedIndex = 0; // Устанавливаем первый элемент
                }
            }

            // Заполняем ComboBox "Класс" (textBoxSpecies)
            if (textBoxSpecies != null)
            {
                textBoxSpecies.Items.Clear();
                textBoxSpecies.Items.AddRange(new string[]
                {
            "Белый тигр",
            "Лев обычный",
            "Амурский тигр",
            "Императорский пингвин",
            "Канадский волк",
            "Горная горилла",
            "Алый ара",
            "Фламинго",
            "Крокодил нильский",
            "Игуана зелёная",
            "Белый медведь",
            "Гигантская панда"
                });

                if (textBoxSpecies.Items.Count > 0)
                {
                    textBoxSpecies.SelectedIndex = 0; // Устанавливаем первый элемент
                }
            }

            // Привязываем обработчики событий
            textBoxFamily.SelectedIndexChanged += textBoxFamily_SelectedIndexChanged;
            textBoxSpecies.SelectedIndexChanged += textBoxSpecies_SelectedIndexChanged;
        }


        // Метод для инициализации ComboBox для пола
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
        private void textBoxWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Блокируем все, кроме цифр и Backspace
            }
        }
        private void textBoxEmployeeSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Блокируем все, кроме цифр и Backspace
            }
        }
        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только буквы, пробелы и Backspace
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Блокируем ввод
            }
        }
        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только буквы, пробелы и Backspace
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Блокируем ввод
            }
        }
        private void textBoxEmployeeAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры и Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Блокируем ввод
            }

            // Ограничение по длине (максимум 2 символа)
            if (textBoxAge.Text.Length >= 2 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        private void textBoxEmployeeName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только буквы, пробелы и Backspace
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Блокируем ввод
            }
        }
        private void textBoxEnclosureFood_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || !char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Блокируем ввод
            }
        }
        private void textBoxEmployeeExperience_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры и Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Блокируем ввод
            }
        }
        private void textBoxHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Блокируем все, кроме цифр и Backspace
            }
        }
        private void textBoxCountry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || !char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Блокируем ввод
            }
        }
        private void textBoxLifetime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Блокируем все, кроме цифр и Backspace
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

                    // Обновленный запрос с правильным названием колонки
                    string query = @"
                SELECT 
                    Животные.[Номер ветеринарной карты], 
                    Животные.[Кличка], 
                    Животные.[Семейство], 
                    Животные.[Класс], 
                    Животные.[Возраст], 
                    Животные.[Пол], 
                    Животные.[Страна обитания], 
                    Животные.[Масса], 
                    Животные.[Высота], 
                    Животные.[Продолжительность жизни], 
                    Сотрудники.[ФИО] AS 'Сотрудник ответственный за животное'
                FROM 
                    Животные
                LEFT JOIN 
                    Сотрудники
                ON 
                    Животные.[Сотрудник ответственный за животное] = Сотрудники.[ID Работника]";

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Добавляем колонку с порядковыми номерами
                        dataTable.Columns.Add("№", typeof(int)).SetOrdinal(0);
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            dataTable.Rows[i]["№"] = i + 1; // Порядковый номер строки
                        }

                        dataGridViewAnimals.DataSource = dataTable;

                        // Скрываем колонку с первичным ключом
                        if (dataGridViewAnimals.Columns.Contains("Номер ветеринарной карты"))
                        {
                            dataGridViewAnimals.Columns["Номер ветеринарной карты"].Visible = false;
                        }
                    }

                    // Загружаем животных в comboBoxEnclosureAnimal
                    string animalQuery = "SELECT Кличка FROM Животные";
                    using (SQLiteCommand command = new SQLiteCommand(animalQuery, connection))
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        int index = 1;
                        while (reader.Read())
                        {
                            string animalName = reader["Кличка"].ToString();

                            // Добавляем животное в comboBoxEnclosureAnimal
                            comboBoxEnclosureAnimal.Items.Add(new ComboBoxItem(animalName, index++));
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
            comboBoxEnclosureType.Items.Clear();
            comboBoxEnclosureType.Items.AddRange(enclosureTypeToAllowedClasses.Keys.ToArray());
        }

        private Dictionary<string, List<string>> enclosureTypeToAllowedClasses = new Dictionary<string, List<string>>()
{
    { "Хищник", new List<string> { "Кошачьи", "Собачьи", "Рептилии" } },
    { "Травоядное", new List<string> { "Парнокопытные", "Грызуновые" } },
    { "Птицы", new List<string> { "Птицы" } },
    { "Рыбы", new List<string> { "Рыбы" } },
    { "Земноводные", new List<string> { "Земноводные" } },
    { "Насекомые", new List<string> { "Насекомые" } },
    { "Членистоногие", new List<string> { "Членистоногие" } },
    { "Приматы", new List<string> { "Приматы" } },
    { "Млекопитающие", new List<string> { "Млекопитающие" } },
};

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
                    // SQL-запрос включает "Номер вольера", но он будет скрыт в DataGridView
                    string query = @"
                SELECT 
                    [Номер вольера] AS 'Номер вольера', 
                    [Вид_вольера] AS 'Вид вольера', 
                    [Корм нужный в вольере] AS 'Корм', 
                    (SELECT ФИО FROM Сотрудники WHERE [ID Работника] = Вольеры.[Сотрудник ответственный за вольер]) AS 'ФИО Сотрудника', 
                    [Животное_в_вольере] AS 'Животное'
                FROM Вольеры";

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridViewEnclosures.DataSource = dataTable;
                    }
                }

                // Скрываем столбец "Номер вольера" (ID)
                if (dataGridViewEnclosures.Columns.Contains("Номер вольера"))
                {
                    dataGridViewEnclosures.Columns["Номер вольера"].Visible = false;
                }

                // Добавляем столбец для отображения номера строки
                if (!dataGridViewEnclosures.Columns.Contains("ColumnRowNumber"))
                {
                    DataGridViewTextBoxColumn rowNumberColumn = new DataGridViewTextBoxColumn
                    {
                        Name = "ColumnRowNumber",
                        HeaderText = "№",
                        ReadOnly = true
                    };
                    dataGridViewEnclosures.Columns.Insert(0, rowNumberColumn); // Вставляем в первую позицию
                }

                // Обновляем нумерацию строк
                UpdateRowNumbersEnclosures();

                // Подписываемся на события добавления и удаления строк
                dataGridViewEnclosures.RowsAdded += (s, ev) => UpdateRowNumbersEnclosures();
                dataGridViewEnclosures.RowsRemoved += (s, ev) => UpdateRowNumbersEnclosures();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных о вольерах: " + ex.Message);
            }
        }

        // Helper method to update row numbers
        private void UpdateRowNumbersEnclosures()
        {
            for (int i = 0; i < dataGridViewEnclosures.Rows.Count; i++)
            {
                dataGridViewEnclosures.Rows[i].Cells["ColumnRowNumber"].Value = i + 1;
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
            bool heightParsed = float.TryParse(textBoxHeight.Text, out height);
            bool lifetimeParsed = int.TryParse(textBoxLifetime.Text, out lifetime);

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
            string specialty = comboBoxPosition.Text;

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

                string query = "INSERT INTO Животные (Кличка, Семейство, Класс, Возраст, Пол, [Страна обитания], Масса, Высота, [Продолжительность жизни], [Сотрудник ответственный за животное]) " +
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
            textBoxFamily.SelectedIndex = 0;
            textBoxSpecies.SelectedIndex = 0;
            textBoxAge.Clear();
            comboBoxGender.SelectedIndex = 0;
            textBoxCountry.Clear();
            textBoxWeight.Clear();
            textBoxLifetime.Clear();
            textBoxHeight.Clear();
            comboBoxWorker.SelectedIndex = 0;
        }

        // Очистка полей после добавления сотрудника
        private void ClearEmployeeFields()
        {
            textBoxEmployeeName.Clear();
            textBoxEmployeeAge.Clear();
            textBoxEmployeeExperience.Clear();
            textBoxEmployeeSalary.Clear();
            comboBoxPosition.SelectedIndex = -1;
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
            var animalId = selectedRow.Cells["№"].Value; // Порядковый номер строки

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
            // Считываем значения из формы
            string enclosureType = comboBoxEnclosureType.SelectedItem?.ToString();
            string food = textBoxEnclosureFood.Text.Trim();
            string workerId = (comboBoxEnclosureWorker.SelectedItem as ComboBoxItem)?.Id.ToString();
            string animalInEnclosure = (comboBoxEnclosureAnimal.SelectedItem as ComboBoxItem)?.Name;

            // Проверяем заполненность всех полей
            if (string.IsNullOrWhiteSpace(enclosureType) ||
                string.IsNullOrWhiteSpace(food) ||
                string.IsNullOrWhiteSpace(workerId) ||
                string.IsNullOrWhiteSpace(animalInEnclosure))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.");
                return;
            }

            // Проверка на существование животного в других вольерах
            string dbPath = @"D:\sqlite\Databases\zoo.db";
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Проверяем, добавлено ли животное в таблицу вольеров
                    string checkQuery = "SELECT COUNT(*) FROM Вольеры WHERE [Животное_в_вольере] = @animalInEnclosure";
                    using (SQLiteCommand checkCommand = new SQLiteCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@animalInEnclosure", animalInEnclosure);
                        int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show($"Животное '{animalInEnclosure}' уже добавлено в один из вольеров.");
                            return;
                        }
                    }

                    // Получаем класс животного из базы данных
                    string animalClass = GetAnimalClassFromDatabase(animalInEnclosure);
                    if (string.IsNullOrEmpty(animalClass))
                    {
                        MessageBox.Show($"Класс животного '{animalInEnclosure}' не найден в базе данных.");
                        return;
                    }

                    // Проверяем совместимость животного с типом вольера
                    if (!IsAnimalCompatibleWithEnclosure(animalClass, enclosureType))
                    {
                        MessageBox.Show($"Животное '{animalInEnclosure}' из класса '{animalClass}' не совместимо с вольером типа '{enclosureType}'.");
                        return;
                    }

                    // Добавляем новый вольер в базу данных
                    string query = "INSERT INTO Вольеры ([Вид_вольера], [Корм нужный в вольере], [Сотрудник ответственный за вольер], [Животное_в_вольере]) " +
                                   "VALUES (@enclosureType, @food, @workerId, @animalInEnclosure)";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@enclosureType", enclosureType);
                        command.Parameters.AddWithValue("@food", food);
                        command.Parameters.AddWithValue("@workerId", workerId);
                        command.Parameters.AddWithValue("@animalInEnclosure", animalInEnclosure);

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

                // Скрываем колонку "ID Билета"
                if (dataGridViewTickets.Columns["ID Билета"] != null)
                {
                    dataGridViewTickets.Columns["ID Билета"].Visible = false;
                }

                // Проверяем, существует ли уже колонка для нумерации строк
                if (!dataGridViewTickets.Columns.Contains("ColumnRowNumber"))
                {
                    // Добавление колонки для порядковых номеров
                    DataGridViewTextBoxColumn rowNumberColumn = new DataGridViewTextBoxColumn
                    {
                        Name = "ColumnRowNumber",
                        HeaderText = "№",
                        ReadOnly = true
                    };
                    dataGridViewTickets.Columns.Insert(0, rowNumberColumn); // Вставляем колонку на первое место
                }

                // Устанавливаем начальные порядковые номера
                UpdateRowNumbers();

                // Подписываемся на события для динамического обновления
                dataGridViewTickets.RowsAdded -= (s, ev) => UpdateRowNumbers();
                dataGridViewTickets.RowsRemoved -= (s, ev) => UpdateRowNumbers();
                dataGridViewTickets.RowsAdded += (s, ev) => UpdateRowNumbers();
                dataGridViewTickets.RowsRemoved += (s, ev) => UpdateRowNumbers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных о билетах: " + ex.Message);
            }
        }



        private void UpdateRowNumbers()
        {
            // Перебираем строки и устанавливаем порядковый номер
            for (int i = 0; i < dataGridViewTickets.Rows.Count; i++)
            {
                dataGridViewTickets.Rows[i].Cells["ColumnRowNumber"].Value = (i + 1).ToString();
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
                MessageBox.Show("Введите Кличку животного для поиска!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dbPath = @"D:\sqlite\Databases\zoo.db"; // Укажите путь к базе данных
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // SQL-запрос с LIKE для поиска по кличке
                    string query = @"
                SELECT 
                    Животные.[Номер ветеринарной карты], 
                    Животные.[Кличка], 
                    Животные.[Семейство], 
                    Животные.[Класс], 
                    Животные.[Возраст], 
                    Животные.[Пол], 
                    Животные.[Страна обитания], 
                    Животные.[Масса], 
                    Животные.[Высота], 
                    Животные.[Продолжительность жизни], 
                    Сотрудники.[ФИО] AS 'Сотрудник ответственный за животное'
                FROM 
                    Животные
                LEFT JOIN 
                    Сотрудники
                ON 
                    Животные.[Сотрудник ответственный за животное] = Сотрудники.[ID Работника]
                WHERE 
                    Животные.[Кличка] LIKE @searchTerm COLLATE NOCASE";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        // Добавляем параметр поиска
                        command.Parameters.AddWithValue("@searchTerm", $"%{searchTerm}%");

                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                        DataTable results = new DataTable();
                        adapter.Fill(results);

                        // Если есть результаты, добавляем порядковые номера
                        if (results.Rows.Count > 0)
                        {
                            if (!results.Columns.Contains("№"))
                            {
                                results.Columns.Add("№", typeof(int));
                            }

                            for (int i = 0; i < results.Rows.Count; i++)
                            {
                                results.Rows[i]["№"] = i + 1; // Добавляем порядковые номера
                            }

                            // Перемещаем колонку "№" в начало
                            results.Columns["№"].SetOrdinal(0);
                        }

                        // Обновляем DataGridView с результатами
                        dataGridViewAnimals.DataSource = results;

                        if (results.Rows.Count == 0)
                        {
                            MessageBox.Show("Животное с такой Кличкой не найдено.", "Результаты поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            textBoxAnimalName.Text = selectedRow.Cells["Кличка"].Value?.ToString() ?? "";
            textBoxFamily.Text = selectedRow.Cells["Семейство"].Value?.ToString() ?? "";
            textBoxSpecies.Text = selectedRow.Cells["Класс"].Value?.ToString() ?? "";
            textBoxAge.Text = selectedRow.Cells["Возраст"].Value?.ToString() ?? "";
            textBoxCountry.Text = selectedRow.Cells["Страна обитания"].Value?.ToString() ?? "";
            textBoxWeight.Text = selectedRow.Cells["Масса"].Value?.ToString() ?? "";
            textBoxHeight.Text = selectedRow.Cells["Высота"].Value?.ToString() ?? "";
            textBoxLifetime.Text = selectedRow.Cells["Продолжительность жизни"].Value?.ToString() ?? "";

            // Заносим работника в comboBoxWorker
            string workerName = selectedRow.Cells["Сотрудник ответственный за животное"].Value?.ToString() ?? "";
            comboBoxWorker.SelectedItem = comboBoxWorker.Items.Cast<object>().FirstOrDefault(item => item.ToString() == workerName);
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

            // Получаем выбранную строку
            DataGridViewRow selectedRow = dataGridViewAnimals.SelectedRows[0];

            // Получаем значение скрытого первичного ключа
            int id = Convert.ToInt32(selectedRow.Cells["Номер ветеринарной карты"].Value);

            // Проверяем заполненность полей
            if (string.IsNullOrWhiteSpace(textBoxAnimalName.Text) ||
                string.IsNullOrWhiteSpace(textBoxSpecies.Text) ||
                string.IsNullOrWhiteSpace(textBoxFamily.Text) ||
                string.IsNullOrWhiteSpace(textBoxAge.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dbPath = @"D:\sqlite\Databases\zoo.db";
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Обновляем запись в базе данных
                    string query = @"
                UPDATE Животные
                SET 
                    Кличка = @name, 
                    Семейство = @family, 
                    Класс = @species, 
                    Возраст = @age
                WHERE 
                    [Номер ветеринарной карты] = @id";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", textBoxAnimalName.Text);
                        command.Parameters.AddWithValue("@family", textBoxFamily.Text);
                        command.Parameters.AddWithValue("@species", textBoxSpecies.Text);
                        command.Parameters.AddWithValue("@age", Convert.ToInt32(textBoxAge.Text));
                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                    }
                }

                // Обновляем таблицу
                LoadAnimals();
                MessageBox.Show("Изменения успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении изменений: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ResetSearch_Click(object sender, EventArgs e)
        {
            string dbPath = @"D:\\sqlite\\Databases\\zoo.db"; // Укажите путь к вашей базе данных
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Запрос для загрузки всех данных
                    string query = @"
                SELECT 
                    Животные.[Номер ветеринарной карты], 
                    Животные.[Кличка], 
                    Животные.[Семейство], 
                    Животные.[Класс], 
                    Животные.[Возраст], 
                    Животные.[Пол], 
                    Животные.[Страна обитания], 
                    Животные.[Масса], 
                    Животные.[Высота], 
                    Животные.[Продолжительность жизни], 
                    Сотрудники.[ФИО] AS 'Сотрудник ответственный за животное'
                FROM 
                    Животные
                LEFT JOIN 
                    Сотрудники
                ON 
                    Животные.[Сотрудник ответственный за животное] = Сотрудники.[ID Работника]";

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                    {
                        DataTable originalTable = new DataTable();
                        adapter.Fill(originalTable);

                        // Создаём новую таблицу с порядковой колонкой в начале
                        DataTable newTable = new DataTable();

                        // Добавляем колонку "№" в начало
                        newTable.Columns.Add("№", typeof(int));

                        // Копируем остальные колонки из оригинальной таблицы
                        foreach (DataColumn column in originalTable.Columns)
                        {
                            newTable.Columns.Add(column.ColumnName, column.DataType);
                        }

                        // Заполняем новую таблицу данными из оригинальной и добавляем порядковые номера
                        for (int i = 0; i < originalTable.Rows.Count; i++)
                        {
                            DataRow newRow = newTable.NewRow();
                            newRow["№"] = i + 1; // Порядковый номер
                            foreach (DataColumn column in originalTable.Columns)
                            {
                                newRow[column.ColumnName] = originalTable.Rows[i][column];
                            }
                            newTable.Rows.Add(newRow);
                        }

                        // Привязываем новую таблицу к DataGridView
                        dataGridViewAnimals.DataSource = newTable;

                        // Скрываем колонку с первичным ключом
                        if (dataGridViewAnimals.Columns.Contains("Номер ветеринарной карты"))
                        {
                            dataGridViewAnimals.Columns["Номер ветеринарной карты"].Visible = false;
                        }
                    }
                }

                // Очищаем текстовое поле поиска (если используется)
                txtSearch.Text = string.Empty;
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
                    comboBoxPosition.Text = selectedRow.Cells["Должность"].Value?.ToString() ?? "";
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
                    // Проверка на заполненность всех полей
                    if (string.IsNullOrWhiteSpace(textBoxEmployeeName.Text) ||
                        string.IsNullOrWhiteSpace(textBoxEmployeeAge.Text) ||
                        string.IsNullOrWhiteSpace(textBoxEmployeeExperience.Text) ||
                        string.IsNullOrWhiteSpace(textBoxEmployeeSalary.Text) ||
                        string.IsNullOrWhiteSpace(comboBoxPosition.Text))
                    {
                        MessageBox.Show("Пожалуйста, заполните все поля перед сохранением.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Проверка корректности возрастных и числовых данных
                    if (!int.TryParse(textBoxEmployeeAge.Text, out int age) || age <= 0 ||
                        !int.TryParse(textBoxEmployeeExperience.Text, out int experience) || experience < 0 ||
                        !decimal.TryParse(textBoxEmployeeSalary.Text, out decimal salary) || salary <= 0)
                    {
                        MessageBox.Show("Пожалуйста, введите корректные числовые значения для возраста, стажа и зарплаты.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Обновление данных в DataGridView
                    selectedRow.Cells["ФИО"].Value = textBoxEmployeeName.Text;
                    selectedRow.Cells["Возраст"].Value = age;
                    selectedRow.Cells["Стаж работы"].Value = experience;
                    selectedRow.Cells["Зарплата"].Value = salary;
                    selectedRow.Cells["Должность"].Value = comboBoxPosition.Text;

                    string connectionString = @"Data Source=D:\sqlite\Databases\zoo.db;Version=3;";
                    string query = @"
    UPDATE Сотрудники
    SET 
        [ФИО] = @fio,
        [Возраст] = @age,
        [Стаж работы] = @experience,
        [Зарплата] = @salary,
        [Должность] = @position
    WHERE [ID Работника] = @id";

                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();
                        using (SQLiteCommand command = new SQLiteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@fio", textBoxEmployeeName.Text);
                            command.Parameters.AddWithValue("@age", age);
                            command.Parameters.AddWithValue("@experience", experience);
                            command.Parameters.AddWithValue("@salary", salary);
                            command.Parameters.AddWithValue("@position", comboBoxPosition.Text);
                            command.Parameters.AddWithValue("@id", selectedRow.Cells["ID Работника"].Value);

                            command.ExecuteNonQuery();
                        }
                    }

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

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сбросе поиска: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonFinishEditing_Click(object sender, EventArgs e)
        {
            // Проверяем, выбрана ли строка для редактирования
            if (dataGridViewTickets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите билет для редактирования.");
                return;
            }

            // Получаем данные из выбранной строки
            var selectedRow = dataGridViewTickets.SelectedRows[0];
            var ticketId = selectedRow.Cells["ID Билета"].Value;

            // Получаем обновленные данные из текстовых полей
            string services = txtServices.Text.Trim();
            string totalCost = txtTotalCost.Text.Trim();
            string purchaseDate = txtPurchaseDate.Text.Trim();
            string employee = comboBoxEmployee.SelectedItem?.ToString();
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();

            // Проверяем, что все поля заполнены
            if (string.IsNullOrWhiteSpace(services) ||
                string.IsNullOrWhiteSpace(totalCost) ||
                string.IsNullOrWhiteSpace(purchaseDate) ||
                string.IsNullOrWhiteSpace(employee) ||
                string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Пожалуйста, заполните все поля для редактирования билета.");
                return;
            }

            string dbPath = @"D:\sqlite\Databases\zoo.db";
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // SQL-запрос для обновления данных
                    string query = @"
                UPDATE Билеты
                SET 
                    Услуги = @services,
                    [Суммарная стоимость] = @totalCost,
                    [Дата покупки] = @purchaseDate,
                    [Сотрудник, выдавший билет] = @employee,
                    Имя = @firstName,
                    Фамилия = @lastName
                WHERE [ID Билета] = @ticketId";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        // Передаем параметры в запрос
                        command.Parameters.AddWithValue("@services", services);
                        command.Parameters.AddWithValue("@totalCost", totalCost);
                        command.Parameters.AddWithValue("@purchaseDate", purchaseDate);
                        command.Parameters.AddWithValue("@employee", employee);
                        command.Parameters.AddWithValue("@firstName", firstName);
                        command.Parameters.AddWithValue("@lastName", lastName);
                        command.Parameters.AddWithValue("@ticketId", ticketId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Билет успешно обновлён!");
                            LoadTickets(); // Обновляем таблицу
                        }
                        else
                        {
                            MessageBox.Show("Не удалось обновить билет. Попробуйте ещё раз.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при редактировании билета: " + ex.Message);
            }
        }



        private void dataGridViewTickets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Проверка на допустимый индекс строки
                {
                    DataGridViewRow row = dataGridViewTickets.Rows[e.RowIndex];

                    // Проверка наличия каждого столбца перед доступом
                    txtServices.Text = row.Cells["Услуги"]?.Value?.ToString() ?? "Не указано";
                    txtTotalCost.Text = row.Cells["Суммарная стоимость"]?.Value?.ToString() ?? "0";
                    txtPurchaseDate.Text = row.Cells["Дата покупки"]?.Value?.ToString() ?? "Не указано";
                    txtFirstName.Text = row.Cells["Имя Покупателя"]?.Value?.ToString() ?? "Не указано";
                    txtLastName.Text = row.Cells["Фамилия Покупателя"]?.Value?.ToString() ?? "Не указано";

                    // Проверка наличия столбца "Сотрудник, выдавший билет"
                    if (dataGridViewTickets.Columns.Contains("Сотрудник, выдавший билет"))
                    {
                        string employee = row.Cells["Сотрудник, выдавший билет"]?.Value?.ToString();
                        if (!string.IsNullOrEmpty(employee))
                        {
                            // Установка значения ComboBox для сотрудника
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
                    else
                    {
                        MessageBox.Show("Столбец 'Сотрудник, выдавший билет' отсутствует в таблице.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обработке клика: {ex.Message}");
            }

            // Отключение сортировки для всех столбцов
            foreach (DataGridViewColumn column in dataGridViewTickets.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }


        private void SearchByDate_Click(object sender, EventArgs e)
        {
            string searchDay = txtSearchDay.Text.Trim();
            string searchMonth = txtSearchMonth.Text.Trim();

            // Проверяем, что оба поля заполнены
            if (string.IsNullOrWhiteSpace(searchDay) || string.IsNullOrWhiteSpace(searchMonth))
            {
                MessageBox.Show("Пожалуйста, введите день и месяц для поиска.");
                return;
            }

            // Проверяем, что введены корректные числа
            if (!int.TryParse(searchDay, out int day) || day < 1 || day > 31 ||
                !int.TryParse(searchMonth, out int month) || month < 1 || month > 12)
            {
                MessageBox.Show("Введите корректные значения для дня (1-31) и месяца (1-12).");
                return;
            }

            string dbPath = @"D:\sqlite\Databases\zoo.db";
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // SQL-запрос для поиска по дню и месяцу
                    string query = @"
                SELECT [ID Билета], Услуги, [Суммарная стоимость], [Дата покупки], 
                       [Сотрудник, выдавший билет], Имя AS 'Имя покупателя', Фамилия AS 'Фамилия покупателя'
                FROM Билеты 
                WHERE strftime('%d', [Дата покупки]) = @day AND strftime('%m', [Дата покупки]) = @month";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        // Передаём день и месяц в параметрах
                        command.Parameters.AddWithValue("@day", searchDay.PadLeft(2, '0')); // Форматируем день
                        command.Parameters.AddWithValue("@month", searchMonth.PadLeft(2, '0')); // Форматируем месяц

                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            if (dataTable.Rows.Count == 0)
                            {
                                MessageBox.Show("Билеты на указанное число и месяц не найдены.");
                            }
                            else
                            {
                                dataGridViewTickets.DataSource = dataTable;
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

            // Проверяем, что сотрудник выбран
            if (comboBoxEmployee.SelectedItem == null)
            {
                MessageBox.Show("Выберите сотрудника перед созданием билета.");
                return;
            }

            // Получаем выбранного сотрудника
            string selectedEmployee = comboBoxEmployee.SelectedItem.ToString();

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

            // Путь к базе данных и строка подключения
            string dbPath = @"D:\sqlite\Databases\zoo.db";
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // SQL-запрос для вставки нового билета
                    string query = "INSERT INTO Билеты (Услуги, [Суммарная стоимость], [Дата покупки], Имя, Фамилия, [Сотрудник, выдавший билет]) " +
                                   "VALUES (@services, @totalCost, @purchaseDate, @firstName, @lastName, @employee)";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        // Передаем параметры в запрос
                        command.Parameters.AddWithValue("@services", services);
                        command.Parameters.AddWithValue("@totalCost", totalCost);
                        command.Parameters.AddWithValue("@purchaseDate", purchaseDate);
                        command.Parameters.AddWithValue("@firstName", firstName);
                        command.Parameters.AddWithValue("@lastName", lastName);
                        command.Parameters.AddWithValue("@employee", selectedEmployee);

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
                    string query = @"
SELECT 
    [Номер вольера] AS 'Номер', 
    [Вид_вольера] AS 'Вид вольера', 
    [Корм нужный в вольере] AS 'Корм', 
    [Сотрудник ответственный за вольер] AS 'Сотрудник', 
    [Животное_в_вольере] AS 'Животное'
FROM Вольеры 
WHERE [Животное_в_вольере] LIKE @animal";

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

                            // Скрываем столбец "Номер"
                            if (dataGridViewEnclosures.Columns.Contains("Номер"))
                            {
                                dataGridViewEnclosures.Columns["Номер"].Visible = false;
                            }

                            // Если данных нет, показываем сообщение
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
                    string query = @"
                SELECT 
                    [Вид_вольера] AS 'Вид вольера', 
                    [Корм нужный в вольере] AS 'Корм', 
                    (SELECT ФИО FROM Сотрудники WHERE [ID Работника] = Вольеры.[Сотрудник ответственный за вольер]) AS 'ФИО Сотрудника',
                    [Животное_в_вольере] AS 'Животное'
                FROM Вольеры";

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridViewEnclosures.DataSource = dataTable;
                    }
                }

                // Убедимся, что номера строк обновляются
                UpdateRowNumbersEnclosures();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
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
                    string query = "SELECT " +
                                   "Услуги, " +
                                   "[Суммарная стоимость], " +
                                   "[Дата покупки], " +
                                   "[Сотрудник, выдавший билет], " +
                                   "Имя AS 'Имя покупателя', " +
                                   "Фамилия AS 'Фамилия покупателя' " +
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
                txtSearchDay.Text = string.Empty;
                txtSearchMonth.Text = string.Empty;
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Проверяем, что клик произошел не на заголовке и не на пустой строке
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    var cellValue = dataGridViewTickets.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (cellValue != null)
                    {
                        MessageBox.Show($"Вы выбрали: {cellValue}");
                    }
                    else
                    {
                        MessageBox.Show("Пустая ячейка.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обработке клика: {ex.Message}");
            }
        }
        private Dictionary<string, List<string>> familyToClassesMap = new Dictionary<string, List<string>>()
{
    { "Кошачьи", new List<string> { "Белый тигр", "Лев обычный", "Амурский тигр" } },
    { "Собачьи", new List<string> { "Канадский волк", "Дикая собака" } },
    { "Грызуновые", new List<string> { "Капибара", "Бобр речной" } },
    { "Приматы", new List<string> { "Горная горилла", "Шимпанзе", "Орангутан" } },
    { "Парнокопытные", new List<string> { "Лось", "Африканский буйвол" } },
    { "Птицы", new List<string> { "Императорский пингвин", "Алый ара", "Фламинго" } },
    { "Рептилии", new List<string> { "Крокодил нильский", "Анаконда", "Игуана зелёная" } },
    { "Рыбы", new List<string> { "Сельдь", "Китовая акула" } },
    { "Насекомые", new List<string> { "Бабочка монарх", "Муравей" } },
    { "Млекопитающие", new List<string> { "Белый медведь", "Гигантская панда" } },
    { "Земноводные", new List<string> { "Лягушка-древолаз", "Саламандра" } },
    { "Членистоногие", new List<string> { "Тарантул", "Скорпион" } }
};
        private Dictionary<string, int> speciesToLifeSpanMap = new Dictionary<string, int>()
{
    { "Белый тигр", 20 },
    { "Лев обычный", 14 },
    { "Амурский тигр", 18 },
    { "Канадский волк", 16 },
    { "Дикая собака", 13 },
    { "Капибара", 12 },
    { "Бобр речной", 10 },
    { "Горная горилла", 40 },
    { "Шимпанзе", 50 },
    { "Орангутан", 35 },
    { "Лось", 20 },
    { "Африканский буйвол", 25 },
    { "Императорский пингвин", 20 },
    { "Алый ара", 50 },
    { "Фламинго", 30 },
    { "Крокодил нильский", 70 },
    { "Анаконда", 30 },
    { "Игуана зелёная", 15 },
    { "Сельдь", 8 },
    { "Китовая акула", 70 },
    { "Бабочка монарх", 0 },
    { "Муравей", 0 },
    { "Белый медведь", 25 },
    { "Гигантская панда", 18 },
    { "Лягушка-древолаз", 6 },
    { "Саламандра", 12 },
    { "Тарантул", 8 },
    { "Скорпион", 6 }
};
        private Dictionary<string, List<string>> enclosureTypeToAllowedFamilies = new Dictionary<string, List<string>>()
{
    { "Травоядное", new List<string> { "Парнокопытные", "Грызуновые" } },
    { "Хищник", new List<string> { "Кошачьи", "Собачьи", "Рептилии" } },
    { "Птицы", new List<string> { "Птицы" } },
    { "Приматы", new List<string> { "Приматы" } },
    { "Рыбы", new List<string> { "Рыбы" } },
    { "Земноводные", new List<string> { "Земноводные" } },
    { "Насекомые", new List<string> { "Насекомые", "Членистоногие" } }
};

        private bool isUpdating = false;
        private void textBoxFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isUpdating) return; // Предотвращаем циклический вызов

            isUpdating = true; // Устанавливаем флаг
            try
            {
                // Получаем выбранное семейство
                string selectedFamily = textBoxFamily.SelectedItem?.ToString();

                // Очищаем ComboBox "Класс" (textBoxSpecies)
                textBoxSpecies.Items.Clear();

                if (string.IsNullOrEmpty(selectedFamily) || !familyToClassesMap.ContainsKey(selectedFamily))
                {
                    return; // Если семейство не выбрано или не найдено в словаре
                }

                // Добавляем классы, связанные с выбранным семейством
                textBoxSpecies.Items.AddRange(familyToClassesMap[selectedFamily].ToArray());

                // Устанавливаем первый элемент как выбранный, если есть доступные классы
                if (textBoxSpecies.Items.Count > 0)
                {
                    textBoxSpecies.SelectedIndex = 0;
                }
            }
            finally
            {
                isUpdating = false; // Сбрасываем флаг
            }
        }

        private void textBoxSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isUpdating) return; // Предотвращаем циклический вызов

            isUpdating = true; // Устанавливаем флаг
            try
            {
                // Получаем выбранный класс
                string selectedClass = textBoxSpecies.SelectedItem?.ToString();

                // Проверяем наличие выбранного класса
                if (string.IsNullOrEmpty(selectedClass)) return;

                // Находим семейство, к которому относится класс
                string matchingFamily = familyToClassesMap.FirstOrDefault(
                    kvp => kvp.Value.Contains(selectedClass)).Key;

                // Обновляем семейство только при необходимости
                if (!string.IsNullOrEmpty(matchingFamily) && textBoxFamily.SelectedItem?.ToString() != matchingFamily)
                {
                    textBoxFamily.SelectedItem = matchingFamily;
                }

                // Устанавливаем продолжительность жизни
                if (speciesToLifeSpanMap.ContainsKey(selectedClass))
                {
                    textBoxLifetime.Text = speciesToLifeSpanMap[selectedClass].ToString(); // Установка в текстовое поле
                }
                else
                {
                    textBoxLifetime.Text = ""; // Если данных нет, оставляем поле пустым
                }
            }
            finally
            {
                isUpdating = false; // Сбрасываем флаг
            }
        }
        private void dataGridViewEnclosures_SelectionChanged(object sender, EventArgs e)
        {
            // Проверяем, что выбрана хотя бы одна строка
            if (dataGridViewEnclosures.SelectedRows.Count == 0)
                return;

            var selectedRow = dataGridViewEnclosures.SelectedRows[0];

            // Получаем значения из выбранной строки
            string enclosureType = selectedRow.Cells["Вид вольера"].Value?.ToString();
            string food = selectedRow.Cells["Корм"].Value?.ToString();
            string workerName = selectedRow.Cells["ФИО Сотрудника"].Value?.ToString();
            string animalInEnclosure = selectedRow.Cells["Животное"].Value?.ToString();

            // Устанавливаем значения в соответствующие элементы формы
            comboBoxEnclosureType.SelectedItem = enclosureType;
            textBoxEnclosureFood.Text = food;

            // Находим работника в ComboBox по имени
            foreach (var item in comboBoxEnclosureWorker.Items)
            {
                if (item is ComboBoxItem comboItem && comboItem.Name == workerName)
                {
                    comboBoxEnclosureWorker.SelectedItem = comboItem;
                    break;
                }
            }

            // Находим животное в ComboBox по имени
            foreach (var item in comboBoxEnclosureAnimal.Items)
            {
                if (item is ComboBoxItem comboItem && comboItem.Name == animalInEnclosure)
                {
                    comboBoxEnclosureAnimal.SelectedItem = comboItem;
                    break;
                }
            }
        }





        private void buttonSaveEnclosureChanges_Click(object sender, EventArgs e)
        {
            if (dataGridViewEnclosures.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите вольер для редактирования.");
                return;
            }

            var selectedRow = dataGridViewEnclosures.SelectedRows[0];

            // Проверяем наличие скрытого столбца "Номер вольера" и его значение
            var hiddenColumnName = "Номер вольера"; // Имя скрытого столбца
            if (!dataGridViewEnclosures.Columns.Contains(hiddenColumnName))
            {
                MessageBox.Show($"Столбец '{hiddenColumnName}' отсутствует. Проверьте настройки таблицы.");
                return;
            }

            var hiddenColumnValue = selectedRow.Cells[hiddenColumnName].Value;
            if (hiddenColumnValue == null || string.IsNullOrWhiteSpace(hiddenColumnValue.ToString()))
            {
                MessageBox.Show($"Не удалось определить идентификатор записи ({hiddenColumnName}). Проверьте данные таблицы.");
                return;
            }

            // Проверяем, что значение в скрытом столбце является числом
            if (!int.TryParse(hiddenColumnValue.ToString(), out int enclosureNumber))
            {
                MessageBox.Show($"Идентификатор записи ({hiddenColumnName}) некорректен: {hiddenColumnValue}");
                return;
            }

            // Считываем новые значения из формы
            string newEnclosureType = comboBoxEnclosureType.SelectedItem?.ToString();
            string newEnclosureFood = textBoxEnclosureFood.Text.Trim();
            string newWorkerId = (comboBoxEnclosureWorker.SelectedItem as ComboBoxItem)?.Id.ToString();
            string newAnimalInEnclosure = (comboBoxEnclosureAnimal.SelectedItem as ComboBoxItem)?.Name;

            if (string.IsNullOrWhiteSpace(newEnclosureType) ||
                string.IsNullOrWhiteSpace(newEnclosureFood) ||
                string.IsNullOrWhiteSpace(newWorkerId) ||
                string.IsNullOrWhiteSpace(newAnimalInEnclosure))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля перед сохранением.");
                return;
            }

            // Проверка: животное уже назначено в другой вольер
            string dbPath = @"D:\sqlite\Databases\zoo.db";
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Проверяем, используется ли животное в другом вольере
                    string checkQuery = @"
                SELECT COUNT(*) 
                FROM Вольеры 
                WHERE [Животное_в_вольере] = @animalInEnclosure AND [Номер вольера] != @id";

                    using (SQLiteCommand checkCommand = new SQLiteCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@animalInEnclosure", newAnimalInEnclosure);
                        checkCommand.Parameters.AddWithValue("@id", enclosureNumber);

                        int count = Convert.ToInt32(checkCommand.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show($"Животное '{newAnimalInEnclosure}' уже назначено в другой вольер. Выберите другое животное.");
                            return;
                        }
                    }

                    // Обновляем данные в базе
                    string updateQuery = @"
                UPDATE Вольеры
                SET 
                    [Вид_вольера] = @enclosureType, 
                    [Корм нужный в вольере] = @food, 
                    [Сотрудник ответственный за вольер] = @workerId, 
                    [Животное_в_вольере] = @animalInEnclosure
                WHERE 
                    [Номер вольера] = @id";

                    using (SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@enclosureType", newEnclosureType);
                        updateCommand.Parameters.AddWithValue("@food", newEnclosureFood);
                        updateCommand.Parameters.AddWithValue("@workerId", newWorkerId);
                        updateCommand.Parameters.AddWithValue("@animalInEnclosure", newAnimalInEnclosure);
                        updateCommand.Parameters.AddWithValue("@id", enclosureNumber);

                        updateCommand.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Изменения успешно сохранены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении изменений: " + ex.Message);
            }

            // Обновляем данные в DataGridView
            LoadEnclosures();
        }


        private void textBoxAnimalName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверяем, является ли символ числом или другим запрещённым символом
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true; // Блокируем ввод
            }

            // Если символ буква, backspace или пробел, разрешаем ввод
            if (char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
        }

        private string GetAnimalClassFromDatabase(string animalName)
        {
            string dbPath = @"D:\sqlite\Databases\zoo.db";
            string connectionString = $"Data Source={dbPath};Version=3;";
            string animalClass = null;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Класс FROM Животные WHERE Кличка = @AnimalName";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AnimalName", animalName);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                animalClass = reader["Класс"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении класса животного: " + ex.Message);
            }

            return animalClass;
        }

        private bool IsAnimalCompatibleWithEnclosure(string animalClass, string enclosureType)
        {
            // Получаем семейство животного
            string animalFamily = familyToClassesMap.FirstOrDefault(f => f.Value.Contains(animalClass)).Key;

            // Если семейство не найдено, животное несовместимо
            if (string.IsNullOrEmpty(animalFamily))
                return false;

            // Проверяем, разрешено ли семейство для данного типа вольера
            if (enclosureTypeToAllowedFamilies.ContainsKey(enclosureType) &&
                enclosureTypeToAllowedFamilies[enclosureType].Contains(animalFamily))
            {
                return true;
            }

            return false;
        }

        private void dataGridViewServices_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewServices.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewServices.SelectedRows[0];
                textBoxDescriptionView.Text = selectedRow.Cells["Описание"].Value?.ToString() ?? string.Empty;
            }
        }
        private void txtSearchDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры и клавишу Backspace
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void textBoxAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Блокируем все, кроме цифр и Backspace
            }
        }
        private void buttonDeleteEnclosure_Click(object sender, EventArgs e)
        {
            if (dataGridViewEnclosures.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewEnclosures.SelectedRows[0];

                // Получаем данные, по которым будем удалять вольер (например, тип вольера и животное)
                string enclosureType = selectedRow.Cells["Вид вольера"].Value?.ToString();
                string enclosureAnimal = selectedRow.Cells["Животное"].Value?.ToString();

                if (string.IsNullOrEmpty(enclosureType) || string.IsNullOrEmpty(enclosureAnimal))
                {
                    MessageBox.Show("Не удалось определить вольер для удаления.");
                    return;
                }

                // Подтверждение удаления
                DialogResult dialogResult = MessageBox.Show($"Вы уверены, что хотите удалить вольер с типом '{enclosureType}' и животным '{enclosureAnimal}'?",
        
                    "Удаление вольера", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        string dbPath = @"D:\sqlite\Databases\zoo.db";
                        string connectionString = $"Data Source={dbPath};Version=3;";

                        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                        {
                            connection.Open();

                            string query = "DELETE FROM Вольеры WHERE Вид_вольера = @EnclosureType AND Животное_в_вольере = @EnclosureAnimal";
                            using (SQLiteCommand command = new SQLiteCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@EnclosureType", enclosureType);
                                command.Parameters.AddWithValue("@EnclosureAnimal", enclosureAnimal);

                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Вольер успешно удалён.");

                                    // Удаляем строку из DataGridView
                                    dataGridViewEnclosures.Rows.Remove(selectedRow);
                                }
                                else
                                {
                                    MessageBox.Show("Не удалось удалить вольер. Возможно, он уже был удалён.");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при удалении вольера: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите вольер для удаления.");
            }
        }
        private void LoadPositions()
        {
            // Задаем фиксированный список должностей
            List<string> positions = new List<string>
    {
        "Охранник",
        "Ветеринар",
        "Экскурсовод",
        "Администратор",
        "Уборщик"
    };

            // Заполняем ComboBox
            comboBoxPosition.Items.Clear();
            comboBoxPosition.Items.AddRange(positions.ToArray());
        }

        private void buttonRefreshEmployees_Click(object sender, EventArgs e)
        {
            LoadEmployees(); 
        }

        private void comboBoxEnclosureAnimal_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAnimalType();
        }
        private void UpdateAnimalType()
        {
            // Проверяем, выбран ли элемент в ComboBox
            if (comboBoxEnclosureAnimal.SelectedItem != null)
            {
                string selectedAnimal = comboBoxEnclosureAnimal.SelectedItem.ToString();

                // Выполняем поиск данных о животном
                string dbPath = @"D:\sqlite\Databases\zoo.db";
                string connectionString = $"Data Source={dbPath};Version=3;";

                try
                {
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();

                        // SQL-запрос для получения данных о животном
                        string query = @"
SELECT Класс, Семейство
FROM Животные
WHERE Кличка = @animalName";

                        using (SQLiteCommand command = new SQLiteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@animalName", selectedAnimal);

                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // Отображаем класс или семейство животного в textBoxAnimalType
                                    string animalClass = reader["Класс"]?.ToString();
                                    string animalFamily = reader["Семейство"]?.ToString();

                                    // Отображаем "Класс" или "Семейство" в textBoxAnimalType
                                    textBoxAnimalType.Text = !string.IsNullOrWhiteSpace(animalClass)
                                        ? animalClass
                                        : animalFamily;
                                }
                                else
                                {
                                    // Если данных нет, очищаем текстовое поле
                                    textBoxAnimalType.Text = "Данные о животном не найдены.";
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при получении данных о животном: " + ex.Message);
                }
            }
            else
            {
                // Если ничего не выбрано, очищаем textBoxAnimalType
                textBoxAnimalType.Text = string.Empty;
            }
        }

    }

}

















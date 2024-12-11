using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace АИС_зоопарк
{
    public class EnclosureManager
    {
        private ComboBox comboBoxEnclosureType;
        private ComboBox comboBoxEnclosureWorker;
        private ComboBox comboBoxEnclosureAnimal;
        private TextBox textBoxEnclosureFood;

        public EnclosureManager(ComboBox comboBoxEnclosureType, ComboBox comboBoxEnclosureWorker,
                                ComboBox comboBoxEnclosureAnimal, TextBox textBoxEnclosureFood)
        {
            this.comboBoxEnclosureType = comboBoxEnclosureType;
            this.comboBoxEnclosureWorker = comboBoxEnclosureWorker;
            this.comboBoxEnclosureAnimal = comboBoxEnclosureAnimal;
            this.textBoxEnclosureFood = textBoxEnclosureFood;

            LoadEnclosureTypes();
            LoadEnclosureWorkers();
            LoadAnimalsInEnclosure();
        }

        private void LoadEnclosureTypes()
        {
            comboBoxEnclosureType.Items.Clear();
            comboBoxEnclosureType.Items.Add("Хищники");
            comboBoxEnclosureType.Items.Add("Травоядные");
            comboBoxEnclosureType.Items.Add("Всеядные");
            comboBoxEnclosureType.SelectedIndex = 0;
        }

        private void LoadEnclosureWorkers()
        {
            comboBoxEnclosureWorker.Items.Clear();
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
                            comboBoxEnclosureWorker.Items.Add(new ComboBoxItem(workerName, workerId));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке сотрудников для вольера: " + ex.Message);
            }
        }

        private void LoadAnimalsInEnclosure()
        {
            comboBoxEnclosureAnimal.Items.Clear();
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
                            string animalName = reader["Название"].ToString();
                            int animalId = Convert.ToInt32(reader["Номер ветеринарной карты"]);
                            comboBoxEnclosureAnimal.Items.Add(new ComboBoxItem(animalName, animalId));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке животных для вольера: " + ex.Message);
            }
        }

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

namespace АИС_зоопарк
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ResetSearch = new System.Windows.Forms.Button();
            this.buttonSaveChanges = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.buttonDeleteAnimal = new System.Windows.Forms.Button();
            this.dataGridViewAnimals = new System.Windows.Forms.DataGridView();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonAddAnimal = new System.Windows.Forms.Button();
            this.comboBoxWorker = new System.Windows.Forms.ComboBox();
            this.comboBoxGender = new System.Windows.Forms.ComboBox();
            this.textBoxWeight = new System.Windows.Forms.TextBox();
            this.textBoxSpecies = new System.Windows.Forms.TextBox();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.textBoxLifetime = new System.Windows.Forms.TextBox();
            this.textBoxFamily = new System.Windows.Forms.TextBox();
            this.textBoxAge = new System.Windows.Forms.TextBox();
            this.textBoxCountry = new System.Windows.Forms.TextBox();
            this.textBoxAnimalName = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonDeleteEnclosure = new System.Windows.Forms.Button();
            this.dataGridViewEnclosures = new System.Windows.Forms.DataGridView();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.buttonAddEnclosure = new System.Windows.Forms.Button();
            this.comboBoxEnclosureAnimal = new System.Windows.Forms.ComboBox();
            this.comboBoxEnclosureWorker = new System.Windows.Forms.ComboBox();
            this.comboBoxEnclosureType = new System.Windows.Forms.ComboBox();
            this.textBoxEnclosureFood = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonDeleteEmployee = new System.Windows.Forms.Button();
            this.dataGridViewEmployees = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddEmployee = new System.Windows.Forms.Button();
            this.textBoxEmployeeSpecialty = new System.Windows.Forms.TextBox();
            this.textBoxEmployeeSalary = new System.Windows.Forms.TextBox();
            this.textBoxEmployeeExperience = new System.Windows.Forms.TextBox();
            this.textBoxEmployeeAge = new System.Windows.Forms.TextBox();
            this.textBoxEmployeeName = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.buttonDeleteService = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.dataGridViewServices = new System.Windows.Forms.DataGridView();
            this.buttonAddService = new System.Windows.Forms.Button();
            this.textBoxServiceDescription = new System.Windows.Forms.TextBox();
            this.textBoxServicePrice = new System.Windows.Forms.TextBox();
            this.textBoxServiceName = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.buttonDeleteTicket = new System.Windows.Forms.Button();
            this.dataGridViewTickets = new System.Windows.Forms.DataGridView();
            this.buttonEditEmployee = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnimals)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEnclosures)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTickets)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(847, 476);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ResetSearch);
            this.tabPage1.Controls.Add(this.buttonSaveChanges);
            this.tabPage1.Controls.Add(this.buttonUpdate);
            this.tabPage1.Controls.Add(this.buttonSearch);
            this.tabPage1.Controls.Add(this.txtSearch);
            this.tabPage1.Controls.Add(this.buttonDeleteAnimal);
            this.tabPage1.Controls.Add(this.dataGridViewAnimals);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.buttonAddAnimal);
            this.tabPage1.Controls.Add(this.comboBoxWorker);
            this.tabPage1.Controls.Add(this.comboBoxGender);
            this.tabPage1.Controls.Add(this.textBoxWeight);
            this.tabPage1.Controls.Add(this.textBoxSpecies);
            this.tabPage1.Controls.Add(this.textBoxHeight);
            this.tabPage1.Controls.Add(this.textBoxLifetime);
            this.tabPage1.Controls.Add(this.textBoxFamily);
            this.tabPage1.Controls.Add(this.textBoxAge);
            this.tabPage1.Controls.Add(this.textBoxCountry);
            this.tabPage1.Controls.Add(this.textBoxAnimalName);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(839, 450);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Добавить животное";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ResetSearch
            // 
            this.ResetSearch.Location = new System.Drawing.Point(339, 169);
            this.ResetSearch.Name = "ResetSearch";
            this.ResetSearch.Size = new System.Drawing.Size(93, 23);
            this.ResetSearch.TabIndex = 30;
            this.ResetSearch.Text = "Сбросить ";
            this.ResetSearch.UseVisualStyleBackColor = true;
            this.ResetSearch.Click += new System.EventHandler(this.ResetSearch_Click);
            // 
            // buttonSaveChanges
            // 
            this.buttonSaveChanges.Location = new System.Drawing.Point(464, 132);
            this.buttonSaveChanges.Name = "buttonSaveChanges";
            this.buttonSaveChanges.Size = new System.Drawing.Size(116, 46);
            this.buttonSaveChanges.TabIndex = 29;
            this.buttonSaveChanges.Text = "Сохранить изменения ";
            this.buttonSaveChanges.UseVisualStyleBackColor = true;
            this.buttonSaveChanges.Click += new System.EventHandler(this.buttonSaveChanges_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(464, 184);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(116, 34);
            this.buttonUpdate.TabIndex = 28;
            this.buttonUpdate.Text = "Изменить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(234, 169);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(99, 23);
            this.buttonSearch.TabIndex = 27;
            this.buttonSearch.Text = "Поиск";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(234, 198);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(198, 20);
            this.txtSearch.TabIndex = 26;
            // 
            // buttonDeleteAnimal
            // 
            this.buttonDeleteAnimal.Location = new System.Drawing.Point(619, 121);
            this.buttonDeleteAnimal.Name = "buttonDeleteAnimal";
            this.buttonDeleteAnimal.Size = new System.Drawing.Size(214, 97);
            this.buttonDeleteAnimal.TabIndex = 25;
            this.buttonDeleteAnimal.Text = "Удалить животное";
            this.buttonDeleteAnimal.UseVisualStyleBackColor = true;
            this.buttonDeleteAnimal.Click += new System.EventHandler(this.buttonDeleteAnimal_Click);
            // 
            // dataGridViewAnimals
            // 
            this.dataGridViewAnimals.AllowUserToAddRows = false;
            this.dataGridViewAnimals.AllowUserToDeleteRows = false;
            this.dataGridViewAnimals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAnimals.Location = new System.Drawing.Point(3, 224);
            this.dataGridViewAnimals.Name = "dataGridViewAnimals";
            this.dataGridViewAnimals.ReadOnly = true;
            this.dataGridViewAnimals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAnimals.Size = new System.Drawing.Size(830, 223);
            this.dataGridViewAnimals.TabIndex = 24;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(592, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(96, 13);
            this.label16.TabIndex = 23;
            this.label16.Text = "Страна обитания ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(171, 12);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "Семейство";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(556, 61);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(207, 13);
            this.label14.TabIndex = 21;
            this.label14.Text = "Сотрудник ответственный за животное";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(712, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(27, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "Пол";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(296, 61);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(169, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Продолжительность жизни(лет)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Масса(кг)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(592, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 13);
            this.label10.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(171, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Высота(см)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(461, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Возраст";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(317, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Класс";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Название";
            // 
            // buttonAddAnimal
            // 
            this.buttonAddAnimal.Location = new System.Drawing.Point(8, 121);
            this.buttonAddAnimal.Name = "buttonAddAnimal";
            this.buttonAddAnimal.Size = new System.Drawing.Size(220, 97);
            this.buttonAddAnimal.TabIndex = 12;
            this.buttonAddAnimal.Text = "Добавить Животное";
            this.buttonAddAnimal.UseVisualStyleBackColor = true;
            this.buttonAddAnimal.Click += new System.EventHandler(this.buttonAddAnimal_Click);
            // 
            // comboBoxWorker
            // 
            this.comboBoxWorker.FormattingEnabled = true;
            this.comboBoxWorker.Location = new System.Drawing.Point(559, 78);
            this.comboBoxWorker.Name = "comboBoxWorker";
            this.comboBoxWorker.Size = new System.Drawing.Size(243, 21);
            this.comboBoxWorker.TabIndex = 11;
            // 
            // comboBoxGender
            // 
            this.comboBoxGender.FormattingEnabled = true;
            this.comboBoxGender.Location = new System.Drawing.Point(715, 27);
            this.comboBoxGender.Name = "comboBoxGender";
            this.comboBoxGender.Size = new System.Drawing.Size(100, 21);
            this.comboBoxGender.TabIndex = 10;
            // 
            // textBoxWeight
            // 
            this.textBoxWeight.Location = new System.Drawing.Point(8, 77);
            this.textBoxWeight.Name = "textBoxWeight";
            this.textBoxWeight.Size = new System.Drawing.Size(100, 20);
            this.textBoxWeight.TabIndex = 9;
            // 
            // textBoxSpecies
            // 
            this.textBoxSpecies.Location = new System.Drawing.Point(320, 28);
            this.textBoxSpecies.Name = "textBoxSpecies";
            this.textBoxSpecies.Size = new System.Drawing.Size(100, 20);
            this.textBoxSpecies.TabIndex = 8;
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(174, 77);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(100, 20);
            this.textBoxHeight.TabIndex = 7;
            // 
            // textBoxLifetime
            // 
            this.textBoxLifetime.Location = new System.Drawing.Point(299, 78);
            this.textBoxLifetime.Name = "textBoxLifetime";
            this.textBoxLifetime.Size = new System.Drawing.Size(166, 20);
            this.textBoxLifetime.TabIndex = 6;
            // 
            // textBoxFamily
            // 
            this.textBoxFamily.Location = new System.Drawing.Point(174, 28);
            this.textBoxFamily.Name = "textBoxFamily";
            this.textBoxFamily.Size = new System.Drawing.Size(100, 20);
            this.textBoxFamily.TabIndex = 3;
            // 
            // textBoxAge
            // 
            this.textBoxAge.Location = new System.Drawing.Point(464, 28);
            this.textBoxAge.Name = "textBoxAge";
            this.textBoxAge.Size = new System.Drawing.Size(100, 20);
            this.textBoxAge.TabIndex = 2;
            // 
            // textBoxCountry
            // 
            this.textBoxCountry.Location = new System.Drawing.Point(595, 28);
            this.textBoxCountry.Name = "textBoxCountry";
            this.textBoxCountry.Size = new System.Drawing.Size(100, 20);
            this.textBoxCountry.TabIndex = 1;
            // 
            // textBoxAnimalName
            // 
            this.textBoxAnimalName.Location = new System.Drawing.Point(8, 28);
            this.textBoxAnimalName.Name = "textBoxAnimalName";
            this.textBoxAnimalName.Size = new System.Drawing.Size(100, 20);
            this.textBoxAnimalName.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonDeleteEnclosure);
            this.tabPage2.Controls.Add(this.dataGridViewEnclosures);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.buttonAddEnclosure);
            this.tabPage2.Controls.Add(this.comboBoxEnclosureAnimal);
            this.tabPage2.Controls.Add(this.comboBoxEnclosureWorker);
            this.tabPage2.Controls.Add(this.comboBoxEnclosureType);
            this.tabPage2.Controls.Add(this.textBoxEnclosureFood);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(839, 450);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Вольеры";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteEnclosure
            // 
            this.buttonDeleteEnclosure.Location = new System.Drawing.Point(349, 172);
            this.buttonDeleteEnclosure.Name = "buttonDeleteEnclosure";
            this.buttonDeleteEnclosure.Size = new System.Drawing.Size(158, 49);
            this.buttonDeleteEnclosure.TabIndex = 10;
            this.buttonDeleteEnclosure.Text = "Удалить вольер";
            this.buttonDeleteEnclosure.UseVisualStyleBackColor = true;
            // 
            // dataGridViewEnclosures
            // 
            this.dataGridViewEnclosures.AllowUserToAddRows = false;
            this.dataGridViewEnclosures.AllowUserToDeleteRows = false;
            this.dataGridViewEnclosures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEnclosures.Location = new System.Drawing.Point(9, 227);
            this.dataGridViewEnclosures.Name = "dataGridViewEnclosures";
            this.dataGridViewEnclosures.ReadOnly = true;
            this.dataGridViewEnclosures.Size = new System.Drawing.Size(498, 217);
            this.dataGridViewEnclosures.TabIndex = 9;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(0, 172);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(113, 13);
            this.label20.TabIndex = 8;
            this.label20.Text = "Животное в вольере";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 119);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(194, 13);
            this.label19.TabIndex = 7;
            this.label19.Text = "Сотрудник ответственный за вольер";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 66);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(114, 13);
            this.label18.TabIndex = 6;
            this.label18.Text = "Корм который нужен";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 12);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 13);
            this.label17.TabIndex = 5;
            this.label17.Text = "Вид вольера ";
            // 
            // buttonAddEnclosure
            // 
            this.buttonAddEnclosure.Location = new System.Drawing.Point(205, 172);
            this.buttonAddEnclosure.Name = "buttonAddEnclosure";
            this.buttonAddEnclosure.Size = new System.Drawing.Size(138, 49);
            this.buttonAddEnclosure.TabIndex = 4;
            this.buttonAddEnclosure.Text = "Добавить вольер";
            this.buttonAddEnclosure.UseVisualStyleBackColor = true;
            this.buttonAddEnclosure.Click += new System.EventHandler(this.buttonAddEnclosure_Click);
            // 
            // comboBoxEnclosureAnimal
            // 
            this.comboBoxEnclosureAnimal.FormattingEnabled = true;
            this.comboBoxEnclosureAnimal.Location = new System.Drawing.Point(0, 188);
            this.comboBoxEnclosureAnimal.Name = "comboBoxEnclosureAnimal";
            this.comboBoxEnclosureAnimal.Size = new System.Drawing.Size(196, 21);
            this.comboBoxEnclosureAnimal.TabIndex = 3;
            // 
            // comboBoxEnclosureWorker
            // 
            this.comboBoxEnclosureWorker.FormattingEnabled = true;
            this.comboBoxEnclosureWorker.Location = new System.Drawing.Point(3, 135);
            this.comboBoxEnclosureWorker.Name = "comboBoxEnclosureWorker";
            this.comboBoxEnclosureWorker.Size = new System.Drawing.Size(196, 21);
            this.comboBoxEnclosureWorker.TabIndex = 2;
            // 
            // comboBoxEnclosureType
            // 
            this.comboBoxEnclosureType.FormattingEnabled = true;
            this.comboBoxEnclosureType.Location = new System.Drawing.Point(6, 28);
            this.comboBoxEnclosureType.Name = "comboBoxEnclosureType";
            this.comboBoxEnclosureType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEnclosureType.TabIndex = 1;
            // 
            // textBoxEnclosureFood
            // 
            this.textBoxEnclosureFood.Location = new System.Drawing.Point(3, 82);
            this.textBoxEnclosureFood.Name = "textBoxEnclosureFood";
            this.textBoxEnclosureFood.Size = new System.Drawing.Size(119, 20);
            this.textBoxEnclosureFood.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonSave);
            this.tabPage3.Controls.Add(this.buttonEditEmployee);
            this.tabPage3.Controls.Add(this.buttonDeleteEmployee);
            this.tabPage3.Controls.Add(this.dataGridViewEmployees);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.buttonAddEmployee);
            this.tabPage3.Controls.Add(this.textBoxEmployeeSpecialty);
            this.tabPage3.Controls.Add(this.textBoxEmployeeSalary);
            this.tabPage3.Controls.Add(this.textBoxEmployeeExperience);
            this.tabPage3.Controls.Add(this.textBoxEmployeeAge);
            this.tabPage3.Controls.Add(this.textBoxEmployeeName);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(839, 450);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Сотрудники";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteEmployee
            // 
            this.buttonDeleteEmployee.Location = new System.Drawing.Point(315, 200);
            this.buttonDeleteEmployee.Name = "buttonDeleteEmployee";
            this.buttonDeleteEmployee.Size = new System.Drawing.Size(126, 59);
            this.buttonDeleteEmployee.TabIndex = 12;
            this.buttonDeleteEmployee.Text = "Удалить сотрудника";
            this.buttonDeleteEmployee.UseVisualStyleBackColor = true;
            this.buttonDeleteEmployee.Click += new System.EventHandler(this.buttonDeleteEmployee_Click);
            // 
            // dataGridViewEmployees
            // 
            this.dataGridViewEmployees.AllowUserToAddRows = false;
            this.dataGridViewEmployees.AllowUserToDeleteRows = false;
            this.dataGridViewEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployees.Location = new System.Drawing.Point(0, 265);
            this.dataGridViewEmployees.Name = "dataGridViewEmployees";
            this.dataGridViewEmployees.ReadOnly = true;
            this.dataGridViewEmployees.Size = new System.Drawing.Size(659, 185);
            this.dataGridViewEmployees.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Должность";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Зарплата";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Стаж работы";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Возраст";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "ФИО Сотрудника";
            // 
            // buttonAddEmployee
            // 
            this.buttonAddEmployee.Location = new System.Drawing.Point(161, 200);
            this.buttonAddEmployee.Name = "buttonAddEmployee";
            this.buttonAddEmployee.Size = new System.Drawing.Size(148, 59);
            this.buttonAddEmployee.TabIndex = 5;
            this.buttonAddEmployee.Text = "Добавить Сотрудника";
            this.buttonAddEmployee.UseVisualStyleBackColor = true;
            this.buttonAddEmployee.Click += new System.EventHandler(this.buttonAddEmployee_Click);
            // 
            // textBoxEmployeeSpecialty
            // 
            this.textBoxEmployeeSpecialty.Location = new System.Drawing.Point(3, 239);
            this.textBoxEmployeeSpecialty.Name = "textBoxEmployeeSpecialty";
            this.textBoxEmployeeSpecialty.Size = new System.Drawing.Size(152, 20);
            this.textBoxEmployeeSpecialty.TabIndex = 4;
            // 
            // textBoxEmployeeSalary
            // 
            this.textBoxEmployeeSalary.Location = new System.Drawing.Point(3, 180);
            this.textBoxEmployeeSalary.Name = "textBoxEmployeeSalary";
            this.textBoxEmployeeSalary.Size = new System.Drawing.Size(81, 20);
            this.textBoxEmployeeSalary.TabIndex = 3;
            // 
            // textBoxEmployeeExperience
            // 
            this.textBoxEmployeeExperience.Location = new System.Drawing.Point(4, 122);
            this.textBoxEmployeeExperience.Name = "textBoxEmployeeExperience";
            this.textBoxEmployeeExperience.Size = new System.Drawing.Size(53, 20);
            this.textBoxEmployeeExperience.TabIndex = 2;
            // 
            // textBoxEmployeeAge
            // 
            this.textBoxEmployeeAge.Location = new System.Drawing.Point(3, 74);
            this.textBoxEmployeeAge.Name = "textBoxEmployeeAge";
            this.textBoxEmployeeAge.Size = new System.Drawing.Size(49, 20);
            this.textBoxEmployeeAge.TabIndex = 1;
            // 
            // textBoxEmployeeName
            // 
            this.textBoxEmployeeName.Location = new System.Drawing.Point(3, 33);
            this.textBoxEmployeeName.Name = "textBoxEmployeeName";
            this.textBoxEmployeeName.Size = new System.Drawing.Size(366, 20);
            this.textBoxEmployeeName.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.buttonDeleteService);
            this.tabPage4.Controls.Add(this.label23);
            this.tabPage4.Controls.Add(this.label22);
            this.tabPage4.Controls.Add(this.label21);
            this.tabPage4.Controls.Add(this.dataGridViewServices);
            this.tabPage4.Controls.Add(this.buttonAddService);
            this.tabPage4.Controls.Add(this.textBoxServiceDescription);
            this.tabPage4.Controls.Add(this.textBoxServicePrice);
            this.tabPage4.Controls.Add(this.textBoxServiceName);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(839, 450);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Услуги";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteService
            // 
            this.buttonDeleteService.Location = new System.Drawing.Point(297, 161);
            this.buttonDeleteService.Name = "buttonDeleteService";
            this.buttonDeleteService.Size = new System.Drawing.Size(97, 65);
            this.buttonDeleteService.TabIndex = 8;
            this.buttonDeleteService.Text = "Удалить услугу";
            this.buttonDeleteService.UseVisualStyleBackColor = true;
            this.buttonDeleteService.Click += new System.EventHandler(this.buttonDeleteService_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(19, 168);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(69, 13);
            this.label23.TabIndex = 7;
            this.label23.Text = "Цена услуги";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(19, 71);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(93, 13);
            this.label22.TabIndex = 6;
            this.label22.Text = "Описание услуги";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(19, 24);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(93, 13);
            this.label21.TabIndex = 5;
            this.label21.Text = "Название услуги";
            // 
            // dataGridViewServices
            // 
            this.dataGridViewServices.AllowUserToAddRows = false;
            this.dataGridViewServices.AllowUserToDeleteRows = false;
            this.dataGridViewServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewServices.Location = new System.Drawing.Point(3, 232);
            this.dataGridViewServices.Name = "dataGridViewServices";
            this.dataGridViewServices.ReadOnly = true;
            this.dataGridViewServices.Size = new System.Drawing.Size(618, 212);
            this.dataGridViewServices.TabIndex = 4;
            // 
            // buttonAddService
            // 
            this.buttonAddService.Location = new System.Drawing.Point(182, 161);
            this.buttonAddService.Name = "buttonAddService";
            this.buttonAddService.Size = new System.Drawing.Size(97, 65);
            this.buttonAddService.TabIndex = 3;
            this.buttonAddService.Text = "Добавить услугу";
            this.buttonAddService.UseVisualStyleBackColor = true;
            this.buttonAddService.Click += new System.EventHandler(this.buttonAddService_Click);
            // 
            // textBoxServiceDescription
            // 
            this.textBoxServiceDescription.Location = new System.Drawing.Point(22, 87);
            this.textBoxServiceDescription.Multiline = true;
            this.textBoxServiceDescription.Name = "textBoxServiceDescription";
            this.textBoxServiceDescription.Size = new System.Drawing.Size(666, 68);
            this.textBoxServiceDescription.TabIndex = 2;
            // 
            // textBoxServicePrice
            // 
            this.textBoxServicePrice.Location = new System.Drawing.Point(22, 184);
            this.textBoxServicePrice.Name = "textBoxServicePrice";
            this.textBoxServicePrice.Size = new System.Drawing.Size(133, 20);
            this.textBoxServicePrice.TabIndex = 1;
            // 
            // textBoxServiceName
            // 
            this.textBoxServiceName.Location = new System.Drawing.Point(22, 40);
            this.textBoxServiceName.Name = "textBoxServiceName";
            this.textBoxServiceName.Size = new System.Drawing.Size(209, 20);
            this.textBoxServiceName.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.buttonDeleteTicket);
            this.tabPage5.Controls.Add(this.dataGridViewTickets);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(839, 450);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Билеты";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteTicket
            // 
            this.buttonDeleteTicket.Location = new System.Drawing.Point(8, 184);
            this.buttonDeleteTicket.Name = "buttonDeleteTicket";
            this.buttonDeleteTicket.Size = new System.Drawing.Size(155, 82);
            this.buttonDeleteTicket.TabIndex = 1;
            this.buttonDeleteTicket.Text = "Удалить выбранный билет ";
            this.buttonDeleteTicket.UseVisualStyleBackColor = true;
            this.buttonDeleteTicket.Click += new System.EventHandler(this.buttonDeleteTicket_Click);
            // 
            // dataGridViewTickets
            // 
            this.dataGridViewTickets.AllowUserToAddRows = false;
            this.dataGridViewTickets.AllowUserToDeleteRows = false;
            this.dataGridViewTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTickets.Location = new System.Drawing.Point(6, 15);
            this.dataGridViewTickets.Name = "dataGridViewTickets";
            this.dataGridViewTickets.ReadOnly = true;
            this.dataGridViewTickets.Size = new System.Drawing.Size(814, 150);
            this.dataGridViewTickets.TabIndex = 0;
            // 
            // buttonEditEmployee
            // 
            this.buttonEditEmployee.Location = new System.Drawing.Point(458, 200);
            this.buttonEditEmployee.Name = "buttonEditEmployee";
            this.buttonEditEmployee.Size = new System.Drawing.Size(85, 59);
            this.buttonEditEmployee.TabIndex = 13;
            this.buttonEditEmployee.Text = "Изменить данные";
            this.buttonEditEmployee.UseVisualStyleBackColor = true;
            this.buttonEditEmployee.Click += new System.EventHandler(this.buttonEditEmployee_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(549, 200);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(96, 59);
            this.buttonSave.TabIndex = 14;
            this.buttonSave.Text = "Сохранить изменения";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 476);
            this.Controls.Add(this.tabControl1);
            this.Name = "AdminForm";
            this.Text = "Интерфейс администратора";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnimals)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEnclosures)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTickets)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxWeight;
        private System.Windows.Forms.TextBox textBoxSpecies;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.TextBox textBoxLifetime;
        private System.Windows.Forms.TextBox textBoxFamily;
        private System.Windows.Forms.TextBox textBoxAge;
        private System.Windows.Forms.TextBox textBoxCountry;
        private System.Windows.Forms.TextBox textBoxAnimalName;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.ComboBox comboBoxWorker;
        private System.Windows.Forms.ComboBox comboBoxGender;
        private System.Windows.Forms.Button buttonAddAnimal;
        private System.Windows.Forms.TextBox textBoxEmployeeSpecialty;
        private System.Windows.Forms.TextBox textBoxEmployeeSalary;
        private System.Windows.Forms.TextBox textBoxEmployeeExperience;
        private System.Windows.Forms.TextBox textBoxEmployeeAge;
        private System.Windows.Forms.TextBox textBoxEmployeeName;
        private System.Windows.Forms.Button buttonAddEmployee;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonAddEnclosure;
        private System.Windows.Forms.ComboBox comboBoxEnclosureAnimal;
        private System.Windows.Forms.ComboBox comboBoxEnclosureWorker;
        private System.Windows.Forms.ComboBox comboBoxEnclosureType;
        private System.Windows.Forms.TextBox textBoxEnclosureFood;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridView dataGridViewAnimals;
        private System.Windows.Forms.Button buttonDeleteAnimal;
        private System.Windows.Forms.DataGridView dataGridViewEmployees;
        private System.Windows.Forms.Button buttonDeleteEmployee;
        private System.Windows.Forms.DataGridView dataGridViewEnclosures;
        private System.Windows.Forms.Button buttonDeleteEnclosure;
        private System.Windows.Forms.DataGridView dataGridViewServices;
        private System.Windows.Forms.Button buttonAddService;
        private System.Windows.Forms.TextBox textBoxServiceDescription;
        private System.Windows.Forms.TextBox textBoxServicePrice;
        private System.Windows.Forms.TextBox textBoxServiceName;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button buttonDeleteService;
        private System.Windows.Forms.Button buttonDeleteTicket;
        private System.Windows.Forms.DataGridView dataGridViewTickets;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonSaveChanges;
        private System.Windows.Forms.Button ResetSearch;
        private System.Windows.Forms.Button buttonEditEmployee;
        private System.Windows.Forms.Button buttonSave;
    }
}
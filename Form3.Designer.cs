namespace АИС_зоопарк
{
    partial class UserForm
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
            this.checkedListBoxServices = new System.Windows.Forms.CheckedListBox();
            this.labelTotalCost = new System.Windows.Forms.Label();
            this.buttonPurchase = new System.Windows.Forms.Button();
            this.comboBoxAnimals = new System.Windows.Forms.ComboBox();
            this.buttonViewAnimalInfo = new System.Windows.Forms.Button();
            this.labelAnimalInfo = new System.Windows.Forms.Label();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedListBoxServices
            // 
            this.checkedListBoxServices.FormattingEnabled = true;
            this.checkedListBoxServices.Location = new System.Drawing.Point(6, 28);
            this.checkedListBoxServices.Name = "checkedListBoxServices";
            this.checkedListBoxServices.Size = new System.Drawing.Size(505, 172);
            this.checkedListBoxServices.TabIndex = 0;
            // 
            // labelTotalCost
            // 
            this.labelTotalCost.AutoSize = true;
            this.labelTotalCost.Location = new System.Drawing.Point(6, 221);
            this.labelTotalCost.Name = "labelTotalCost";
            this.labelTotalCost.Size = new System.Drawing.Size(60, 24);
            this.labelTotalCost.TabIndex = 1;
            this.labelTotalCost.Text = "label1";
            // 
            // buttonPurchase
            // 
            this.buttonPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPurchase.Location = new System.Drawing.Point(114, 142);
            this.buttonPurchase.Name = "buttonPurchase";
            this.buttonPurchase.Size = new System.Drawing.Size(161, 105);
            this.buttonPurchase.TabIndex = 2;
            this.buttonPurchase.Text = "Купить билет";
            this.buttonPurchase.UseVisualStyleBackColor = true;
            this.buttonPurchase.Click += new System.EventHandler(this.buttonPurchase_Click);
            // 
            // comboBoxAnimals
            // 
            this.comboBoxAnimals.FormattingEnabled = true;
            this.comboBoxAnimals.Location = new System.Drawing.Point(6, 76);
            this.comboBoxAnimals.Name = "comboBoxAnimals";
            this.comboBoxAnimals.Size = new System.Drawing.Size(136, 28);
            this.comboBoxAnimals.TabIndex = 3;
            // 
            // buttonViewAnimalInfo
            // 
            this.buttonViewAnimalInfo.Location = new System.Drawing.Point(6, 110);
            this.buttonViewAnimalInfo.Name = "buttonViewAnimalInfo";
            this.buttonViewAnimalInfo.Size = new System.Drawing.Size(136, 86);
            this.buttonViewAnimalInfo.TabIndex = 4;
            this.buttonViewAnimalInfo.Text = "Узнать ";
            this.buttonViewAnimalInfo.UseVisualStyleBackColor = true;
            this.buttonViewAnimalInfo.Click += new System.EventHandler(this.buttonViewAnimalInfo_Click);
            // 
            // labelAnimalInfo
            // 
            this.labelAnimalInfo.AutoSize = true;
            this.labelAnimalInfo.Location = new System.Drawing.Point(157, 22);
            this.labelAnimalInfo.Name = "labelAnimalInfo";
            this.labelAnimalInfo.Size = new System.Drawing.Size(113, 20);
            this.labelAnimalInfo.TabIndex = 5;
            this.labelAnimalInfo.Text = "Информация ";
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(637, 251);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(125, 20);
            this.textBoxFirstName.TabIndex = 6;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(637, 307);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(125, 20);
            this.textBoxLastName.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(111, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Введите имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(111, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Введите фамилию";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonPurchase);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(523, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 253);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Купите билет тут";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkedListBoxServices);
            this.groupBox2.Controls.Add(this.labelTotalCost);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(517, 248);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Выберите услуги:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelAnimalInfo);
            this.groupBox3.Controls.Add(this.buttonViewAnimalInfo);
            this.groupBox3.Controls.Add(this.comboBoxAnimals);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(0, 254);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(517, 199);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Узнайте информацию о животных";
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "UserForm";
            this.Text = "Интерфейс посетителя";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxServices;
        private System.Windows.Forms.Label labelTotalCost;
        private System.Windows.Forms.Button buttonPurchase;
        private System.Windows.Forms.ComboBox comboBoxAnimals;
        private System.Windows.Forms.Button buttonViewAnimalInfo;
        private System.Windows.Forms.Label labelAnimalInfo;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}
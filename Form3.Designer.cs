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
            this.SuspendLayout();
            // 
            // checkedListBoxServices
            // 
            this.checkedListBoxServices.FormattingEnabled = true;
            this.checkedListBoxServices.Location = new System.Drawing.Point(1, 1);
            this.checkedListBoxServices.Name = "checkedListBoxServices";
            this.checkedListBoxServices.Size = new System.Drawing.Size(382, 169);
            this.checkedListBoxServices.TabIndex = 0;
            // 
            // labelTotalCost
            // 
            this.labelTotalCost.AutoSize = true;
            this.labelTotalCost.Location = new System.Drawing.Point(389, 157);
            this.labelTotalCost.Name = "labelTotalCost";
            this.labelTotalCost.Size = new System.Drawing.Size(35, 13);
            this.labelTotalCost.TabIndex = 1;
            this.labelTotalCost.Text = "label1";
            // 
            // buttonPurchase
            // 
            this.buttonPurchase.Location = new System.Drawing.Point(637, 333);
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
            this.comboBoxAnimals.Location = new System.Drawing.Point(1, 291);
            this.comboBoxAnimals.Name = "comboBoxAnimals";
            this.comboBoxAnimals.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAnimals.TabIndex = 3;
            // 
            // buttonViewAnimalInfo
            // 
            this.buttonViewAnimalInfo.Location = new System.Drawing.Point(1, 352);
            this.buttonViewAnimalInfo.Name = "buttonViewAnimalInfo";
            this.buttonViewAnimalInfo.Size = new System.Drawing.Size(121, 86);
            this.buttonViewAnimalInfo.TabIndex = 4;
            this.buttonViewAnimalInfo.Text = "Узнать информацию о животном";
            this.buttonViewAnimalInfo.UseVisualStyleBackColor = true;
            this.buttonViewAnimalInfo.Click += new System.EventHandler(this.buttonViewAnimalInfo_Click);
            // 
            // labelAnimalInfo
            // 
            this.labelAnimalInfo.AutoSize = true;
            this.labelAnimalInfo.Location = new System.Drawing.Point(128, 352);
            this.labelAnimalInfo.Name = "labelAnimalInfo";
            this.labelAnimalInfo.Size = new System.Drawing.Size(91, 13);
            this.labelAnimalInfo.TabIndex = 5;
            this.labelAnimalInfo.Text = "Информация тут";
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(637, 251);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(100, 20);
            this.textBoxFirstName.TabIndex = 6;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(637, 307);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(100, 20);
            this.textBoxLastName.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(634, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Введите имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(634, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Введите фамилию";
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.labelAnimalInfo);
            this.Controls.Add(this.buttonViewAnimalInfo);
            this.Controls.Add(this.comboBoxAnimals);
            this.Controls.Add(this.buttonPurchase);
            this.Controls.Add(this.labelTotalCost);
            this.Controls.Add(this.checkedListBoxServices);
            this.Name = "UserForm";
            this.Text = "Интерфейс посетителя";
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
    }
}
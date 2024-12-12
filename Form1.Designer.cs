namespace АИС_зоопарк
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.admin = new System.Windows.Forms.Button();
            this.user = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // admin
            // 
            this.admin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.admin.Location = new System.Drawing.Point(12, 81);
            this.admin.Name = "admin";
            this.admin.Size = new System.Drawing.Size(273, 135);
            this.admin.TabIndex = 0;
            this.admin.Text = "Войти как администратор";
            this.admin.UseVisualStyleBackColor = true;
            this.admin.Click += new System.EventHandler(this.admin_Click);
            // 
            // user
            // 
            this.user.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.user.Location = new System.Drawing.Point(12, 255);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(273, 114);
            this.user.TabIndex = 1;
            this.user.Text = "Войти как пользователь";
            this.user.UseVisualStyleBackColor = true;
            this.user.Click += new System.EventHandler(this.user_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(314, 450);
            this.Controls.Add(this.user);
            this.Controls.Add(this.admin);
            this.Name = "Form1";
            this.Text = "Зоопарк";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button admin;
        private System.Windows.Forms.Button user;
    }
}


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
        }

        private void admin_Click(object sender, EventArgs e)
        {
            Form2 userForm = new Form2();
            userForm.ShowDialog();
        }

        private void user_Click(object sender, EventArgs e)
        {
            UserForm adminForm = new UserForm();
            adminForm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

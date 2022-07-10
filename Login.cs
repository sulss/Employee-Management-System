using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(UserId.Text==""|| passwordmsk.Text == "")
            {
                MessageBox.Show("Enter User Name or Password !");
            }
            else if(UserId.Text=="Admin" && passwordmsk.Text=="123123")
            {
                this.Hide();
                Home home =new Home();
                home.Show();
            }
            else
            {
                MessageBox.Show("Wrong User Name or Password");
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EmployeeManagement
{
    public partial class Salary : Form
    {
        public Salary()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sule\Documents\MyEmployeeDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
        private void fetchempdata()
        {
            if (empIDsl.Text == "")
            {
                MessageBox.Show("Enter Employee ID");
            }
            else {

                Con.Open();
                string query = "select * from EmployeeTbl where EmpId='" + empIDsl.Text + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {

                    empNamesl.Text = dr["EmpName"].ToString();
                    empPossl.Text = dr["EmpPos"].ToString();



                }
                Con.Close();
            }
        }
            private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            fetchempdata();
        }

        int Dailybase,total;

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("\n SALARY", new Font("Century Gothic", 25, FontStyle.Bold), Brushes.DarkBlue, new Point(230));

             e.Graphics.DrawString("\n Employee ID : " + empIDsl.Text, new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Black, new Point(10, 80));
             e.Graphics.DrawString("\t \n Employee Name : " + empNamesl.Text, new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Black, new Point(10, 110));
             e.Graphics.DrawString("\t \n Position : " + empPossl.Text, new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Black, new Point(10, 140));
             e.Graphics.DrawString("\t \n Work Day : " + empWorkdsl.Text, new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Black, new Point(10, 170));
             e.Graphics.DrawString("\t \n Daily Base : " + Dailybase, new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Black, new Point(10, 200));
             e.Graphics.DrawString("\t \n Salary : " + total, new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Black, new Point(10, 230));
             
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (empPossl.Text == "")
            {
                MessageBox.Show("Select An Employee");
            }
            else if (empWorkdsl.Text == "" || Convert.ToInt32(empWorkdsl.Text) >28)
            {
                MessageBox.Show("Enter A Valid Number of Days");
            }
            else
            {
                if (empPossl.Text == "Manager")
                {
                    Dailybase = 250;
                }
                else if(empPossl.Text=="Senior Developer")
                {
                    Dailybase = 230;
                }
                else if (empPossl.Text == "Junior Developer")
                {
                    Dailybase = 200;
                }
                else if (empPossl.Text == "Accountant")
                {
                    Dailybase = 170;
                }
                else if (empPossl.Text == "Receptionist")
                {
                    Dailybase = 150;
                }
                else 
                {
                    Dailybase = 100;
                }
                total = Dailybase * Convert.ToInt32(empWorkdsl.Text);
                SalarySlip.Text = "\n KUANTUM SİBER GÜVENLİK A.Ş \n \n ID : " +empIDsl.Text + "\n \n Name:"+ empNamesl.Text + "\n \n Position : "+empPossl.Text + "\n \n Work Day :" + empWorkdsl.Text + "\n \n Dailybase :" +Dailybase+"\n \n Salary :"+total;
            }
        }
    }
}

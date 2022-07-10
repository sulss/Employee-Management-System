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
    public partial class ViewEmp : Form
    {
        public ViewEmp()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sule\Documents\MyEmployeeDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void fetchempdata()
        {
            Con.Open();
            string query = "select * from EmployeeTbl where EmpId='" + EmpIDSearch.Text + "'";
            SqlCommand cmd = new SqlCommand(query,Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                empidvl.Text = dr["EmpId"].ToString();
                empaddvl.Text = dr["EmpAdd"].ToString();
                empdobvl.Text = dr["EmpDOB"].ToString();
                empnamevl.Text = dr["EmpName"].ToString();
                empposvl.Text = dr["EmpPos"].ToString();
                empphonvl.Text = dr["EmpPhone"].ToString();
                empgenvl.Text = dr["EmpGen"].ToString();
                empidvl.Visible = true;
                empaddvl.Visible = true;
                empdobvl.Visible = true;
                empnamevl.Visible = true;
                empposvl.Visible = true;
                empphonvl.Visible = true;
                empgenvl.Visible = true;
            }
            Con.Close();
        }
        private void ViewEmp_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            fetchempdata();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("\n EMPLOYEE  SUMMARY",new Font("Century Gothic",25,FontStyle.Bold),Brushes.DarkBlue,new Point(230));

            e.Graphics.DrawString("\n Employee ID : "+empidvl.Text, new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Black, new Point(10,80));
            e.Graphics.DrawString("\t \n Employee Name : " + empnamevl.Text, new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Black, new Point(10,110));
            e.Graphics.DrawString("\t \n Position : " + empposvl.Text, new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Black, new Point(10,140));
            e.Graphics.DrawString("\t \n Gender : " + empgenvl.Text, new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Black, new Point(10,170));
            e.Graphics.DrawString("\t \n Date of Birth: " + empdobvl.Text, new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Black, new Point(10,200));
            e.Graphics.DrawString("\t \n Employee Address : " + empaddvl.Text, new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Black, new Point(10,230));
            e.Graphics.DrawString("\t \n Phone Number : " + empphonvl.Text, new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Black, new Point(10,260));


        }
    }
}

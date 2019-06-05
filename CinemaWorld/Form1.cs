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


namespace CinemaWorld
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int flag = 0;
            string cs = "Data Source=ACER-PC;Initial Catalog=MovieDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            


            string sql = "Select Username,Password from UserData";
            SqlCommand com = new SqlCommand(sql, con);
            SqlDataReader dr = com.ExecuteReader();

            while (dr.Read())
            {
                string un, pw;
                un = dr.GetValue(0).ToString();
                pw = dr.GetValue(1).ToString();

                
                if (textBox1.Text == un && textBox2.Text == pw)
                    flag = 1;

            }

                if (flag == 1)
                {
                    UserHome uh = new UserHome();
                    uh.Show();
                    this.Hide();

                    com.Dispose();
                    dr.Dispose();

                }
               

              
                

            else
            {

                com.Dispose();
                dr.Dispose();
                string sql2 = "Select UsernameA,PasswordA from AdminData";
                SqlCommand com2 = new SqlCommand(sql2, con);
                SqlDataReader dr2 = com2.ExecuteReader();

                while (dr2.Read())
                {
                    string un2, pw2;
                    un2 = dr2.GetValue(0).ToString();
                    pw2 = dr2.GetValue(1).ToString();


                    if (textBox1.Text == un2 && textBox2.Text == pw2)
                        flag = 2;

                }

                if (flag == 2)
                {
                    AdminHome ah = new AdminHome();
                    ah.Show();
                    this.Hide();



                }
                else

                    MessageBox.Show("Invalid username or password","Re-enter",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);


                com.Dispose();

                con.Close();

        }
    }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserHome u = new UserHome();
            u.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome a = new AdminHome();
            a.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Image myimage = new Bitmap(@"D:\Uni\NIBM\Movie\form1.jpg");
            this.BackgroundImage = myimage;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

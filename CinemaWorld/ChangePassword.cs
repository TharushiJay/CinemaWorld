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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminHome a = new AdminHome();
            a.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {

                int flag = 0;

                string cs = "Data Source=ACER-PC;Initial Catalog=MovieDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(cs);
                con.Open();




                string sql = "Select Username, Password from UserData";
                SqlCommand com = new SqlCommand(sql, con);

                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    string un, pw;
                    un = dr.GetValue(0).ToString();
                    pw = dr.GetValue(1).ToString();


                    if (textBox4.Text == un && textBox1.Text == pw)
                        flag = 1;

                }
                dr.Close();
                com.Dispose();

                if (flag == 1)
                {
                    string sql2 = "Update UserData set Password=@Password where Username=@Username";
                    SqlCommand com2 = new SqlCommand(sql2, con);

                    com2.Parameters.AddWithValue("@Password", textBox2.Text);
                    com2.Parameters.AddWithValue("@Username", textBox4.Text);
                    int line = com2.ExecuteNonQuery();
                    com2.Dispose();

                    con.Close();

                    if (line > 0)
                        MessageBox.Show("Password successfully changed", "Password change", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Password change unsuccessful", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Invalid username or password", "Please re-enter", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    textBox2.Text = "";
                    textBox3.Text = "";

                }
            }
            else
            {
                MessageBox.Show("Password mismatch", "Re-enter password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = "";
                textBox3.Text = "";
            }
            this.Hide();
            AdminHome a = new AdminHome();
            a.Show();

        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            Image myimage = new Bitmap(@"D:\Uni\NIBM\Movie\pw.jpg");
            this.BackgroundImage = myimage;
        }
    }
}

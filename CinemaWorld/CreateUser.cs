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
    public partial class CreateUser : Form
    {
        public CreateUser()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox6.Text == textBox7.Text)
                {

                    string cs = "Data Source=ACER-PC;Initial Catalog=MovieDB;Integrated Security=True";
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();




                    string sql = "Insert into UserData values(@Username,@Password,@Name,@Address,@DOB,@NIC)";
                    SqlCommand com = new SqlCommand(sql, con);

                    com.Parameters.AddWithValue("@Username", textBox5.Text);
                    com.Parameters.AddWithValue("@Password", textBox6.Text);
                    com.Parameters.AddWithValue("@Name", textBox1.Text);
                    com.Parameters.AddWithValue("@Address", textBox2.Text);
                    DateTime DOB = dateTimePicker1.Value;
                    com.Parameters.AddWithValue("@DOB", DOB);
                    com.Parameters.AddWithValue("@NIC", textBox4.Text);

                    int line = com.ExecuteNonQuery();
                    com.Dispose();
                    con.Close();

                    if (line > 0)
                        MessageBox.Show("User successfully created!", "Create user", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Error!", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                    this.Hide();
                    AdminHome a = new AdminHome();
                    a.Show();

                }
                else
                {
                    MessageBox.Show("Password mismatch!", "Re-enter password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox6.Text = "";
                    textBox7.Text = "";
                }
            }
        
        catch(Exception ex)
            {
                MessageBox.Show("Please re-enter valid values","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            AdminHome a = new AdminHome();
            a.Show();
            this.Hide();

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if(textBox4.Text.Length==9)
            {
                panel1.Show();

            }
        }

        private void CreateUser_Load(object sender, EventArgs e)
        {
            panel1.Hide();
            Image myimage = new Bitmap(@"D:\Uni\NIBM\Movie\create.JPG");
            this.BackgroundImage = myimage;


        }
    }
}

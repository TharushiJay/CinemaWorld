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
    public partial class DeleteUser : Form
    {
        public DeleteUser()
        {
            InitializeComponent();
        }

        private void DeleteUser_Load(object sender, EventArgs e)
        {
            Image myimage = new Bitmap(@"D:\Uni\NIBM\Movie\delete.jpg");
            this.BackgroundImage = myimage;

            string cs = "Data Source=ACER-PC;Initial Catalog=MovieDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();




            string sql = "Select Username from UserData";
            SqlCommand com = new SqlCommand(sql, con);

            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr.GetValue(0));


            }
            comboBox1.SelectedIndex = 0;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome a = new AdminHome();
            a.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = "Data Source=ACER-PC;Initial Catalog=MovieDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();




            string sql = "Delete from UserData where Username=@Username";
            SqlCommand com = new SqlCommand(sql, con);

            com.Parameters.AddWithValue("@Username", comboBox1.SelectedItem);
           int line= com.ExecuteNonQuery();
           if (line > 0)
               MessageBox.Show("User Deleted!");
           else
               MessageBox.Show("User not deleted");
            com.Dispose();
            con.Close();

            this.Hide();
            AdminHome a = new AdminHome();
            a.Show();

        }
        

    }
}

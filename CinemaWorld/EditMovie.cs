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
    public partial class EditMovie : Form
    {
        public EditMovie()
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
            string cs = "Data Source=ACER-PC;Initial Catalog=MovieDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();




            string sql = "Insert into MovieData values(@Movie)";
            SqlCommand com = new SqlCommand(sql, con);

            com.Parameters.AddWithValue("@Movie", textBox1.Text);

            int line = com.ExecuteNonQuery();
            if (line > 0)
                MessageBox.Show("Movie list successfully updated","Updated",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
            else
                MessageBox.Show("Movie list not updated","Error",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
            com.Dispose();
            con.Close();

            textBox1.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cs = "Data Source=ACER-PC;Initial Catalog=MovieDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();




            string sql = "Delete from MovieData where Movie=@Movie";
            SqlCommand com = new SqlCommand(sql, con);

            com.Parameters.AddWithValue("@Movie", comboBox1.SelectedItem);

            int line = com.ExecuteNonQuery();
            if (line > 0)
                MessageBox.Show("Movie successfully deleted");
            else
                MessageBox.Show("Error");
            com.Dispose();
            con.Close();
        }

        private void EditMovie_Load(object sender, EventArgs e)
        {
            Image myimage = new Bitmap(@"D:\Uni\NIBM\Movie\movie.jpg");
            this.BackgroundImage = myimage;

            string cs = "Data Source=ACER-PC;Initial Catalog=MovieDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();




            string sql = "Select Movie from MovieData";
            SqlCommand com = new SqlCommand(sql, con);

            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr.GetValue(0));


            }
            comboBox1.SelectedIndex = 0;
            con.Close();
        }
    }
}

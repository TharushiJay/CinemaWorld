using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace CinemaWorld
{
    public partial class UserHome : Form
    {
        public UserHome()
        {
            InitializeComponent();

            panel1.Hide();



            if (DateTime.Now.Hour < 10)
                comboBox2.SelectedIndex = 0;
            else if (DateTime.Now.Hour < 13)
                comboBox2.SelectedIndex = 1;
            else if (DateTime.Now.Hour < 16)
                comboBox2.SelectedIndex = 2;
            else if (DateTime.Now.Hour < 19)
                comboBox2.SelectedIndex = 3;
            else if (DateTime.Now.Hour < 22)
                comboBox2.SelectedIndex = 4;
            else
                comboBox2.SelectedIndex = 0;

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form1 f = new Form1();
            f.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void UserHome_Load(object sender, EventArgs e)
        {
            Image myimage = new Bitmap(@"D:\Uni\NIBM\Movie\userhome.jpg");
            this.BackgroundImage = myimage;


            panel1.Hide();

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
            comboBox1.SelectedIndex = -1;
            con.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            panel1.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown3.Value == 0)
                MessageBox.Show("Please enter a valid number of tickets", "Invalid number of tickets", MessageBoxButtons.OK, MessageBoxIcon.Question);
            else {

                if (numericUpDown1.Value + numericUpDown2.Value != numericUpDown3.Value)
                {
                    MessageBox.Show("Invalid number of tickets total tickets. Please re-enter!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    numericUpDown3.Value = 0;
                }
                else
                {
                    this.Size = new Size(900, 400);

                    if (numericUpDown1.Value != 0)
                        listBox1.Items.Add("Full tickets\t" + numericUpDown1.Value.ToString() + "\t" + (numericUpDown1.Value * 200).ToString());

                    if (numericUpDown2.Value != 0)
                        listBox1.Items.Add("Half tickets\t" + numericUpDown2.Value.ToString() + "\t" + (numericUpDown2.Value * 100).ToString());

                    decimal total = (numericUpDown1.Value * 200) + (numericUpDown2.Value * 100);
                    textBox2.Text = total.ToString();


                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Size = new Size(600, 400);
            comboBox1.SelectedIndex = -1;

            panel1.Hide();

            if (DateTime.Now.Hour < 10)
                comboBox2.SelectedIndex = 0;
            else if (DateTime.Now.Hour < 13)
                comboBox2.SelectedIndex = 1;
            else if (DateTime.Now.Hour < 16)
                comboBox2.SelectedIndex = 2;
            else if (DateTime.Now.Hour < 19)
                comboBox2.SelectedIndex = 3;
            else if (DateTime.Now.Hour < 22)
                comboBox2.SelectedIndex = 4;
            else
                comboBox2.SelectedIndex = 0;

            
            numericUpDown1.Value = 0;
            
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            this.dateTimePicker1.Value = DateTime.Now;

            listBox1.Items.Clear();



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            panel1.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             }

        private void button4_Click(object sender, EventArgs e)
        {
            //File.AppendAllText(@"D:\Uni\NIBM\movie.txt", listBox1.Text.ToString() + Environment.NewLine);
            
            /*if (numericUpDown1.Value != 0)
                File.AppendAllText(@"D:\Uni\NIBM\movie2.txt","Full tickets\t" + numericUpDown1.Value.ToString() + "\t" + (numericUpDown1.Value * 200).ToString() + Environment.NewLine);

            if (numericUpDown2.Value != 0)
               File.AppendAllText(@"D:\Uni\NIBM\movie2.txt", "Half tickets\t" + numericUpDown2.Value.ToString() + "\t" + (numericUpDown2.Value * 200).ToString()+Environment.NewLine);
            */
            string cs = "Data Source=ACER-PC;Initial Catalog=MovieDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();




            string sql = "Insert into BillingData values(@Movie,@ShowTime,@Date,@FullTickets,@HalfTickets,@TotalTickets)";
            SqlCommand com = new SqlCommand(sql, con);

            com.Parameters.AddWithValue("@Movie",comboBox1.SelectedItem.ToString());
            com.Parameters.AddWithValue("@ShowTime", comboBox2.SelectedItem.ToString());
            DateTime Date = dateTimePicker1.Value;
            com.Parameters.AddWithValue("@Date", Date);
            com.Parameters.AddWithValue("@FullTickets", numericUpDown1.Value.ToString());
            com.Parameters.AddWithValue("@HalfTickets", numericUpDown2.Value.ToString());
            com.Parameters.AddWithValue("@TotalTickets", numericUpDown3.Value.ToString());


            int line = com.ExecuteNonQuery();
            com.Dispose();
            con.Close();




            if (line > 0)
                MessageBox.Show("Transaction Confirmed!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else
                MessageBox.Show("Transaction error!", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

}

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

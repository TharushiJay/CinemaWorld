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
    public partial class AdminHome : Form
    {
        public AdminHome()
        {
            InitializeComponent();
        }

        private void AdminHome_Load(object sender, EventArgs e)
        {
            Image myimage = new Bitmap(@"D:\Uni\NIBM\Movie\adminhome.jpg");
            this.BackgroundImage = myimage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form1 f = new Form1();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateUser c = new CreateUser();
            c.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangePassword c = new ChangePassword();
            c.Show();
            this.Hide();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            DeleteUser d = new DeleteUser();
            d.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            EditMovie em = new EditMovie();
            em.Show();
            this.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            GenerateReports g = new GenerateReports();
            g.Show();
            this.Hide();

        }
    }
}

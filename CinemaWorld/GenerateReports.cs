using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaWorld
{
    public partial class GenerateReports : Form
    {
        public GenerateReports()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome a = new AdminHome();
            a.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = @"C:\Users\acer\documents\visual studio 2013\Projects\CinemaWorld\CinemaWorld\CrystalReport1.rpt";


        }
    }
}

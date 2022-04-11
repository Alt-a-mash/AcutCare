using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcutCare
{
    public partial class Reporting : Form
    {
        public Reporting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void button17_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "https://twitter.com/");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "https://www.instagram.com/");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "http://www.Facebook.com/");
        }

        private void Reporting_Load(object sender, EventArgs e)
        {
            CrystalReport1 obj = new CrystalReport1();
            DataSet table = new DataSet();
            string conx = ConnectionClass.ConnectionString1;
            SqlConnection con = new SqlConnection(conx);
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter("select * from blood_info", con);
            adp.Fill(table, "blood_info");
            obj.SetDataSource(table);
            crystalReportViewer1.ReportSource = obj;
        }
    }
}

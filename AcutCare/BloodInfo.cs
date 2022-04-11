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

namespace AcutCare
{
    public partial class BloodInfo : Form
    {
        public BloodInfo()
        {
            InitializeComponent();
            this.Opacity = 0.0;
        }
        
        private const int CS_DropShadow = 0X00020000;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DropShadow;
                return cp;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1.0)
            {
                Opacity += 0.25;
            }
            else
            {
                timer2.Stop();
            }
        }

        private void BloodInfo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'acutCareDataSet1.Blood_Info' table. You can move, or remove it, as needed.
            this.blood_InfoTableAdapter.Fill(this.acutCareDataSet1.Blood_Info);
            timer2.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0.0)
            {
                Opacity -= 0.25;
            }
            else
            {
                timer3.Stop();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer3.Start();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "http://www.Facebook.com/");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "https://www.instagram.com/");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "https://twitter.com/");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StockManagement op = new StockManagement();
            op.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gradientColor1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.Visible == false)
            {
                dataGridView1.Visible = true;
                button1.Text = "Close";
            }
            else
            {
                dataGridView1.Visible = false;
                button1.Text = "View Data";
            }
        }
    }
}

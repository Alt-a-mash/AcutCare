using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcutCare
{
    public partial class OpeningPage : Form
    {
        public OpeningPage()
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Label label1 = new Label();
            label1.Text = "AcutCare";
            label1.Font = new Font("Times New Roman",48,FontStyle.Bold);
            label1.Location = new Point(236, 161);
            label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            label1.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void OpeningPage_Load(object sender, EventArgs e)
        {
            timer2.Start();
        }
        

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(this.Opacity < 1.0)
            {
                Opacity += 0.25;
            }
            else
            {
                timer2.Stop();
                timer1.Start();
            }
        }

        private void gradientColor1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            timer1.Stop();
            timer3.Start();
            Index op = new Index();
            op.Show();
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
    }
}

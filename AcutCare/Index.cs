using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AcutCare
{
    public partial class Index : Form
    {

        ArrayList x = new ArrayList();
        public int a = 0;
        public Index()
        {
            InitializeComponent();
            panel3.Hide();
            this.Opacity = 0.0;
            button7.Visible = false;
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            AdminForm op = new AdminForm();
            op.Owner = this;
            op.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            StaffForm op = new StaffForm();
            op.Owner = this;
            op.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (panel3.Visible == false)
            {
                panel3.Show();
                button3.Image = Properties.Resources.up;
            }
            else if (panel3.Visible == true)
            {
                panel3.Hide();
                button3.Image = Properties.Resources.down;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            BloodInfo nx = new BloodInfo();

            if (button8.Enabled == true)
            {
                nx.Show();
                nx.button4.Visible = true;
                nx.button4.Enabled = true;
            }
            else
            {
                nx.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DonorRegister op = new DonorRegister();
            op.Show();
            panel3.Hide();
            button3.Image = Properties.Resources.down;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RecipientForm op = new RecipientForm();
            op.Show();
            panel3.Hide();
            button3.Image = Properties.Resources.down;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
        }

        private void Index_Load(object sender, EventArgs e)
        {
            timer2.Start();
       

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            EventOrganizer op = new EventOrganizer();
            op.Show();


            AdminForm xe = new AdminForm();
            xe.Close();

            StaffForm ex = new StaffForm();
            ex.Close();
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Index_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (panel2.Visible == false)
                panel2.Show();
            else if (panel2.Visible == true)
                panel2.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0.0)
            {
                Opacity -= 0.25;
            }
            else
            {
                timer1.Stop();
                Application.Exit();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (panel2.Visible == false)
                panel2.Show();
            else if (panel2.Visible == true)
                panel2.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            DonorsInfo di = new DonorsInfo();
            di.Show();
            di.button4.Visible = true;
            di.button4.Enabled = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            RecipientsInfo ri = new RecipientsInfo();
            ri.Show();
            ri.button4.Visible = true;
            ri.button4.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            BloodInfo nx = new BloodInfo();
            nx.Show();
            nx.button4.Visible = true;
            nx.button4.Enabled = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            EventOrganizer eg = new EventOrganizer();

            eg.Show();

            eg.button2.Visible = true;

            eg.button3.Visible = true;

            eg.textBox6.Visible = true;

            eg.label7.Visible = true;

            eg.button4.Size = new Size(230, 40);

            eg.button4.Location = new Point(333, 301);

            eg.label7.Visible = true;

            eg.textBox6.Visible = true;

            eg.label1.Visible = true;

            eg.comboBox1.Visible = true;

            eg.panel13.Visible = true;
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

        private void Index_Shown(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;

            notifyIcon1.ShowBalloonTip(5);

            button1.Enabled = true;

            button2.Enabled = true;

            button7.Visible = false;

            button7.Enabled = false;

            button8.Visible = false;

            button8.Enabled = false;

            button9.Visible = false;

            button9.Enabled = false;

            button10.Visible = false;

            button10.Enabled = false;

            button11.Visible = false;

            button11.Enabled = false;

            button12.Visible = false;

            button12.Enabled = false;

            button15.Enabled = false;

            button15.Visible = false;

            button19.Enabled = false;

            button19.Visible = false;

            panel2.Visible = false;

            DonorRegister op = new DonorRegister();

            op.button2.Visible = false;

            op.button2.Enabled = false;

            op.button3.Visible = false;

            op.button3.Enabled = false;

            RecipientForm rf = new RecipientForm();

            rf.button2.Visible = false;

            rf.button2.Enabled = false;

            rf.button3.Visible = false;

            rf.button3.Enabled = false;

            BloodInfo np = new BloodInfo();

            np.button4.Visible = false;

            np.button4.Enabled = false;

            EventOrganizer eg = new EventOrganizer();

            eg.button2.Visible = false;

            eg.button3.Visible = false;

            eg.textBox6.Visible = false;

            eg.label7.Visible = false;

            eg.button4.Size = new Size(505, 40);

            eg.button4.Location = new Point(58, 301);

            eg.label7.Visible = false;

            eg.textBox6.Visible = false;

            eg.label1.Visible = false;

            eg.comboBox1.Visible = false;

            eg.panel13.Visible = false;

            StaffForm sf = new StaffForm();

            sf.Size = new Size(400, 408);

            sf.label5.Location = new Point(51, 9);

            sf.button1.Visible = false;

            sf.button3.Visible = false;

            sf.button5.Visible = false;

            sf.button6.Visible = false;

            sf.button1.Enabled = false;

            sf.button3.Enabled = false;

            sf.button5.Enabled = false;

            sf.button6.Enabled = false;

            sf.button4.Visible = true;

            sf.button4.Enabled = true;

            sf.button13.Location = new Point(13, 354);

            sf.button16.Location = new Point(13, 308);

            sf.button17.Location = new Point(13, 262);

            DonorsInfo di = new DonorsInfo();

            di.button4.Visible = false;

            di.button4.Enabled = false;

            RecipientsInfo ri = new RecipientsInfo();

            ri.button4.Visible = false;

            ri.button4.Enabled = false;
        }

        private void button13_Click_1(object sender, EventArgs e)
        {

        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            StaffForm op = new StaffForm();
            op.Show();

            op.Size = new Size(486, 540);
            op.label5.Location = new Point(95, 9);
            op.button13.Location = new Point(13, 377);
            op.button16.Location = new Point(13, 331);
            op.button17.Location = new Point(13, 285);

            op.button1.Visible = true;
            op.button3.Visible = true;
            op.button5.Visible = true;
            op.button6.Visible = true;

            op.button1.Enabled = true;
            op.button3.Enabled = true;
            op.button5.Enabled = true;
            op.button6.Enabled = true;

            op.button4.Visible = false;
            op.button4.Enabled = false;

            panel2.Hide();
        }

        private void button13_Click_2(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "http://www.Facebook.com/");
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "https://www.instagram.com/");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "https://twitter.com/");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            EventOrganizer op = new EventOrganizer();
            op.Show();
            panel3.Hide();
            button3.Image = Properties.Resources.down;
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            Reporting re = new Reporting();
            re.Show();
        }

        private void gradientColor1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}

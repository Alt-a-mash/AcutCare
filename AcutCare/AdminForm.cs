using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AcutCare
{
    public partial class AdminForm : Form
    {
        public AdminForm()
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


        private void clos_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bac_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
        }

        private void panel1_Enter(object sender, EventArgs e)
        {
            
        }

        private void panel1_Leave(object sender, EventArgs e)
        {
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_Leave(object sender, EventArgs e)
        { }

        private void password_Enter(object sender, EventArgs e)
        {
        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string conx = ConnectionClass.ConnectionString1;
            SqlConnection con = new SqlConnection(conx);
            SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM Admin WHERE Name = '" + textBox1.Text + "' and Password = '" + textBox2.Text + "'", con);
            try
            {
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                  
                    try
                    {
                       
                        SqlCommand cmd1 = new SqlCommand("SELECT Count(*) FROM Blood_Info WHERE Quantity_ltr < 20", con);
                        int count1 = (int)cmd1.ExecuteScalar();
                        if (count1 > 0)
                        {
                            MessageBox.Show("Blood Quantity is getting low please see the table and manage blood stock");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    this.Hide();

                    (this.Owner as Index).button7.Visible = true;

                    (this.Owner as Index).button7.Visible = true;

                    (this.Owner as Index).button8.Visible = true;

                    (this.Owner as Index).button12.Visible = true;

                    (this.Owner as Index).button9.Visible = true;

                    (this.Owner as Index).button11.Visible = true;

                    (this.Owner as Index).button10.Visible = true;

                    (this.Owner as Index).button15.Visible = true;

                    (this.Owner as Index).button19.Visible = true;

                    (this.Owner as Index).button19.Enabled = true;

                    (this.Owner as Index).button7.Enabled = true;

                    (this.Owner as Index).button8.Enabled = true;

                    (this.Owner as Index).button12.Enabled = true;

                    (this.Owner as Index).button9.Enabled = true;

                    (this.Owner as Index).button11.Enabled = true;

                    (this.Owner as Index).button10.Enabled = true;

                    (this.Owner as Index).button15.Enabled = true;

                    (this.Owner as Index).button1.Enabled = false;

                    (this.Owner as Index).button2.Enabled = false;

                    DonorRegister op = new DonorRegister();

                    op.button2.Visible = true;

                    op.button2.Enabled = true;

                    op.button3.Visible = true;

                    op.button3.Enabled = true;

                    RecipientForm rf = new RecipientForm();

                    rf.button2.Visible = true;

                    rf.button2.Enabled = true;

                    rf.button3.Visible = true;

                    rf.button3.Enabled = true;

                    DonorsInfo di = new DonorsInfo();

                    di.button4.Visible = true;

                    di.button4.Enabled = true;

                    RecipientsInfo ri = new RecipientsInfo();

                    ri.button4.Visible = true;

                    ri.button4.Enabled = true;

                    EventOrganizer eg = new EventOrganizer();

                    eg.button2.Visible = true;

                    eg.button3.Visible = true;

                    eg.button4.Size = new Size(230, 40);

                    eg.button4.Location = new Point(333, 301);

                    eg.label7.Visible = true;

                    eg.textBox6.Visible = true;

                    eg.label1.Visible = true;

                    eg.comboBox1.Visible = true;

                    eg.panel13.Visible = true;

                    eg.button4.Text = "Add Event";

                    eg.label12.Text = "Event Manager";

                    textBox1.Clear();

                    textBox2.Clear();
                }
                else if (textBox1.Text.Equals("") && textBox2.Text.Equals(""))
                {
                    MessageBox.Show("Enter Username and Password!");
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password!");

                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void transparentControlBox1_Leave(object sender, EventArgs e)
        {
        }

        private void transparentControlBox1_Enter(object sender, EventArgs e)
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

        private void transparentControlBox1_TextChanged(object sender, EventArgs e)
        {}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer3.Start();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            timer2.Start();

            textBox1.Text = "Enter name here...";
            textBox1.GotFocus += OnFocus1;
            textBox1.LostFocus += OnDefocus1;

            textBox2.Text = "Password...";
            textBox2.GotFocus += OnFocus2;
            textBox2.LostFocus += OnDefocus2;
        }

        private void OnFocus1(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter name here...")
            {
                textBox1.Text = "";
            }
            textBox1.ForeColor = Color.Black;

        }

        private void OnFocus2(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password...")
            {
                textBox2.Text = "";
            }
            textBox2.ForeColor = Color.Black;
            textBox2.PasswordChar = '\u25CF';
        }

        private void OnDefocus1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Enter name here...";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void OnDefocus2(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2.Text = "password...";
                textBox2.ForeColor = Color.Silver;
            }
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
                this.Close();
            }
        }

        private void gradientColor1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome","http://www.Facebook.com/");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "https://www.instagram.com/");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "https://twitter.com/");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '\u25CF')
            {
                textBox2.PasswordChar = '\0';
            }
            else if(textBox2.PasswordChar == '\0')
            {

                textBox2.PasswordChar = '\u25CF';
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AcutCare
{
    public partial class EventOrganizer : Form
    {
        public EventOrganizer()
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
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

        private void EventOrganizer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'acutCareDataSet1.Events' table. You can move, or remove it, as needed.
            this.eventsTableAdapter1.Fill(this.acutCareDataSet1.Events);

            timer2.Start();

            textBox1.Text = "Enter Id here...";
            textBox1.GotFocus += OnFocus1;
            textBox1.LostFocus += OnDefocus1;

            textBox2.Text = "Enter Name here...";
            textBox2.GotFocus += OnFocus2;
            textBox2.LostFocus += OnDefocus2;

            textBox4.Text = "Enter Venue here...";
            textBox4.GotFocus += OnFocus4;
            textBox4.LostFocus += OnDefocus4;

            textBox5.Text = "Enter No. of Volunteers here...";
            textBox5.GotFocus += OnFocus5;
            textBox5.LostFocus += OnDefocus5;

            textBox6.Text = "Enter Blood Amount here...";
            textBox6.GotFocus += OnFocus6;
            textBox6.LostFocus += OnDefocus6;

            comboBox1.Text = "Pending";
            comboBox1.GotFocus += OnFocusc1;
            comboBox1.LostFocus += OnDefocusc1;
        }

        private void OnFocus1(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter Id here...")
            {
                textBox1.Text = "";
            }
            textBox1.ForeColor = Color.Black;

        }

        private void OnDefocus1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Enter Id here...";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void OnFocus2(object sender, EventArgs e)
        {
            if (textBox2.Text == "Enter Name here...")
            {
                textBox2.Text = "";
            }
            textBox2.ForeColor = Color.Black;

        }

        private void OnDefocus2(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2.Text = "Enter Name here...";
                textBox2.ForeColor = Color.Silver;
            }
        }

        private void OnFocus4(object sender, EventArgs e)
        {
            if (textBox4.Text == "Enter Venue here...")
            {
                textBox4.Text = "";
            }
            textBox4.ForeColor = Color.Black;

        }

        private void OnDefocus4(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                textBox4.Text = "Enter Venue here...";
                textBox4.ForeColor = Color.Silver;
            }
        }

        private void OnFocus5(object sender, EventArgs e)
        {
            if (textBox5.Text == "Enter No. of Volunteers here...")
            {
                textBox5.Text = "";
            }
            textBox5.ForeColor = Color.Black;

        }

        private void OnDefocus5(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                textBox5.Text = "Enter No. of Volunteers here...";
                textBox5.ForeColor = Color.Silver;
            }
        }

        private void OnFocus6(object sender, EventArgs e)
        {
            if (textBox6.Text == "Enter Blood Amount here...")
            {
                textBox6.Text = "";
            }
            textBox6.ForeColor = Color.Black;

        }

        private void OnDefocus6(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                textBox6.Text = "Enter Blood Amount here...";
                textBox6.ForeColor = Color.Silver;
            }
        }

        private void OnFocusc1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Pending")
            {
                comboBox1.Text = "";
            }
            comboBox1.ForeColor = Color.Black;

        }

        private void OnDefocusc1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                comboBox1.Text = "Pending";
                comboBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string conx = ConnectionClass.ConnectionString1;
            SqlConnection con = new SqlConnection(conx);

            if (textBox1.Text == "" || textBox2.Text == ""|| textBox5.Text == "" || textBox4.Text == "" || textBox1.Text == "Enter Id here..." || textBox2.Text == "Enter Name here..." || textBox5.Text == "Enter No. of Volunteers here..." || textBox4.Text == "Enter Venue here...")
            {
                MessageBox.Show("Insert all Data!");
            }
            else
            {
                MessageBoxButtons b = MessageBoxButtons.OK;
                DialogResult r = MessageBox.Show("Are you sure?", "Submit!", b, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.OK)
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("insert into Events (Event_Id,Organizer,Date_of_Donation,Venue,Volunteers,Amount_of_Blood_Collected) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + dateTimePicker1.Value.Date + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')", con);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Event Registered");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        dateTimePicker1.Value = DateTime.Now;
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
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            string conx = ConnectionClass.ConnectionString1;
            SqlConnection con = new SqlConnection(conx);
            if (textBox1.Text == "" || textBox2.Text == "" || textBox5.Text == "" || textBox4.Text == "" || textBox1.Text == "Enter Id here..." || textBox2.Text == "Enter Name here..." || textBox5.Text == "Enter No. of Volunteers here..." || textBox4.Text == "Enter Venue here...")
            {
                MessageBox.Show("Insert all Data!");
            }
            else
            {
                MessageBoxButtons b = MessageBoxButtons.OK;
                DialogResult r = MessageBox.Show("Are you sure?", "Update!", b, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.OK)
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM Events WHERE Event_Id = '" + textBox1.Text + "'", con);

                        con.Open();
                        int count = (int)cmd.ExecuteScalar();
                        if (count > 0)
                        {
                            try
                            {
                                con.Open();
                                SqlCommand cmd1 = new SqlCommand("UPDATE Events SET Organizer=('" + textBox2.Text + "'), Venue=('" + textBox4.Text + "'), Amount_of_Blood_Collected=('" + textBox6.Text + "'), Volunteers=('" + textBox5.Text + "'), Date_of_Donation=('" + dateTimePicker1.Value.Date + "'), Status=('" + comboBox1.Text + "') where Event_Id=('" + textBox1.Text + "')", con);

                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Updataed");
                                textBox1.Clear();
                                textBox2.Clear();
                                textBox4.Clear();
                                textBox5.Clear();
                                textBox6.Clear();
                                comboBox1.Text = "Pending";
                                dateTimePicker1.Value = DateTime.Now;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                        {

                            MessageBox.Show("Incorrect ID");
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
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string conx = ConnectionClass.ConnectionString1;
            SqlConnection con = new SqlConnection(conx);
            if (textBox1.Text == "" || textBox1.Text == "Enter Id here...")
            {
                MessageBox.Show("Insert Id!");
            }
            else
            {
                MessageBoxButtons b = MessageBoxButtons.OK;
                DialogResult r = MessageBox.Show("Are you sure?", "Delete!", b, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.OK)
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM Events WHERE Event_Id = '" + textBox1.Text + "'", con);

                        con.Open();
                        int count = (int)cmd.ExecuteScalar();
                        if (count > 0)
                        {
                            try
                            {
                                con.Open();
                                SqlCommand cmd1 = new SqlCommand("DELETE FROM Events where Event_Id=('" + textBox1.Text + "')", con);
                                cmd1.ExecuteNonQuery();
                                MessageBox.Show("Event Deleted");

                                textBox1.Clear();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                        {

                            MessageBox.Show("Incorrect ID");
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
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer3.Start();
            this.Hide();
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

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(dataGridView1.Visible == false)
            {
                dataGridView1.Visible = true;
                button1.Text = "C\nl\no\ns\ne";
                button1.Location = new Point(643, 358);
                button1.Size = new Size(40, 165);
            }
            else
            {
                dataGridView1.Visible = false;
                button1.Text = "View Data";
                button1.Location = new Point(58, 358);
                button1.Size = new Size(625, 40);
            }
        }
    }
}

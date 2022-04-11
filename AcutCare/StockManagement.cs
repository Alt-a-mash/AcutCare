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
    public partial class StockManagement : Form
    {
        public StockManagement()
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

        private void StockManagement_Load(object sender, EventArgs e)
        {
            timer2.Start();

            textBox1.Text = "Write Id here...";
            textBox1.GotFocus += OnFocus1;
            textBox1.LostFocus += OnDefocus1;

            textBox4.Text = "Enter Blood quantity...";
            textBox4.GotFocus += OnFocus4;
            textBox4.LostFocus += OnDefocus4;

            comboBox1.Text = "Select Blood Group...";
            comboBox1.GotFocus += OnFocusc1;
            comboBox1.LostFocus += OnDefocusc1;
        }

        private void OnFocus1(object sender, EventArgs e)
        {
            if (textBox1.Text == "Write Id here...")
            {
                textBox1.Text = "";
            }
            textBox1.ForeColor = Color.Black;

        }

        private void OnDefocus1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Write Id here...";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void OnFocus4(object sender, EventArgs e)
        {
            if (textBox4.Text == "Enter Blood quantity...")
            {
                textBox4.Text = "";
            }
            textBox4.ForeColor = Color.Black;

        }

        private void OnDefocus4(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                textBox4.Text = "Enter Blood quantity...";
                textBox4.ForeColor = Color.Silver;
            }
        }

        private void OnFocusc1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Select Blood Group...")
            {
                comboBox1.Text = "";
            }
            comboBox1.ForeColor = Color.Black;

        }

        private void OnDefocusc1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                comboBox1.Text = "Select Blood Group...";
                comboBox1.ForeColor = Color.Silver;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Equals("AB+"))
            {
                textBox1.Text = "1";
            }
            if (comboBox1.Text.Equals("AB-"))
            {
                textBox1.Text = "2";
            }
            if (comboBox1.Text.Equals("B+"))
            {
                textBox1.Text = "3";
            }
            if (comboBox1.Text.Equals("B-"))
            {
                textBox1.Text = "4";
            }
            if (comboBox1.Text.Equals("A+"))
            {
                textBox1.Text = "5";
            }
            if (comboBox1.Text.Equals("A-"))
            {
                textBox1.Text = "6";
            }
            if (comboBox1.Text.Equals("O+"))
            {
                textBox1.Text = "7";
            }
            if (comboBox1.Text.Equals("O-"))
            {
                textBox1.Text = "8";
            }

            string conx = ConnectionClass.ConnectionString1;
            SqlConnection con = new SqlConnection(conx);

            if (comboBox1.Text == "Select Blood Group" || textBox4.Text == "")
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
                        SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM Blood_Info WHERE Blood_Id = '" + textBox1.Text + "'", con);

                        con.Open();
                        int count = (int)cmd.ExecuteScalar();
                        if (count > 0)
                        {
                            try
                            {
                                SqlCommand cmd1 = new SqlCommand("update Blood_Info set Date_of_Collection=('" + dateTimePicker1.Value.Date + "'),Expiry_Date=('" + dateTimePicker2.Value.Date + "'),Quantity_ltr=( Quantity_ltr + '" + textBox4.Text + "') where Blood_Id=('" + textBox1.Text + "')", con);

                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Data Updated!");

                                textBox1.Clear();
                                textBox4.Clear();
                                comboBox1.Text = "Select Blood Group";
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Equals("AB+"))
            {
                textBox1.Text = "1";
                textBox1.TextAlign = HorizontalAlignment.Center;
            }
            else if (comboBox1.Text.Equals("AB-"))
            {
                textBox1.Text = "2";
                textBox1.TextAlign = HorizontalAlignment.Center;
            }
            else if (comboBox1.Text.Equals("B+"))
            {
                textBox1.Text = "3";
                textBox1.TextAlign = HorizontalAlignment.Center;
            }
            else if (comboBox1.Text.Equals("B-"))
            {
                textBox1.Text = "4";
                textBox1.TextAlign = HorizontalAlignment.Center;
            }
            else if (comboBox1.Text.Equals("A+"))
            {
                textBox1.Text = "5";
                textBox1.TextAlign = HorizontalAlignment.Center;
            }
            else if (comboBox1.Text.Equals("A-"))
            {
                textBox1.Text = "6";
                textBox1.TextAlign = HorizontalAlignment.Center;
            }
            else if (comboBox1.Text.Equals("O+"))
            {
                textBox1.Text = "7";
                textBox1.TextAlign = HorizontalAlignment.Center;
            }
            else if (comboBox1.Text.Equals("O-"))
            {
                textBox1.Text = "8";
                textBox1.TextAlign = HorizontalAlignment.Center;
            }
            else
            {
                MessageBox.Show("Wrong Blood Group Selected!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer3.Start();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "https://twitter.com/");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "http://www.Facebook.com/");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "https://www.instagram.com/");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            dateTimePicker2.Value = dateTimePicker1.Value.AddDays(30);
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            
        }
    }
}

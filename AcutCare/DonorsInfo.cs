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
    public partial class DonorsInfo : Form
    {
        public DonorsInfo()
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

        private void DonorsInfo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'acutCareDataSet1.Donors' table. You can move, or remove it, as needed.
            this.donorsTableAdapter.Fill(this.acutCareDataSet1.Donors);
            timer2.Start();

            //Placeholder
            textBox1.Text = "Enter here...";
            textBox1.GotFocus += OnFocus1;
            textBox1.LostFocus += OnDefocus1;

            comboBox1.Text = "Select...";
            comboBox1.GotFocus += OnFocusc1;
            comboBox1.LostFocus += OnDefocusc1;
        }

        private void OnFocus1(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter here...")
            {
                textBox1.Text = "";
            }
            textBox1.ForeColor = Color.Black;

        }

        private void OnDefocus1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Enter here...";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void OnFocusc1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Select...")
            {
                comboBox1.Text = "";
            }
            comboBox1.ForeColor = Color.Black;

        }

        private void OnDefocusc1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                comboBox1.Text = "Select...";
                comboBox1.ForeColor = Color.Silver;
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

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DonorRegister op = new DonorRegister();
            op.Show();
            op.button2.Visible = true;
            op.button2.Enabled = true;
            op.button3.Visible = true;
            op.button3.Enabled = true;
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string conx = ConnectionClass.ConnectionString1;
            SqlConnection con = new SqlConnection(conx);

            if (comboBox1.Text == "Select")
            {
                MessageBox.Show("Select what to search!");
            }
            else if (comboBox1.Text == "Donor_Id")
            {
                SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM Donors WHERE Donor_Id = '" + textBox1.Text + "'", con);
                try
                {
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        try
                        {

                            string query = "select * from Donors where Donor_Id=('" + textBox1.Text + "') ";
                            SqlDataAdapter sda = new SqlDataAdapter(query, con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                        MessageBox.Show("No Record!");
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
            else if (comboBox1.Text == "Name")
            {
                SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM Donors WHERE Name = '" + textBox1.Text + "'", con);
                try
                {
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        try
                        {

                            string query = "select * from Donors where Name=('" + textBox1.Text + "') ";
                            SqlDataAdapter sda = new SqlDataAdapter(query, con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                        MessageBox.Show("No Record!");
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
            else if (comboBox1.Text == "Blood_Group")
            {
                SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM Donors WHERE Blood_Group = '" + textBox1.Text + "'", con);
                try
                {
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        try
                        {

                            string query = "select * from Donors where Blood_Group=('" + textBox1.Text + "') ";
                            SqlDataAdapter sda = new SqlDataAdapter(query, con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                        MessageBox.Show("No Record!");
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
            else if (comboBox1.Text == "Disease")
            {
                SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM Donors WHERE Disease = '" + textBox1.Text + "'", con);
                try
                {
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        try
                        {

                            string query = "select * from Donors where Disease=('" + textBox1.Text + "') ";
                            SqlDataAdapter sda = new SqlDataAdapter(query, con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                        MessageBox.Show("No Record!");
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
            else if (comboBox1.Text == "Blood_Id")
            {
                SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM Donors WHERE Blood_Id = '" + textBox1.Text + "'", con);
                try
                {
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        try
                        {

                            string query = "select * from Donors where Blood_Id=('" + textBox1.Text + "') ";
                            SqlDataAdapter sda = new SqlDataAdapter(query, con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                        MessageBox.Show("No Record!");
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
            else if (comboBox1.Text == "Event_Id")
            {
                SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM Donors WHERE Event_Id = '" + textBox1.Text + "'", con);
                try
                {
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        try
                        {

                            string query = "select * from Donors where Event_Id=('" + textBox1.Text + "') ";
                            SqlDataAdapter sda = new SqlDataAdapter(query, con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                        MessageBox.Show("No Record!");
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
            else if (comboBox1.Text == "City")
            {
                SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM Donors WHERE City = '" + textBox1.Text + "'", con);
                try
                {
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        try
                        {

                            string query = "select * from Donors where City=('" + textBox1.Text + "') ";
                            SqlDataAdapter sda = new SqlDataAdapter(query, con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                        MessageBox.Show("No Record!");
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

        private void gradientColors1_Paint(object sender, PaintEventArgs e)
        {

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.Visible == false)
            {
                dataGridView1.Visible = true;
                button1.Text = "C\nl\no\ns\ne";
            }
            else
            {
                dataGridView1.Visible = false;
                button1.Text = "View Data";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

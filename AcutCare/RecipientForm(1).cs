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
    public partial class RecipientForm : Form
    {
        String Gender;

        public RecipientForm()
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
            this.Close();
        }

        private void bac_Click(object sender, EventArgs e)
        {
            Index bk = new Index();
            bk.Show();
            this.Hide();
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

        private void button14_Click(object sender, EventArgs e)
        {
        }

        private void RecipientForm_Load(object sender, EventArgs e)
        {

            timer2.Start();
            
            //Placeholder
            textBox1.Text = "Enter Id here...";
            textBox1.GotFocus += OnFocus1;
            textBox1.LostFocus += OnDefocus1;

            textBox2.Text = "Enter Name here...";
            textBox2.GotFocus += OnFocus2;
            textBox2.LostFocus += OnDefocus2;

            maskedTextBox1.Text = "(999) 999-9999";
            maskedTextBox1.GotFocus += OnFocusm1;
            maskedTextBox1.LostFocus += OnDefocusm1;

            textBox6.Text = "Enter Address here...";
            textBox6.GotFocus += OnFocus6;
            textBox6.LostFocus += OnDefocus6;

            textBox7.Text = "someone@something.com";
            textBox7.GotFocus += OnFocus7;
            textBox7.LostFocus += OnDefocus7;

            textBox9.Text = "Enter Blood Id here...";
            textBox9.GotFocus += OnFocus9;
            textBox9.LostFocus += OnDefocus9;

            textBox10.Text = "Enter Disease...";
            textBox10.GotFocus += OnFocus10;
            textBox10.LostFocus += OnDefocus10;

            comboBox2.Text = "Select Blood Group...";
            comboBox2.GotFocus += OnFocusc2;
            comboBox2.LostFocus += OnDefocusc2;

            comboBox1.Text = "Select Event...";
            comboBox1.GotFocus += OnFocusc1;
            comboBox1.LostFocus += OnDefocusc1;

            comboBox3.Text = "Select City...";
            comboBox3.GotFocus += OnFocusc3;
            comboBox3.LostFocus += OnDefocusc3;

            string conx = ConnectionClass.ConnectionString1;
            SqlConnection con = new SqlConnection(conx);
            try
            {
                con.Open();
                string selectquery = "select * from Events";

                SqlCommand cmd = new SqlCommand(selectquery, con);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string rn = dr.GetString(1);
                    comboBox1.Items.Add(rn);

                }

                string selectquery1 = "select * from Recipients";
                SqlCommand cmd1 = new SqlCommand(selectquery1, con);
                dr.Close();
                SqlDataReader dr1 = cmd1.ExecuteReader();

                while (dr1.Read())
                {
                    int rn2 = dr1.GetInt32(0);
                    int h = rn2 + 1;
                    textBox1.Text = h.ToString();
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

        private void OnFocusm1(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "(999) 999-9999")
            {
                maskedTextBox1.Text = "";
            }
            maskedTextBox1.ForeColor = Color.Black;

        }

        private void OnDefocusm1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maskedTextBox1.Text))
            {
                maskedTextBox1.Text = "(999) 999-9999";
                maskedTextBox1.ForeColor = Color.Silver;
            }
        }

        private void OnFocus6(object sender, EventArgs e)
        {
            if (textBox6.Text == "Enter Address here...")
            {
                textBox6.Text = "";
            }
            textBox6.ForeColor = Color.Black;

        }

        private void OnDefocus6(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                textBox6.Text = "Enter Address here...";
                textBox6.ForeColor = Color.Silver;
            }
        }

        private void OnFocus7(object sender, EventArgs e)
        {
            if (textBox7.Text == "someone@something.com")
            {
                textBox7.Text = "";
            }
            textBox7.ForeColor = Color.Black;

        }

        private void OnDefocus7(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox7.Text))
            {
                textBox7.Text = "someone@something.com";
                textBox7.ForeColor = Color.Silver;
            }
        }

        private void OnFocus9(object sender, EventArgs e)
        {
            if (textBox9.Text == "Enter Blood Id here...")
            {
                textBox9.Text = "";
            }
            textBox9.ForeColor = Color.Black;

        }

        private void OnDefocus9(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox9.Text))
            {
                textBox9.Text = "Enter Blood Id here...";
                textBox9.ForeColor = Color.Silver;
            }
        }

        private void OnFocus10(object sender, EventArgs e)
        {
            if (textBox10.Text == "Enter Disease...")
            {
                textBox10.Text = "";
            }
            textBox10.ForeColor = Color.Black;

        }

        private void OnDefocus10(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox10.Text))
            {
                textBox10.Text = "Enter Disease...";
                textBox10.ForeColor = Color.Silver;
            }
        }

        private void OnFocusc2(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Select Blood Group...")
            {
                comboBox2.Text = "";
            }
            comboBox2.ForeColor = Color.Black;

        }

        private void OnDefocusc2(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox2.Text))
            {
                comboBox2.Text = "Select Blood Group...";
                comboBox2.ForeColor = Color.Silver;
            }
        }

        private void OnFocusc1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Select Event...")
            {
                comboBox1.Text = "";
            }
            comboBox1.ForeColor = Color.Black;

        }

        private void OnDefocusc1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                comboBox1.Text = "Select Event...";
                comboBox1.ForeColor = Color.Silver;
            }
        }

        private void OnFocusc3(object sender, EventArgs e)
        {
            if (comboBox3.Text == "Select City...")
            {
                comboBox3.Text = "";
            }
            comboBox3.ForeColor = Color.Black;

        }

        private void OnDefocusc3(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox3.Text))
            {
                comboBox3.Text = "Select City...";
                comboBox3.ForeColor = Color.Silver;
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
        }

        private void timer2_Tick_1(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void gradientColor1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
        }

        private void textBox7_Validating(object sender, CancelEventArgs e)
        {

            Regex numberchk = new Regex(@"^([A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,})$");

            if (textBox7.Text == string.Empty || textBox7.Text == "someone@something.com")
            {
                errorProvider1.SetError(textBox7, "Please write your e-mail address!");
                errorProvider2.SetError(textBox7, "");
                errorProvider3.SetError(textBox7, "");
            }
            else
            {
                if (numberchk.IsMatch(textBox7.Text))
                {
                    errorProvider1.SetError(textBox7, "");
                    errorProvider2.SetError(textBox7, "");
                    errorProvider3.SetError(textBox7, "Correct!");
                }
                else
                {
                    errorProvider1.SetError(textBox7, "");
                    errorProvider2.SetError(textBox7, "Wrong syntax!");
                    errorProvider3.SetError(textBox7, "");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Gender Selection through Radio Buttons
            if (radioButton1.Checked)
            {
                Gender = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                Gender = radioButton2.Text;
            }

            //Blood Id through Blood Group
            if (comboBox2.Text.Equals("AB+"))
            {
                textBox9.Text = "1";
            }
            else if (comboBox2.Text.Equals("AB-"))
            {
                textBox9.Text = "2";
            }
            else if (comboBox2.Text.Equals("B+"))
            {
                textBox9.Text = "3";
            }
            else if (comboBox2.Text.Equals("B+=-"))
            {
                textBox9.Text = "4";
            }
            else if (comboBox2.Text.Equals("A+"))
            {
                textBox9.Text = "5";
            }
            else if (comboBox2.Text.Equals("A-"))
            {
                textBox9.Text = "6";
            }
            else if (comboBox2.Text.Equals("O+"))
            {
                textBox9.Text = "7";
            }
            else if (comboBox2.Text.Equals("O-"))
            {
                textBox9.Text = "8";
            }

            Regex numberchk = new Regex(@"^([A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,})$");
            //Database Connection
            string conx = ConnectionClass.ConnectionString1;
            SqlConnection con = new SqlConnection(conx);


            if (textBox1.Text == "" || textBox2.Text == "" || maskedTextBox1.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox9.Text == "" || comboBox2.Text == "" || comboBox1.Text == "" || comboBox3.Text == "" || textBox1.Text == "Enter Id here..." || textBox2.Text == "Enter Name here..." || maskedTextBox1.Text == "(999) 999-9999" || textBox6.Text == "Enter Address here..." || textBox7.Text == "someone@something.com" || textBox9.Text == "Enter Blood Id here..." || comboBox2.Text == "Select Blood Group" || comboBox1.Text == "Select Event" || comboBox3.Text == "Select City")
            {
                MessageBox.Show("Insert Data!");
            }
            else
            {
                if (numberchk.IsMatch(textBox7.Text))
                {
                    MessageBoxButtons b = MessageBoxButtons.OK;
                    DialogResult r = MessageBox.Show("Are you sure?", "Submit!", b, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (r == DialogResult.OK)
                    {
                        try
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand("insert into Recipients (Name, Date_of_Birth, Gender, Blood_Group, Address, Contact_No, Email_Address, Disease, Blood_Id, Event_Id, City) values ('" + textBox2.Text + "','" + dateTimePicker1.Value.Date + "','" + Gender + "','" + comboBox2.Text + "','" + textBox6.Text + "','" + maskedTextBox1.Text + "','" + textBox7.Text + "','" + textBox10.Text + "','" + textBox9.Text + "','" + comboBox1.Text + "','" + comboBox3.Text + "')", con);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("inserted");

                            string selectquery = "select * from project";

                            SqlCommand cmd1 = new SqlCommand(selectquery, con);

                            SqlDataReader dr = cmd1.ExecuteReader();

                            while (dr.Read())
                            {
                                int rn2 = dr.GetInt32(0);
                                int h = rn2 + 1;
                                textBox1.Text = h.ToString();

                            }

                            textBox1.Clear();
                            textBox2.Clear();
                            maskedTextBox1.Clear();
                            textBox6.Clear();
                            textBox7.Clear();
                            textBox9.Clear();
                            textBox10.Clear();
                            radioButton1.Checked = false;
                            radioButton2.Checked = false;
                            comboBox1.Text = "Select Event";
                            comboBox2.Text = "Select Blood Group";
                            comboBox3.Text = "Select City";
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
                else
                {
                    MessageBox.Show("Incorrect Email!");
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //Gender Selection through Radio Buttons
            if (radioButton1.Checked)
            {
                Gender = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                Gender = radioButton2.Text;
            }

            //Blood Id through Blood Group
            if (comboBox2.Text.Equals("AB+"))
            {
                textBox9.Text = "1";
            }
            else if (comboBox2.Text.Equals("AB-"))
            {
                textBox9.Text = "2";
            }
            else if (comboBox2.Text.Equals("B+"))
            {
                textBox9.Text = "3";
            }
            else if (comboBox2.Text.Equals("B+=-"))
            {
                textBox9.Text = "4";
            }
            else if (comboBox2.Text.Equals("A+"))
            {
                textBox9.Text = "5";
            }
            else if (comboBox2.Text.Equals("A-"))
            {
                textBox9.Text = "6";
            }
            else if (comboBox2.Text.Equals("O+"))
            {
                textBox9.Text = "7";
            }
            else if (comboBox2.Text.Equals("O-"))
            {
                textBox9.Text = "8";
            }

            Regex numberchk = new Regex(@"^([A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,})$");

            //Database Connection
            string conx = ConnectionClass.ConnectionString1;
            SqlConnection con = new SqlConnection(conx);

            if (textBox1.Text == "" || textBox2.Text == "" || maskedTextBox1.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox9.Text == "" || comboBox2.Text == "" || comboBox1.Text == "" || comboBox3.Text == "" || textBox1.Text == "Enter Id here..." || textBox2.Text == "Enter Name here..." || maskedTextBox1.Text == "(999) 999-9999" || textBox6.Text == "Enter Address here..." || textBox7.Text == "someone@something.com" || textBox9.Text == "Enter Blood Id here..." || comboBox2.Text == "Select Blood Group" || comboBox1.Text == "Select Event")
            {
                MessageBox.Show("Insert Data!");
            }
            else
            {
                if (numberchk.IsMatch(textBox7.Text))
                {
                    MessageBoxButtons b = MessageBoxButtons.OK;
                    DialogResult r = MessageBox.Show("Are you sure?", "Update!", b, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (r == DialogResult.OK)
                    {
                        try
                        {
                            SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM Recipients WHERE Recipient_Id = '" + textBox1.Text + "'", con);
                            con.Open();
                            int count = (int)cmd.ExecuteScalar();
                            if (count > 0)
                            {
                                try
                                {
                                    con.Open();
                                    SqlCommand cmd1 = new SqlCommand("UPDATE Recipients SET Name=('" + textBox2.Text + "'),Date_of_Birth=('" + dateTimePicker1.Value.Date + "'),Gender=('" + Gender + "'),Blood_Group=('" + comboBox2.Text + "'),Address=('" + textBox6.Text + "'),ContactNo=('" + maskedTextBox1.Text + "'),Email_Address=('" + textBox7.Text + "'),Diseases=('" + textBox10.Text + "'),Blood_Id=('" + textBox9.Text + "'),Event_Id=('" + comboBox1.Text + "'),City=('" + comboBox3.Text + "') where Recipient_Id=('" + textBox1.Text + "')", con);

                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Updataed");

                                    textBox1.Clear();
                                    textBox2.Clear();
                                    maskedTextBox1.Clear();
                                    textBox6.Clear();
                                    textBox7.Clear();
                                    textBox9.Clear();
                                    textBox10.Clear();
                                    radioButton1.Checked = false;
                                    radioButton2.Checked = false;
                                    comboBox1.Text = "Select Event";
                                    comboBox2.Text = "Select Blood Group";
                                    comboBox3.Text = "Select City";
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
                else
                {
                    MessageBox.Show("Incorrect Email!");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Database Connection
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
                        SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM Recipients WHERE Recipient_Id = '" + textBox1.Text + "'", con);
                        con.Open();
                        int count = (int)cmd.ExecuteScalar();
                        if (count > 0)
                        {
                            try
                            {
                                con.Open();
                                SqlCommand cmd1 = new SqlCommand("DELETE FROM Recipients where Recipient_Id=('" + textBox1.Text + "')", con);
                                cmd1.ExecuteNonQuery();
                                MessageBox.Show("Deleted");

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

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer3.Start();
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

        private void button5_Click(object sender, EventArgs e)
        {
            RecipientsInfo op = new RecipientsInfo();
            op.Show();
        }

		private void textBox9_TextChanged_1(object sender, EventArgs e)
		{

			//Blood Id through Blood Group
			if (comboBox2.Text.Equals("AB+"))
			{
				textBox9.Text = "1";
			}
			else if (comboBox2.Text.Equals("AB-"))
			{
				textBox9.Text = "2";
			}
			else if (comboBox2.Text.Equals("B+"))
			{
				textBox9.Text = "3";
			}
			else if (comboBox2.Text.Equals("B+=-"))
			{
				textBox9.Text = "4";
			}
			else if (comboBox2.Text.Equals("A+"))
			{
				textBox9.Text = "5";
			}
			else if (comboBox2.Text.Equals("A-"))
			{
				textBox9.Text = "6";
			}
			else if (comboBox2.Text.Equals("O+"))
			{
				textBox9.Text = "7";
			}
			else if (comboBox2.Text.Equals("O-"))
			{
				textBox9.Text = "8";
			}
		}

		private void textBox10_TextChanged_1(object sender, EventArgs e)
		{

		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			//Blood Id through Blood Group
			if (comboBox2.Text.Equals("AB+"))
			{
				textBox9.Text = "1";
			}
			else if (comboBox2.Text.Equals("AB-"))
			{
				textBox9.Text = "2";
			}
			else if (comboBox2.Text.Equals("B+"))
			{
				textBox9.Text = "3";
			}
			else if (comboBox2.Text.Equals("B+=-"))
			{
				textBox9.Text = "4";
			}
			else if (comboBox2.Text.Equals("A+"))
			{
				textBox9.Text = "5";
			}
			else if (comboBox2.Text.Equals("A-"))
			{
				textBox9.Text = "6";
			}
			else if (comboBox2.Text.Equals("O+"))
			{
				textBox9.Text = "7";
			}
			else if (comboBox2.Text.Equals("O-"))
			{
				textBox9.Text = "8";
			}
		}

		private void textBox1_TextChanged_1(object sender, EventArgs e)
		{

		}
	}
}

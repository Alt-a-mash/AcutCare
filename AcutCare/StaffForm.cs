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
    public partial class StaffForm : Form
    {
        public StaffForm()
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

        private void StaffForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'acutCareDataSet1.Staff_Accounts' table. You can move, or remove it, as needed.
            this.staff_AccountsTableAdapter.Fill(this.acutCareDataSet1.Staff_Accounts);

            timer2.Start();

            //Placeholder
            textBox1.Text = "Enter id here...";
            textBox1.GotFocus += OnFocus1;
            textBox1.LostFocus += OnDefocus1;

            textBox2.Text = "Enter name here...";
            textBox2.GotFocus += OnFocus2;
            textBox2.LostFocus += OnDefocus2;

            textBox3.Text = "Enter username here...";
            textBox3.GotFocus += OnFocus3;
            textBox3.LostFocus += OnDefocus3;

            textBox4.Text = "Password...";
            textBox4.GotFocus += OnFocus4;
            textBox4.LostFocus += OnDefocus4;
        }

        private void OnFocus1(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter id here...")
            {
                textBox1.Text = "";
            }
            textBox1.ForeColor = Color.Black;

        }

        private void OnDefocus1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Enter id here...";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void OnFocus2(object sender, EventArgs e)
        {
            if (textBox2.Text == "Enter name here...")
            {
                textBox2.Text = "";
            }
            textBox2.ForeColor = Color.Black;

        }

        private void OnDefocus2(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2.Text = "Enter name here...";
                textBox2.ForeColor = Color.Silver;
            }
        }

        private void OnFocus3(object sender, EventArgs e)
        {
            if (textBox3.Text == "Enter username here...")
            {
                textBox3.Text = "";
            }
            textBox3.ForeColor = Color.Black;

        }

        private void OnDefocus3(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                textBox3.Text = "Enter username here...";
                textBox3.ForeColor = Color.Silver;
            }
        }

        private void OnFocus4(object sender, EventArgs e)
        {
            if (textBox4.Text == "Password...")
            {
                textBox4.Text = "";
            }
            textBox4.ForeColor = Color.Black;
            textBox4.PasswordChar = '\u25CF';
        }

        private void OnDefocus4(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                textBox4.Text = "Password...";
                textBox4.ForeColor = Color.Silver;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void password_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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

        private void button1_Click_2(object sender, EventArgs e)
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
                this.Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string conx = ConnectionClass.ConnectionString1;
            SqlConnection con = new SqlConnection(conx);

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Enter all fields!");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM Staff_Accounts WHERE Staff_Id = '" + textBox1.Text + "'", con);
                try
                {
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        try
                        {
                            string selectquery = "select * from Staff_Accounts where Username = ('" + textBox3.Text + "') and Password = ('" + textBox4.Text + "')";

                            SqlCommand cmd1 = new SqlCommand(selectquery, con);

                            SqlDataReader dr = cmd1.ExecuteReader();

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    string rn1 = dr.GetString(2);
                                    string rn2 = dr.GetString(3);

                                    if (rn1.Equals("stock") && rn2.Equals("aptech"))
                                    {
                                        this.Hide();
                                      
                                     

                                        (this.Owner as Index).button7.Visible = true;

                                        (this.Owner as Index).button7.Enabled = true;

                                        (this.Owner as Index).button8.Visible = true;

                                        (this.Owner as Index).button15.Visible = true;

                                        (this.Owner as Index).button8.Enabled = true;

                                        (this.Owner as Index).button1.Enabled = false;

                                        (this.Owner as Index).button2.Enabled = false;

                                        (this.Owner as Index).button15.Enabled = true;

                                        BloodInfo nx = new BloodInfo();

                                        nx.button4.Visible = true;

                                        nx.button4.Enabled = true;

                                    }
                                    else if (rn1.Equals("donor") && rn2.Equals("aptech"))
                                    {
                                        this.Hide();

                                        (this.Owner as Index).button7.Visible = true;

                                        (this.Owner as Index).button7.Enabled = true;

                                        (this.Owner as Index).button9.Visible = true;

                                        (this.Owner as Index).button15.Visible = true;

                                        (this.Owner as Index).button9.Enabled = true;

                                        (this.Owner as Index).button1.Enabled = false;

                                        (this.Owner as Index).button2.Enabled = false;

                                        (this.Owner as Index).button15.Enabled = true;

                                        DonorRegister op = new DonorRegister();

                                        op.button2.Visible = true;

                                        op.button2.Enabled = true;

                                        op.button3.Visible = true;

                                        op.button3.Enabled = true;

                                        DonorsInfo di = new DonorsInfo();

                                        di.button4.Visible = true;

                                        di.button4.Enabled = true;
                                    }
                                    else if (rn1.Equals("recipient") && rn2.Equals("aptech"))
                                    {
                                        this.Hide();

                                        (this.Owner as Index).button7.Visible = true;

                                        (this.Owner as Index).button7.Enabled = true;

                                        (this.Owner as Index).button10.Visible = true;

                                        (this.Owner as Index).button15.Visible = true;

                                        (this.Owner as Index).button10.Enabled = true;

                                        (this.Owner as Index).button1.Enabled = false;

                                        (this.Owner as Index).button2.Enabled = false;

                                        (this.Owner as Index).button15.Enabled = true;

                                        RecipientForm rf = new RecipientForm();

                                        rf.button2.Visible = true;

                                        rf.button2.Enabled = true;

                                        rf.button3.Visible = true;

                                        rf.button3.Enabled = true;

                                        RecipientsInfo ri = new RecipientsInfo();

                                        ri.button4.Visible = true;

                                        ri.button4.Enabled = true;
                                    }
                                    else if (rn1.Equals("blood") && rn2.Equals("aptech"))
                                    {
                                        this.Hide();

                                        (this.Owner as Index).button7.Visible = true;

                                        (this.Owner as Index).button7.Enabled = true;

                                        (this.Owner as Index).button8.Visible = true;

                                        (this.Owner as Index).button15.Visible = true;

                                        (this.Owner as Index).button8.Enabled = true;

                                        (this.Owner as Index).button1.Enabled = false;

                                        (this.Owner as Index).button2.Enabled = false;

                                        (this.Owner as Index).button15.Enabled = true;
                                    }
                                    else if (rn1.Equals("event") && rn2.Equals("aptech"))
                                    {
                                        this.Hide();

                                        (this.Owner as Index).button7.Visible = true;

                                        (this.Owner as Index).button7.Enabled = true;

                                        (this.Owner as Index).button11.Visible = true;

                                        (this.Owner as Index).button15.Visible = true;

                                        (this.Owner as Index).button11.Enabled = true;

                                        (this.Owner as Index).button1.Enabled = false;

                                        (this.Owner as Index).button2.Enabled = false;

                                        (this.Owner as Index).button15.Enabled = true;

                                        EventOrganizer ev = new EventOrganizer();

                                        ev.button2.Visible = true;

                                        ev.button3.Visible = true;

                                        ev.button2.Enabled = true;

                                        ev.button3.Enabled = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Wrong Username or Password!");
                                    }
                                }
                            }
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

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
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

        private void gradientColors1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            string conx = ConnectionClass.ConnectionString1;
            SqlConnection con = new SqlConnection(conx);

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox1.Text == "Enter id here..." || textBox2.Text == "Enter name here..." || textBox3.Text == "Enter username here..." || textBox4.Text == "Password")
            {
                MessageBox.Show("Insert all Data!");
            }
            else
            {
                MessageBoxButtons b = MessageBoxButtons.OK;
                DialogResult r = MessageBox.Show("Are you sure?", "Add!", b, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.OK)
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("insert into Staff_Accounts values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", con);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Staff member added!");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox4.Clear();
                        textBox3.Clear();
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
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox1.Text == "Enter id here..." || textBox2.Text == "Enter name here..." || textBox3.Text == "Enter username here..." || textBox4.Text == "Password")
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
                        SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM Staff_Accounts WHERE Staff_Id = '" + textBox1.Text + "'", con);

                        con.Open();
                        int count = (int)cmd.ExecuteScalar();
                        if (count > 0)
                        {
                            try
                            {
                                con.Open();
                                SqlCommand cmd1 = new SqlCommand("UPDATE Staff_Accounts SET Name=('" + textBox2.Text + "'), Username=('" + textBox3.Text + "'), Password=('" + textBox4.Text + "'), where Staff_Id=('" + textBox1.Text + "')", con);

                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Updataed");
                                textBox1.Clear();
                                textBox2.Clear();
                                textBox4.Clear();
                                textBox3.Clear();
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

        private void button6_Click(object sender, EventArgs e)
        {

            string conx = ConnectionClass.ConnectionString1;
            SqlConnection con = new SqlConnection(conx);
            if (textBox1.Text == "" || textBox1.Text == "Enter id here...")
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
                        SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM Staff_Accounts WHERE Staff_Id = '" + textBox1.Text + "'", con);

                        con.Open();
                        int count = (int)cmd.ExecuteScalar();
                        if (count > 0)
                        {
                            try
                            {
                                con.Open();
                                SqlCommand cmd1 = new SqlCommand("DELETE FROM Staff_Accounts where Staff_Id=('" + textBox1.Text + "')", con);
                                cmd1.ExecuteNonQuery();
                                MessageBox.Show("Staff account Deleted");

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

            if (dataGridView1.Visible == false)
            {
                dataGridView1.Visible = true;
                button5.Text = "Close";
            }
            else
            {
                dataGridView1.Visible = false;
                button5.Text = "View";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox4.PasswordChar == '\u25CF')
            {
                textBox4.PasswordChar = '\0';
            }
            else if (textBox4.PasswordChar == '\0')
            {

                textBox4.PasswordChar = '\u25CF';
            }
        }
    }
}

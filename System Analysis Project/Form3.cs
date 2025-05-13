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


namespace System_Analysis_Project
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LIBRARY_SYSTEM;Integrated Security=True;Encrypt=False"))
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM LIBRARIAN WHERE LIB_NAME='" + textBox2.Text + "' AND LIB_PASS='" + textBox1.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    if (checkBox1.Checked)
                    {
                        Properties.Settings.Default.SavedUser = textBox2.Text;
                        Properties.Settings.Default.SavedPass = textBox1.Text;
                        Properties.Settings.Default.RememberMe = true;
                    }
                    else
                    {

                        Properties.Settings.Default.SavedUser = "";
                        Properties.Settings.Default.SavedPass = "";
                        Properties.Settings.Default.RememberMe = false;
                    }

                    Properties.Settings.Default.Save();

                    MessageBox.Show("Logged in Successfully");
                    Form4 main = new Form4();
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid UserName or Password");
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form5 main2 = new Form5();
            main2.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form6 main2 = new Form6();
            main2.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
            picEye.Image = Properties.Resources.eye_opened;
            isPasswordShown = true;

            if (Properties.Settings.Default.RememberMe)
            {
                textBox2.Text = Properties.Settings.Default.SavedUser;
                textBox1.Text = Properties.Settings.Default.SavedPass;
                checkBox1.Checked = true;
            }

            textBox1.PasswordChar = '*';
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "Invalid UserName");
                e.Cancel = true;
                return;
            }
            errorProvider1.SetError(textBox2, "");
            e.Cancel = false;
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || textBox1.Text.Length < 5)
            {
                errorProvider1.SetError(textBox1, "Invalid UserName");
                e.Cancel = true;
                return;
            }
            errorProvider1.SetError(textBox1, "");
            e.Cancel = false;
        }

        bool isPasswordShown = false;

        private void picEye_Click(object sender, EventArgs e)
        {
            if (isPasswordShown)
            {
                textBox1.UseSystemPasswordChar = true;
                picEye.Image = Properties.Resources.eye_closed;
                isPasswordShown = false;
            }
            else
            {
                textBox1.UseSystemPasswordChar = false;
                picEye.Image = Properties.Resources.eye_opened;
                isPasswordShown = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

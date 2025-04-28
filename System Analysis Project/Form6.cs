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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 main2 = new Form3();
            main2.Show();
            this.Hide();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=MyDB;Integrated Security=True;Encrypt=False");
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "INSERT INTO users(username,password,phone,email) VALUES(@username,@password,@phone,@email)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@password", textBox4.Text);
            cmd.Parameters.AddWithValue("@phone", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@email", textBox2.Text);
            cmd.ExecuteNonQuery();
            Form4 main2 = new Form4();
            main2.Show();
            this.Hide();
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                errorProvider1.SetError(textBox1, "this field is required");
                e.Cancel = true;
                return;
            }
            errorProvider1.SetError(textBox1, "");
            e.Cancel = false;
        }
    }
}

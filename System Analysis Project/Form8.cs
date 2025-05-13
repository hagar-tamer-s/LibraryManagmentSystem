using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace System_Analysis_Project
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Form4 main6 = new Form4();
            main6.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=LIBRARY_SYSTEM;Integrated Security=True;Encrypt=False");
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "INSERT INTO USERR(USER_NAME,USER_PHONE,USER_ADDRESS,USER_NATIONAL_NUM) VALUES(@username,@phone,@address,@nationalNum)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@nationalNum", textBox5.Text);
            cmd.Parameters.AddWithValue("@phone", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@address", textBox2.Text);
            cmd.ExecuteNonQuery();



            string selectQuery = "SELECT USER_NAME, USER_PHONE, USER_ADDRESS, USER_NATIONAL_NUM FROM USERR WHERE USER_NATIONAL_NUM = @nationalNum";
            SqlDataAdapter da = new SqlDataAdapter(selectQuery, con);
            da.SelectCommand.Parameters.AddWithValue("@nationalNum", textBox5.Text); 

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;

            MessageBox.Show("Saved Successfully");
            con.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "DELETE FROM USERR WHERE USER_ID = @userId";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@userId", int.Parse(textBox4.Text)); 
            cmd.ExecuteNonQuery();
            MessageBox.Show("Member record deleted successfully");
            con.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

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

namespace System_Analysis_Project
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Form4 main4 = new Form4();
            main4.Show();
            this.Hide();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Clear();
            textBox4.Clear();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=LIBRARY_SYSTEM;Integrated Security=True;Encrypt=False");
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "INSERT INTO BORROW(BORROW_DATE,RET_DATE,PAID_STATUS,USER_ID,BOOK_ID) VALUES(@borrowDate,@returnDate,@paidStatus,@userId,@bookId)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@borrowDate", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@returnDate", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("@paidStatus", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@userId", textBox3.Text);
            cmd.Parameters.AddWithValue("@bookId", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();


            string selectQuery = "SELECT BORROW_DATE, RET_DATE, PAID_STATUS, USER_ID, BOOK_ID FROM BORROW WHERE USER_ID = @userId AND BOOK_ID = @bookId";
            SqlDataAdapter da = new SqlDataAdapter(selectQuery, con);
            da.SelectCommand.Parameters.AddWithValue("@userId", textBox3.Text); 
            da.SelectCommand.Parameters.AddWithValue("@bookId", int.Parse(textBox1.Text)); 

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;

            MessageBox.Show("Data Saved and Displayed Successfully");
            con.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void _TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "DELETE FROM BORROW WHERE BORROW_ID = @borrowId";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@borrowId", int.Parse(textBox4.Text)); 
            cmd.ExecuteNonQuery();
            MessageBox.Show("Borrow record deleted successfully");
            con.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

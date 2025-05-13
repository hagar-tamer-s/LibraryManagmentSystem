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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 main1 = new Form3();
            main1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 main2 = new Form7();
            main2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form8 main3 = new Form8();
            main3.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 main4 = new Form4();
            main4.Show();
            this.Hide();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=LIBRARY_SYSTEM;Integrated Security=True;Encrypt=False");
        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "INSERT INTO RESERVATIONS(RES_DATE,BOOK_STATUS,BOOK_ID,USER_ID,L_ID) VALUES(@reservationDate,@bookStatus,@bookId,@userId,@lId)";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@reservationDate", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@bookStatus", textBox1.Text);
            cmd.Parameters.AddWithValue("@bookId", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@userId", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@lId", int.Parse(textBox5.Text));
            cmd.ExecuteNonQuery();


            string selectQuery = "SELECT RES_DATE, BOOK_STATUS, BOOK_ID, USER_ID, L_ID FROM RESERVATIONS WHERE USER_ID = @userId AND BOOK_ID = @bookId";
            SqlDataAdapter da = new SqlDataAdapter(selectQuery, con);
            da.SelectCommand.Parameters.AddWithValue("@userId", int.Parse(textBox3.Text)); 
            da.SelectCommand.Parameters.AddWithValue("@bookId", int.Parse(textBox2.Text)); 

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;

            MessageBox.Show("Data Saved and Displayed Successfully");
            con.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            con.Open();
            string query = "DELETE FROM RESERVATIONS WHERE RES_ID = @resId";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@resId", int.Parse(textBox4.Text)); 
            cmd.ExecuteNonQuery();
            MessageBox.Show("Reservation record deleted successfully");
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

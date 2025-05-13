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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
                con.Open();
                string query = "SELECT * FROM BOOK"; 
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            
            
            
                con.Close();
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Form4 main5 = new Form4();
            main5.Show();
            this.Hide();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=LIBRARY_SYSTEM;Integrated Security=True;Encrypt=False");
        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "INSERT INTO BOOK(BOOK_TITLE,BOOK_AUTHOR,BOOK_CATEGORY,COPIES_NUM) VALUES(@TITLE,@AUTHOR,@CATEGORY,@NumOfCopies)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@TITLE", textBox4.Text);
            cmd.Parameters.AddWithValue("@AUTHOR", textBox1.Text);
            cmd.Parameters.AddWithValue("@CATEGORY", textBox3.Text);
            cmd.Parameters.AddWithValue("@NumOfCopies", int.Parse(textBox2.Text));
            cmd.ExecuteNonQuery();

            string selectQuery = "SELECT * FROM BOOK WHERE BOOK_TITLE = @TITLE AND BOOK_AUTHOR = @AUTHOR AND BOOK_CATEGORY=@CATEGORY AND COPIES_NUM=@NumOfCopies ";
            SqlDataAdapter da = new SqlDataAdapter(selectQuery, con);
            da.SelectCommand.Parameters.AddWithValue("@TITLE", textBox4.Text);
            da.SelectCommand.Parameters.AddWithValue("@AUTHOR", textBox1.Text);
            da.SelectCommand.Parameters.AddWithValue("@CATEGORY", textBox3.Text);
            da.SelectCommand.Parameters.AddWithValue("@NumOfCopies", int.Parse(textBox2.Text));

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;

            MessageBox.Show("Saved Successfully");
            con.Close();
            
        }

        private void LoadDataToGridView()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM BOOK", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;



        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "DELETE FROM BOOK WHERE BOOK_TITLE = @bookTitle";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@bookTitle", textBox4.Text); 
            cmd.ExecuteNonQuery();
            MessageBox.Show("Book deleted successfully");
            con.Close();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

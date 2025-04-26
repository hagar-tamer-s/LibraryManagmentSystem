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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
      

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
            Form9 main4 = new Form9();
            main4.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 main5 = new Form3();
            main5.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form10 main6 = new Form10();
            main6.Show();
            this.Hide();
        }
    }
}

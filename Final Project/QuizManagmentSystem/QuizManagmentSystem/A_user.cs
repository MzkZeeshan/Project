using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizManagmentSystem
{
    public partial class A_user : Form
    {

        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\MuhammadZeeshan\Desktop\QuizManagmentSystem\QuizManagmentSystem\QUIZ.mdf;Integrated Security=True;Connect Timeout=30");
        public A_user()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void A_user_Load(object sender, EventArgs e)
        {

            this.textBox5.ReadOnly = true;
            this.textBox6.ReadOnly = true;
            this.textBox7.ReadOnly = true;
            this.textBox3.ReadOnly = true;
            this.textBox2.ReadOnly = true;
            this.textBox1.ReadOnly = true;
            c.Open();
            try
            {
                SqlCommand q = new SqlCommand("Select * from Students ", c);
               SqlDataReader dr = q.ExecuteReader();



                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;

            }
            catch (Exception err)
            {

                MessageBox.Show("Something Wrong Here Plz Contact Your Developer. " + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            c.Close();




            c.Open();
            try
            {
                SqlCommand q = new SqlCommand("Select * from Teacher ", c);
                SqlDataReader dr = q.ExecuteReader();



                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView2.DataSource = dt;

            }
            catch (Exception err)
            {

                MessageBox.Show("Something Wrong Here Plz Contact Your Developer. " + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            c.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
    
                this.textBox5.ReadOnly = false;
                this.textBox6.ReadOnly = false;
                this.textBox7.ReadOnly = false;
             
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
          
                this.textBox5.Text = row.Cells["UserName"].Value.ToString();
                this.textBox6.Text = row.Cells["Password"].Value.ToString();
                this.textBox7.Text = row.Cells["Email"].Value.ToString();
                this.label5.Text = row.Cells["StudentID"].Value.ToString();
            
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            c.Open();
            try
            {
                SqlCommand q = new SqlCommand("update Students set [UserName]=@UserName,[Password]=@Password,[Email]=@Email where [StudentID]=@StudentID", c);
                q.Parameters.AddWithValue("@UserName", textBox5.Text);
                q.Parameters.AddWithValue("@Password", textBox6.Text);
                q.Parameters.AddWithValue("@Email", textBox7.Text);
                q.Parameters.AddWithValue("@StudentID", this.label5.Text);
        

                q.ExecuteNonQuery();
                MessageBox.Show("Student Has Been Updated");

            }
            catch (Exception err)
            {

                MessageBox.Show("Something Wrong Here Plz Contact Your Developer. " + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            c.Close();
            this.textBox5.Clear();
            this.textBox6.Clear();
            this.textBox7.Clear();
            this.label5.Text = "0";
            this.textBox5.ReadOnly = true;
            this.textBox6.ReadOnly = true;
            this.textBox7.ReadOnly = true;




            c.Open();
            try
            {
                SqlCommand q = new SqlCommand("Select * from Students ", c);
                SqlDataReader dr = q.ExecuteReader();



                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;

            }
            catch (Exception err)
            {

                MessageBox.Show("Something Wrong Here Plz Contact Your Developer. " + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            c.Close();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                this.textBox3.ReadOnly = false;
                this.textBox2.ReadOnly = false;
                this.textBox1.ReadOnly = false;

                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];

                this.textBox3.Text = row.Cells["UserName"].Value.ToString();
                this.textBox2.Text = row.Cells["Password"].Value.ToString();
                this.textBox1.Text = row.Cells["Email"].Value.ToString();
                this.label2.Text = row.Cells["TeacherID"].Value.ToString();

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            c.Open();
            try
            {
                SqlCommand q = new SqlCommand("update Teacher set [UserName]=@UserName,[Password]=@Password,[Email]=@Email where [TeacherID]=@TeacherID", c);
                q.Parameters.AddWithValue("@UserName", textBox3.Text);
                q.Parameters.AddWithValue("@Password", textBox2.Text);
                q.Parameters.AddWithValue("@Email", textBox1.Text);
                q.Parameters.AddWithValue("@TeacherID", this.label2.Text);


                q.ExecuteNonQuery();
                MessageBox.Show("Teacher Has Been Updated");

            }
            catch (Exception err)
            {

                MessageBox.Show("Something Wrong Here Plz Contact Your Developer. " + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            c.Close();
            this.textBox3.Clear();
            this.textBox2.Clear();
            this.textBox1.Clear();
            this.label2.Text = "0";
            this.textBox3.ReadOnly = true;
            this.textBox2.ReadOnly = true;
            this.textBox1.ReadOnly = true;



            c.Open();
            try
            {
                SqlCommand q = new SqlCommand("Select * from Teacher ", c);
                SqlDataReader dr = q.ExecuteReader();



                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;

            }
            catch (Exception err)
            {

                MessageBox.Show("Something Wrong Here Plz Contact Your Developer. " + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            c.Close();

        }

        private void label2_Click(object sender, EventArgs e)
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

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            A_ViewE a = new A_ViewE();
            a.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Admin_setting a = new Admin_setting();
            a.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            A_dasboard a = new A_dasboard();
            a.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            A_course a = new A_course();
            a.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            A_user a = new A_user();
            a.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            A_Add a = new A_Add();
            a.Show();
            this.Hide();

        }
    }
}

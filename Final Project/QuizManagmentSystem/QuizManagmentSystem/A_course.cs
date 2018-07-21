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
    public partial class A_course : Form
    {

        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\MuhammadZeeshan\Desktop\QuizManagmentSystem\QuizManagmentSystem\QUIZ.mdf;Integrated Security=True;Connect Timeout=30");
        public A_course()
        {
            InitializeComponent();
        }

        private void A_course_Load(object sender, EventArgs e)
        {
            c.Open();
            try
            {
                SqlCommand q = new SqlCommand("Select * from Course ", c);
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

        private void button17_Click(object sender, EventArgs e)
        {
            
             c.Open();
             try
             {

                 SqlCommand q = new SqlCommand("insert into Course(CourseName) Values (@CourseName)", c);
                 q.Parameters.AddWithValue("@CourseName", this.textBox5.Text);
                
                
                  q.ExecuteNonQuery();
                  MessageBox.Show("Your Record Has been Submitted. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
             }
             catch (Exception err)
             {

                 MessageBox.Show("Something Wrong Here Plz Contact Your Developer. " + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
             }
             c.Close();
             c.Open();
             try
             {
                 SqlCommand q = new SqlCommand("Select * from Course ", c);
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                

                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];

                this.textBox3.Text = row.Cells["CourseName"].Value.ToString();
              
                this.label2.Text = row.Cells["CourseID"].Value.ToString();

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            c.Open();
            try
            {
               SqlCommand q = new SqlCommand("update Course set [CourseName]=@CourseName where [CourseID]=@CourseID", c);
                q.Parameters.AddWithValue("@CourseName", textBox3.Text);
                q.Parameters.AddWithValue("@CourseID", label2.Text);


                q.ExecuteNonQuery();
                MessageBox.Show("Student Has Been Updated");

            }
            catch (Exception err)
            {

                MessageBox.Show("Something Wrong Here Plz Contact Your Developer. " + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            c.Close();
            c.Open();
            try
            {
                SqlCommand q = new SqlCommand("Select * from Course ", c);
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
    }
}

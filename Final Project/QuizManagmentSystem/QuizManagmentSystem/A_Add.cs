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
    public partial class A_Add : Form
    {

        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\MuhammadZeeshan\Desktop\QuizManagmentSystem\QuizManagmentSystem\QUIZ.mdf;Integrated Security=True;Connect Timeout=30; MultipleActiveResultSets=true");
        public string s = "";
        int aa;
        public A_Add()
        {
            InitializeComponent();
        }

        private void A_Add_Load(object sender, EventArgs e)
        {
            this.textBox4.ReadOnly = true; 
            c.Open();
            try
            {
                SqlCommand qq = new SqlCommand("Select count(StudentID) from Students ", c);
               SqlDataReader drr = qq.ExecuteReader();
                if (drr.Read())
                {
                    int a = Convert.ToInt16(drr[0]);
                    a=1+a;
                    this.textBox4.Text = "Std-0" + a.ToString() + "-" + System.DateTime.Today.Year;
                }
                
                SqlCommand q = new SqlCommand("Select CourseName,CourseID from Course", c);
                SqlDataReader dr = q.ExecuteReader();
                while (dr.Read())
                {
                    this.comboBox2.Items.Add(dr["CourseName"]);


                }

                c.Close();
            }
            catch (Exception err)
            {

                MessageBox.Show("Something Wrong Here Plz Contact Your Developer. " + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }

        }

        private void button17_Click(object sender, EventArgs e)
        {
             c.Open();
             try
             {

                 SqlCommand q = new SqlCommand("insert into Students([StudentID],[UserName],[Password],[Email]) values(@StudentID,@UserName,@Password,@Email)", c);
                      q.Parameters.AddWithValue("@StudentID",this.textBox4.Text);
                   q.Parameters.AddWithValue("@UserName",this.textBox5.Text);
                   q.Parameters.AddWithValue("@Password",this.textBox6.Text);
                   q.Parameters.AddWithValue("@Email",this.textBox7.Text);
                
                  q.ExecuteNonQuery();
                  MessageBox.Show("Your Record Has been Submitted. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                  this.textBox5.Clear();
                  this.textBox6.Clear();
                  this.textBox7.Clear();

                SqlCommand qq = new SqlCommand("Select count(StudentID) from Students ", c);
                SqlDataReader drr = qq.ExecuteReader();
                if (drr.Read())
                {
                    int a = Convert.ToInt16(drr[0]);
                    a=1+a;
                    this.textBox4.Text = "Std-0" + a.ToString() + "-" + System.DateTime.Today.Year;
                }
             }
             catch (Exception err)
             {

                  MessageBox.Show("Something Wrong Here Plz Contact Your Developer. " + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
             }
                  c.Close();
                

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
             c.Open();
             try
             {
                 SqlCommand qq = new SqlCommand("Select count(TeacherID) from Teacher ", c);
                 SqlDataReader drr = qq.ExecuteReader();
                 if (drr.Read())
                 {
                     int a = Convert.ToInt16(drr[0]);
                     a = 1 + a;
                     this.textBox1.Text = "Teach-0" + a.ToString() + "-" + System.DateTime.Today.Year;
                 }


                 SqlCommand qqq = new SqlCommand("Select CourseID from Course where CourseName= '"+this.comboBox2.Text+"'", c);
                 SqlDataReader drrr = qqq.ExecuteReader();
                 if (drrr.Read())
                 {
                     aa = Convert.ToInt16(drrr["CourseID"]);
                     
                 }
             }

             catch (Exception err)
             {

                 MessageBox.Show("Something Wrong Here Plz Contact Your Developer. " + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
             }
             c.Close();
            

        }

        private void button12_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
             c.Open();
             try
             {

                 SqlCommand q = new SqlCommand("insert into Teacher([TeacherID],[UserName],[Password],[Email],[CourseID]) values(@TeacherID,@UserName,@Password,@Email,@CourseID)", c);
                 q.Parameters.AddWithValue("@TeacherID", this.textBox1.Text);
                 q.Parameters.AddWithValue("@UserName", this.textBox8.Text);
                 q.Parameters.AddWithValue("@Password", this.textBox3.Text);
                 q.Parameters.AddWithValue("@Email", this.textBox2.Text);
                 q.Parameters.AddWithValue("@CourseID", aa);

                 q.ExecuteNonQuery();
                 MessageBox.Show("Your Record Has been Submitted. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                 this.textBox1.Clear();
                 this.textBox8.Clear();
                 this.textBox3.Clear();
                 this.textBox2.Clear();
             
             }
             catch (Exception err)
             {

                 MessageBox.Show("Something Wrong Here Plz Contact Your Developer. " + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
             }
             c.Close();
            


        }
    }
}

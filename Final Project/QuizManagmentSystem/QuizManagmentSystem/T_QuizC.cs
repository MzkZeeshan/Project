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
    public partial class T_QuizC : Form
    {
        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\MuhammadZeeshan\Desktop\QuizManagmentSystem\QuizManagmentSystem\QUIZ.mdf;Integrated Security=True;Connect Timeout=30; MultipleActiveResultSets=true");
     
        string courseID = "";
        public T_QuizC()
        {
            InitializeComponent();
        }

        private void T_QuizC_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.textBox1.ReadOnly = true;
            this.textBox2.ReadOnly = true;



            this.textBox1.Text = Form1.T_ID;
        
            
            c.Open();
            try
            {
                SqlCommand q = new SqlCommand("Select CourseID from Teacher where TeacherID= '" + Form1.T_ID + "'", c);
                SqlDataReader dr = q.ExecuteReader();
                if (dr.Read())
                {
                    courseID = dr["CourseID"].ToString();
                    SqlCommand qq = new SqlCommand("Select CourseName from Course where CourseID= '" + dr["CourseID"].ToString() + "'", c);
              
                    SqlDataReader drr = qq.ExecuteReader();
                    if(drr.Read())
                    {
                        this.textBox1.Text = drr["CourseName"].ToString();
                    }
                }

            }
            catch (Exception err)
            {

                MessageBox.Show("Something Wrong Here Plz Contact Your Developer. " + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            c.Close();




            c.Open();
            try
            {
                SqlCommand qq = new SqlCommand("Select count(QuizIDs) from QuizID where CourseID= '" + courseID + "'", c);
                SqlDataReader drr = qq.ExecuteReader();
                if (drr.Read())
                {
                    this.textBox2.Text = "0" + drr[0].ToString() + "/" + this.textBox1.Text.Substring(0, 3) +"/"+ System.DateTime.Today.Year;
                }

            }
            catch (Exception err)
            {

                MessageBox.Show("SomethingWron Here Plz Contact Your Developer" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            c.Close();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {
           
            try
            {
                c.Open();
                SqlCommand q = new SqlCommand("insert into Quiz(CourseID,QuizID,Questions,OppA,OppB,OppC,OppD,OppCorrect,QuizName,TeacherID) values(@CourseID,@QuizID,@Questions,@OppA,@OppB,@OppC,@OppD,@OppCorrect,@QuizName,@TeacherID)", c);
                q.Parameters.AddWithValue("@CourseID", courseID);
                q.Parameters.AddWithValue("@QuizID",textBox2.Text);
                q.Parameters.AddWithValue("@Questions",textBox3.Text);
                q.Parameters.AddWithValue("@OppA",textBox5.Text);
                q.Parameters.AddWithValue("@OppB",textBox6.Text);
                q.Parameters.AddWithValue("@OppC", textBox7.Text);
                q.Parameters.AddWithValue("@OppD", textBox6.Text);
                if(radioButton1.Checked)
                {
                    q.Parameters.AddWithValue("@OppCorrect", textBox5.Text);

                }
                else if (radioButton2.Checked)
                {
                    q.Parameters.AddWithValue("@OppCorrect", textBox6.Text);
                }
                else if (radioButton3.Checked)
                {
                    q.Parameters.AddWithValue("@OppCorrect", textBox7.Text);
                }
                else if (radioButton4.Checked)
                {
                    q.Parameters.AddWithValue("@OppCorrect", textBox8.Text);
                }
                else
                {

                }
                
                q.Parameters.AddWithValue("@QuizName",textBox4.Text);
                q.Parameters.AddWithValue("@TeacherID",Form1.T_ID);
                q.ExecuteNonQuery();
              
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox3.Text = "";
                
                

            }
            catch (Exception err)
            {

                MessageBox.Show("SomethingWron Here Plz Contact Your Developer" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            c.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
           
            try
            {
                c.Open();
                SqlCommand q = new SqlCommand("insert into Quiz(CourseID,QuizID,Questions,OppA,OppB,OppC,OppD,OppCorrect,QuizName,TeacherID) values(@CourseID,@QuizID,@Questions,@OppA,@OppB,@OppC,@OppD,@OppCorrect,@QuizName,@TeacherID)", c);
                q.Parameters.AddWithValue("@CourseID", courseID);
                q.Parameters.AddWithValue("@QuizID", textBox2.Text);
                q.Parameters.AddWithValue("@Questions", textBox3.Text);
                q.Parameters.AddWithValue("@OppA", textBox5.Text);
                q.Parameters.AddWithValue("@OppB", textBox6.Text);
                q.Parameters.AddWithValue("@OppC", textBox7.Text);
                q.Parameters.AddWithValue("@OppD", textBox6.Text);
                if (radioButton1.Checked)
                {
                    q.Parameters.AddWithValue("@OppCorrect", textBox5.Text);

                }
                else if (radioButton2.Checked)
                {
                    q.Parameters.AddWithValue("@OppCorrect", textBox6.Text);
                }
                else if (radioButton3.Checked)
                {
                    q.Parameters.AddWithValue("@OppCorrect", textBox7.Text);
                }
                else if (radioButton4.Checked)
                {
                    q.Parameters.AddWithValue("@OppCorrect", textBox8.Text);
                }
                else
                {

                }

                q.Parameters.AddWithValue("@QuizName", textBox4.Text);
                q.Parameters.AddWithValue("@TeacherID", Form1.T_ID);
                q.ExecuteNonQuery();




                SqlCommand qq = new SqlCommand("insert into QuizID(QuizIDs,CourseID,TeacherID) values(@QuizIDs,@CourseID,@TeacherID)", c);
          
                qq.Parameters.AddWithValue("@QuizIDs", textBox2.Text);
                qq.Parameters.AddWithValue("@CourseID", courseID);
                qq.Parameters.AddWithValue("@TeacherID", Form1.T_ID);
                qq.ExecuteNonQuery();
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox3.Text = "";
                c.Close();
                MessageBox.Show("Your Quiz Has Been Created .", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
            }
            catch (Exception err)
            {

                MessageBox.Show("Something Wrong Here Plz Contact Your Developer. " + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }

     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 a = new Form2();

            a.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            T_ViewEnrol a = new T_ViewEnrol();
            a.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            T_ViewsandUpdate a = new T_ViewsandUpdate();
            a.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ViewResult a = new ViewResult();
            a.Show();
            this.Hide();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            T_setting a = new T_setting();
            a.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }
    }
}

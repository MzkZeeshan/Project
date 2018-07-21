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
    public partial class ViewResult : Form
    {
        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\MuhammadZeeshan\Desktop\QuizManagmentSystem\QuizManagmentSystem\QUIZ.mdf;Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=true");
     
        string courseID = "";
        public ViewResult()
        {
            InitializeComponent();
        }

        private void ViewResult_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
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
                    if (drr.Read())
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
                SqlCommand q = new SqlCommand("Select QuizIDs from QuizID where TeacherID= '" + Form1.T_ID.ToString() + "'", c);
                SqlDataReader dr = q.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["QuizIDs"]);
                }

            }
            catch (Exception err)
            {

                MessageBox.Show("Something Wrong Here Plz Contact Your Developer. " + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
         c.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           c.Open();
            try
            {
                SqlCommand q = new SqlCommand("Select StudentID,Score from Result where QuizID='" + comboBox1.Text + "' ", c);
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void button4_Click(object sender, EventArgs e)
        {
            T_QuizC a = new T_QuizC();
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


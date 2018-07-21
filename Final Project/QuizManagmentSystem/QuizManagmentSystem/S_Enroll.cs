﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizManagmentSystem
{

    public partial class S_Enroll : Form
    {
        public S_Enroll()
        {
            InitializeComponent();
        }

        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\MuhammadZeeshan\Desktop\QuizManagmentSystem\QuizManagmentSystem\QUIZ.mdf;Integrated Security=True;Connect Timeout=30; MultipleActiveResultSets=true");

        private void S_Enroll_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            c.Open();
            try
            {
                SqlCommand q = new SqlCommand("Select TeacherID,CourseName from Enrollments where StudentID= '" + Form1.S_ID + "'", c);
                SqlDataReader dr = q.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            catch (Exception err)
            {

                MessageBox.Show("SomethingWron Here Plz Contact Your Developer" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            c.Close();
       






            c.Open();
            try
            {
               SqlCommand q = new SqlCommand("Select CourseName,CourseID from Course", c);
                SqlDataReader dr = q.ExecuteReader();
                while (dr.Read())
                {
                    this.comboBox2.Items.Add(dr["CourseID"]);


                }

                c.Close();
            }
            catch (Exception err)
            {

                MessageBox.Show("Something Wrong Here Plz Contact Your Developer. " + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            S_Dasboard a = new S_Dasboard();
            a.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            S_Enroll a = new S_Enroll();
            a.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            S_takequiz a = new S_takequiz();
            a.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            S_mycreation a = new S_mycreation();
            a.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            S_setting a = new S_setting();
            a.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            c.Open();
            try
            {

                SqlCommand q = new SqlCommand("insert into Enrollments([TeacherID],[StudentID],[CourseID],[CourseName]) values(@TeacherID,@StudentID,@CourseID,@CourseName)", c);
                q.Parameters.AddWithValue("@TeacherID", this.textBox1.Text);
                q.Parameters.AddWithValue("@StudentID", Form1.S_ID);
                q.Parameters.AddWithValue("@CourseID", this.comboBox2.Text);
                q.Parameters.AddWithValue("@CourseName", this.textBox3.Text);

                q.ExecuteNonQuery();
                MessageBox.Show("Your Record Has been Submitted. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                this.textBox1.Clear();
                this.textBox2.Clear();
                this.textBox3.Clear();

          
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
                SqlCommand q = new SqlCommand("Select TeacherID,UserName From Teacher where CourseId='"+this.comboBox2.Text+"'", c);
                SqlDataReader dr = q.ExecuteReader();
                while (dr.Read())
                {
                   this.textBox1.Text= dr["TeacherID"].ToString();
                   this.textBox2.Text = dr["UserName"].ToString();


                }
                SqlCommand qq = new SqlCommand("Select CourseName From Course where CourseID='" + this.comboBox2.Text + "'", c);
                SqlDataReader drr = qq.ExecuteReader();
                while (drr.Read())
                {
                    this.textBox3.Text = drr["CourseName"].ToString();
                 

                }
                c.Close();
            }
            catch (Exception err)
            {

                MessageBox.Show("Something Wrong Here Plz Contact Your Developer. " + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
        }
    }
}

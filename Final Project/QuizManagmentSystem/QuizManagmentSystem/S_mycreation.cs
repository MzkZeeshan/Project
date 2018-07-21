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

    public partial class S_mycreation : Form
    {

        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\MuhammadZeeshan\Desktop\QuizManagmentSystem\QuizManagmentSystem\QUIZ.mdf;Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=true");
        public S_mycreation()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
                c.Open();
                try
                {
                    SqlCommand q = new SqlCommand("Select CourseID from Course where CourseName= '" + this.comboBox2.Text + "'", c);
                    SqlDataReader dr = q.ExecuteReader();
                    if (dr.Read())
                    {

                        SqlCommand qq = new SqlCommand("Select * from Result where CourseID='" + dr["CourseID"]+ "' ", c);
                        SqlDataReader drr = qq.ExecuteReader();



                        DataTable dt = new DataTable();
                        dt.Load(drr);
                        dataGridView1.DataSource = dt;

                    }
                }
                catch (Exception err)
                {

                    MessageBox.Show("Something Wrong Here Plz Contact Your Developer. " + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }
                c.Close();
        }

        private void S_mycreation_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            c.Open();
            try
            {
                SqlCommand q = new SqlCommand("Select CourseName from Enrollments where StudentID='" + Form1.S_ID + "' ", c);
                SqlDataReader dr = q.ExecuteReader();
                while (dr.Read())
                {
                    this.comboBox2.Items.Add(dr["CourseName"]);


                }


            }
            catch (Exception err)
            {

                MessageBox.Show("Something Wrong Here Plz Contact Your Developer. " + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            c.Close();
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
    }
}

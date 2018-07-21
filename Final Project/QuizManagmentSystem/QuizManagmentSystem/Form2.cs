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
    public partial class Form2 : Form
    {

        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\MuhammadZeeshan\Desktop\QuizManagmentSystem\QuizManagmentSystem\QUIZ.mdf;Integrated Security=True;Connect Timeout=30");
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            c.Open();
            try
            {
               
                SqlCommand q = new SqlCommand("Select Count(StudentID) from  Enrollments where TeacherID='"+Form1.T_ID+"'", c);
                SqlDataReader dr = q.ExecuteReader();
                if (dr.Read())
                {
                    if (Convert.ToInt16(dr[0]) < 10)
                    {


                        this.label2.Text = "0" + dr[0].ToString();
                    }
                    else
                    {

                        this.label2.Text = dr[0].ToString();

                    }


                }


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

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
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

        private void button7_Click_1(object sender, EventArgs e)
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

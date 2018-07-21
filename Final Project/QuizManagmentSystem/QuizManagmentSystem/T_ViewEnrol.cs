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
    public partial class T_ViewEnrol : Form
    {
        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\MuhammadZeeshan\Desktop\QuizManagmentSystem\QuizManagmentSystem\QUIZ.mdf;Integrated Security=True;Connect Timeout=30");
     
        public T_ViewEnrol()
        {
            InitializeComponent();
        }

        private void T_ViewEnrol_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.textBox1.ReadOnly = true;
            this.textBox2.ReadOnly = true;


            this.textBox2.Text = Form1.T_ID;


        
           c.Open();
            try
            {
                SqlCommand q = new SqlCommand("Select UserName from Teacher where TeacherID= '" + Form1.T_ID.ToString() + "'",c);
                SqlDataReader dr = q.ExecuteReader();
                if (dr.Read())
                {
                    textBox1.Text = dr["UserName"].ToString();
                }

            }
            catch (Exception err)
            {

                MessageBox.Show("SomethingWron Here Plz Contact Your Developer" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
           c.Close();
            
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
             c.Open();
                try
                {
                    SqlCommand q = new SqlCommand("Select * from Enrollments where TeacherID='"+this.textBox2.Text+"' ",c);
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

        private void button18_Click(object sender, EventArgs e)
        {
              c.Open();
                try
                {
                    SqlCommand q = new SqlCommand("Select * from Enrollments  where StudentID='"+this.textBox3.Text+"' ",c);
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
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form2 a = new Form2();
            a.Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            T_QuizC a = new T_QuizC();
            a.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            T_ViewsandUpdate a = new T_ViewsandUpdate();
            a.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ViewResult a = new ViewResult();
            a.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            T_setting a = new T_setting();
            a.Show();
            this.Hide();

        }

        private void button9_Click(object sender, EventArgs e)
        {

            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }
        }
    }


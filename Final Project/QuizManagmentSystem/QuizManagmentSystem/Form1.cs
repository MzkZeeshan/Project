using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizManagmentSystem
{
    public partial class Form1 : Form
    {

        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\MuhammadZeeshan\Desktop\QuizManagmentSystem\QuizManagmentSystem\QUIZ.mdf;Integrated Security=True;Connect Timeout=30");
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        public Form1()
        {
            InitializeComponent();
        
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        public static string T_ID;
        public static string S_ID;

        private void button2_Click(object sender, EventArgs e)
        {
            admin a = new admin();
            a.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           c.Open();
            if(this.radioButton2.Checked)
            {
              
                try
                {
                    SqlCommand q = new SqlCommand("Select UserName,Password,TeacherID from Teacher where UserName= '" + this.textBox1.Text + "' and Password='" + this.textBox2.Text + "' ",c);
                    SqlDataReader dr = q.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr["UserName"].ToString() == this.textBox1.Text && dr["Password"].ToString() == this.textBox2.Text)
                        {

                            T_ID = dr["TeacherID"].ToString();
                            Form2 a = new Form2();
                            a.Show();
                            this.Hide();
                        }

                    }
                    else
                    {

                        MessageBox.Show("Wrong User Name and Password.", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    }

                  
                }
                catch (Exception err)
                {

                    MessageBox.Show("Something Wrong Here Plz Contact Your Developer. " + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }

            
            }
            else if(this.radioButton1.Checked)
            {

                try
                {
                    SqlCommand q = new SqlCommand("Select UserName,Password,StudentID from Students where UserName= '" + this.textBox1.Text + "' and Password='" + this.textBox2.Text + "' ",c);
                    SqlDataReader dr = q.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr["UserName"].ToString() == this.textBox1.Text && dr["Password"].ToString() == this.textBox2.Text)
                        {
                     
                            S_ID = dr["StudentID"].ToString();
                            S_Dasboard a = new S_Dasboard();
                            a.Show();
                            this.Hide();
                            
                        }

                    }
                    else
                    {

                        MessageBox.Show("Wrong User Name and Password.", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    }

                   
                }
                catch (Exception err)
                {

                    MessageBox.Show("SomethingWron Here Plz Contact Your Developer" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }

               
            }

            else
            {

            }
           c.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class S_takequiz : Form
    {
        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\MuhammadZeeshan\Desktop\QuizManagmentSystem\QuizManagmentSystem\QUIZ.mdf;Integrated Security=True;Connect Timeout=30; MultipleActiveResultSets=true");
     
        string courseID = "";
        int totalQ = 0;
        int Pss = 0;
        int inc = 0;
        DataTable dt;
        int OptionCorrect = 0;
        string remarks = "";
        
        public S_takequiz()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void S_takequiz_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;
            this.label5.Visible = false;
            this.textBox3.Visible = false;
            this.textBox5.Visible = false;
            this.textBox6.Visible = false;
            this.textBox7.Visible = false;
            this.textBox8.Visible = false;
            this.radioButton8.Visible = false;
            this.radioButton7.Visible = false;
            this.radioButton6.Visible = false;
            this.radioButton5.Visible = false;
            this.button6.Visible = false;
            this.label7.Visible = false;
            this.label8.Visible = false;
            this.label9.Visible = false;
            this.label11.Visible = false;
            this.label10.Visible = false;
            this.label3.Visible = false;
            this.panel10.Visible = false;


            c.Open();
            try
            {
                SqlCommand q = new SqlCommand("Select CourseName from Enrollments where StudentID='"+Form1.S_ID+"' ", c);
                SqlDataReader dr = q.ExecuteReader();
                while(dr.Read())
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
              try
            {
                c.Open();
                panel10.Visible = true;
                SqlCommand q = new SqlCommand("Select Count(QuizID) from Quiz where QuizID='"+this.comboBox3.Text+"'  ", c);
                SqlDataReader dr = q.ExecuteReader();
                if (dr.Read())
                {
                    this.label14.Text = dr[0].ToString();
                    totalQ = Convert.ToInt16(dr[0]);
                    double a = (double)totalQ / 2;

                   
                   Pss=Convert.ToInt16( Math.Ceiling(a));
                   this.label15.Text = Pss.ToString();



                   c.Close();


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
                SqlCommand q = new SqlCommand("Select CourseID from Course where CourseName= '" + this.comboBox2.Text + "'", c);
                SqlDataReader dr = q.ExecuteReader();
                if (dr.Read())
                {
                    courseID = dr["CourseID"].ToString();
                    SqlCommand qq = new SqlCommand("Select QuizIDs from QuizID where CourseID= '" + dr["CourseID"].ToString() + "'", c);

                    SqlDataReader drr = qq.ExecuteReader();
                    while(drr.Read())
                    {
                       this.comboBox3.Items.Add( drr["QuizIDs"].ToString());
                    }
                }

            }
            catch (Exception err)
            {

                MessageBox.Show("Something Wrong Here Plz Contact Your Developer. " + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            c.Close();    
        
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.panel10.Visible = false;
            this.label5.Visible = true;
            this.textBox3.Visible = true;
            this.textBox5.Visible = true;
            this.textBox6.Visible = true;
            this.textBox7.Visible = true;
            this.textBox8.Visible = true;
            this.radioButton8.Visible = true;
            this.radioButton7.Visible = true;
            this.radioButton6.Visible = true;
            this.radioButton5.Visible = true;
            this.button6.Visible = true;
            this.label7.Visible = true;
            this.label8.Visible = true;
            this.label9.Visible = true;
            this.label11.Visible = true;
            this.label10.Visible = true;
            this.label3.Visible = true;
            this.button17.Enabled = false;
            this.comboBox2.Enabled = false;

            this.comboBox3.Enabled = false;

 
            c.Open();
            try
            {
              
                   if(totalQ>0)
                   {
                       SqlCommand qq = new SqlCommand("select Questions,OppA,OppB,OppC,OppD,OppCorrect,TeacherID from Quiz where QuizID='" + this.comboBox3.Text + "'", c);
                       SqlDataReader drr = qq.ExecuteReader();

                       dt = new DataTable();
                       dt.Load(drr);
                       //dataGridView1.DataSource = dt;
                       this.textBox3.Text=dt.Rows[inc]["Questions"].ToString();
                       this.radioButton8.Text = dt.Rows[inc]["OppA"].ToString();
                       this.radioButton7.Text = dt.Rows[inc]["OppB"].ToString();
                       this.radioButton6.Text = dt.Rows[inc]["OppC"].ToString();
                       this.radioButton5.Text = dt.Rows[inc]["OppD"].ToString();
                 
                       ++inc;
                    
                       
                      

                   }


                


            }
            catch (Exception err)
            {

                MessageBox.Show("Something Wrong Here Plz Contact Your Developer. " + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            c.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (totalQ != inc)
            {

                if (this.radioButton8.Checked)
                {
                    int check = inc - 1;
                    if (dt.Rows[inc - 1]["OppA"].ToString() == dt.Rows[inc - 1]["OppCorrect"].ToString())
                    {
                        ++OptionCorrect;
                        this.label3.Text = OptionCorrect.ToString();
                    }


                }
                else if (this.radioButton7.Checked)
                {
                    if (dt.Rows[inc - 1]["OppB"].ToString() == dt.Rows[inc - 1]["OppCorrect"].ToString())
                    {

                        ++OptionCorrect;
                        this.label3.Text = OptionCorrect.ToString();
                    }


                }
                else if (this.radioButton6.Checked)
                {
                    if (dt.Rows[inc - 1]["OppC"].ToString() == dt.Rows[inc - 1]["OppCorrect"].ToString())
                    {
                        ++OptionCorrect;
                        this.label3.Text = OptionCorrect.ToString();
                    }


                }
                else if (this.radioButton5.Checked)
                {
                    if (dt.Rows[inc - 1]["OppD"].ToString() == dt.Rows[inc - 1]["OppCorrect"].ToString())
                    {
                        ++OptionCorrect;
                        this.label3.Text = OptionCorrect.ToString();
                    }


                }

                this.textBox3.Text = dt.Rows[inc]["Questions"].ToString();
                this.radioButton8.Text = dt.Rows[inc]["OppA"].ToString();
                this.radioButton7.Text = dt.Rows[inc]["OppB"].ToString();
                this.radioButton6.Text = dt.Rows[inc]["OppC"].ToString();
                this.radioButton5.Text = dt.Rows[inc]["OppD"].ToString();
               







                ++inc;



            }
            else
            {
                if (this.radioButton8.Checked)
                {
                    int check = inc - 1;
                    if (dt.Rows[inc-1]["OppA"].ToString() == dt.Rows[inc-1]["OppCorrect"].ToString())
                    {
                        ++OptionCorrect;
                        this.label3.Text = OptionCorrect.ToString();
                    }


                }
                else if (this.radioButton7.Checked)
                {
                    if (dt.Rows[inc-1]["OppB"].ToString() == dt.Rows[inc-1]["OppCorrect"].ToString())
                    {

                        ++OptionCorrect;
                        this.label3.Text = OptionCorrect.ToString();
                    }


                }
                else if (this.radioButton6.Checked)
                {
                    if (dt.Rows[inc-1]["OppC"].ToString() == dt.Rows[inc-1]["OppCorrect"].ToString())
                    {
                        ++OptionCorrect;
                        this.label3.Text = OptionCorrect.ToString();
                    }


                }
                else if (this.radioButton5.Checked)
                {
                    if (dt.Rows[inc-1]["OppD"].ToString() == dt.Rows[inc-1]["OppCorrect"].ToString())
                    {
                        ++OptionCorrect;
                        this.label3.Text = OptionCorrect.ToString();
                    }


                }

                c.Open();
                SqlCommand q = new SqlCommand("insert into Result(CourseID,QuizID,StudentID,TeacherID,Score,Remarks) values(@CourseID,@QuizID,@StudentID,@TeacherID,@Score,@Remarks) ", c);
                q.Parameters.AddWithValue("@CourseID", courseID);
                   q.Parameters.AddWithValue("@QuizID", this.comboBox3.Text);
                   q.Parameters.AddWithValue("@StudentID", Form1.S_ID);
                   q.Parameters.AddWithValue("@TeacherID", dt.Rows[0]["TeacherID"].ToString());
                   q.Parameters.AddWithValue("@Score", OptionCorrect.ToString());
                if(OptionCorrect>=Pss)
                {
                    remarks = "PASS";
                }
                else
                {
                    remarks="Fail";
                }


                q.Parameters.AddWithValue("@Remarks", remarks);
                q.ExecuteNonQuery();
                MessageBox.Show("You are "+remarks+" Your Score is "+OptionCorrect.ToString() +".", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                
                c.Close();

                this.comboBox2.Items.Clear();
                this.comboBox3.Items.Clear();
                this.comboBox3.Text = "";
                this.comboBox2.Text = "";
                c.Open();
                try
                {
                    SqlCommand qq = new SqlCommand("Select CourseName from Enrollments where StudentID='" + Form1.S_ID + "' ", c);
                    SqlDataReader drr = qq.ExecuteReader();
                    while (drr.Read())
                    {
                        this.comboBox2.Items.Add(drr["CourseName"]);


                    }


                }
                catch (Exception err)
                {

                    MessageBox.Show("Something Wrong Here Plz Contact Your Developer. " + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }
                c.Close();

                

                this.label5.Visible = false;
                this.textBox3.Visible = false;
                this.textBox5.Visible = false;
                this.textBox6.Visible = false;
                this.textBox7.Visible = false;
                this.textBox8.Visible = false;
                this.radioButton8.Visible = false;
                this.radioButton7.Visible = false;
                this.radioButton6.Visible = false;
                this.radioButton5.Visible = false;
                this.button6.Visible = false;
                this.label7.Visible = false;
                this.label8.Visible = false;
                this.label9.Visible = false;
                this.label11.Visible = false;
                this.label10.Visible = false;
                this.label3.Visible = false;
                this.panel10.Visible = false;
                this.button17.Enabled = true;
                this.comboBox2.Enabled = true;

                this.comboBox3.Enabled = true;



                MessageBox.Show("end");
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

       
    }
}

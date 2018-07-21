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
    public partial class T_ViewsandUpdate : Form
    {
        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\MuhammadZeeshan\Desktop\QuizManagmentSystem\QuizManagmentSystem\QUIZ.mdf;Integrated Security=True;Connect Timeout=30");
     
        public T_ViewsandUpdate()
        {
            InitializeComponent();
        }

        private void T_ViewsandUpdate_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.textBox2.ReadOnly = true;
            this.textBox3.ReadOnly = true;
            this.textBox5.ReadOnly = true;
            this.textBox6.ReadOnly = true;
            this.textBox7.ReadOnly = true;
            this.textBox8.ReadOnly = true;
            this.textBox1.ReadOnly = true;

          c.Open();
            try
            {
                SqlCommand q = new SqlCommand("Select QuizIDs from QuizID where TeacherID= '" + Form1.T_ID+ "'", c);
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          c.Open();
            try
            {
                SqlCommand q = new SqlCommand("Select Questions,QuestionID,OppA,OppB,OppC,OppD,OppCorrect from Quiz where QuizID='" + comboBox1.Text + "' ", c);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                this.textBox3.ReadOnly = false;
                this.textBox5.ReadOnly = false;
                this.textBox6.ReadOnly = false;
                this.textBox7.ReadOnly = false;
                this.textBox8.ReadOnly = false;
                this.textBox1.ReadOnly = false;
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                this.textBox3.Text = row.Cells["Questions"].Value.ToString();
                this.textBox5.Text = row.Cells["OppA"].Value.ToString();
                this.textBox6.Text = row.Cells["OppB"].Value.ToString();
                this.textBox7.Text = row.Cells["OppC"].Value.ToString();
                this.textBox8.Text = row.Cells["OppD"].Value.ToString();
                this.textBox2.Text = row.Cells["QuestionID"].Value.ToString();
                this.textBox1.Text = row.Cells["OppCorrect"].Value.ToString();
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
          
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
          c.Open();
            try
            {
                SqlCommand q = new SqlCommand("update Quiz set Questions=@Questions,OppA=@OppA,OppB=@OppB,OppC=@OppC,OppD=@OppD,OppCorrect=@OppCorrect where QuestionID=@QuestionID", c);
                 q.Parameters.AddWithValue("@Questions", textBox3.Text);
                q.Parameters.AddWithValue("@OppA", textBox5.Text);
                q.Parameters.AddWithValue("@OppB", textBox6.Text);
                q.Parameters.AddWithValue("@OppC", textBox7.Text);
                q.Parameters.AddWithValue("@OppD", textBox6.Text);
                q.Parameters.AddWithValue("@OppCorrect", textBox1.Text);
                q.Parameters.AddWithValue("@QuestionID", this.textBox2.Text);

                q.ExecuteNonQuery();
                MessageBox.Show("Question Has Been Updated");

            }
            catch (Exception err)
            {

                MessageBox.Show("Something Wrong Here Plz Contact Your Developer. " + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
          c.Close();


            this.textBox3.ReadOnly = true;
            this.textBox5.ReadOnly = true;
            this.textBox6.ReadOnly = true;
            this.textBox7.ReadOnly = true;
            this.textBox8.ReadOnly = true;
            this.textBox1.ReadOnly = true;
            this.textBox3.Clear();
       
            this.textBox5.Clear();
            this.textBox6.Clear();
            this.textBox7.Clear();
            this.textBox8.Clear();
            this.textBox1.Clear();
            this.textBox2.Clear();
        

          c.Open();
            try
            {
                SqlCommand q = new SqlCommand("Select Questions,QuestionID,OppA,OppB,OppC,OppD,OppCorrect from Quiz where QuizID='" + comboBox1.Text + "' ", c);
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

        private void button9_Click(object sender, EventArgs e)
        {
          
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

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}

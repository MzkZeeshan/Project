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
    public partial class Admin_setting : Form
    {

        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\MuhammadZeeshan\Desktop\QuizManagmentSystem\QuizManagmentSystem\QUIZ.mdf;Integrated Security=True;Connect Timeout=30 MultipleActiveResultSets=true");
    

        public Admin_setting()
        {
            InitializeComponent();
 
        }

        private void button17_Click(object sender, EventArgs e)
        {

            c.Open();
            try
            {
                SqlCommand q = new SqlCommand("Select Password from Admin where AdminID= '" + admin.A_ID + "'",c);
                SqlDataReader dr = q.ExecuteReader();
                if (dr.Read())
                {
                    if (dr["Password"].ToString() == this.textBox5.Text)
                    {
                        if (this.textBox6.Text == this.textBox7.Text)
                        {

                            SqlCommand qq = new SqlCommand("Update Admin set [Password]=@Password  where [AdminID]='" + admin.A_ID + "' ",c);
                            qq.Parameters.AddWithValue("@Password", this.textBox6.Text);
                            qq.ExecuteNonQuery();
                            MessageBox.Show(" Password has been Changed.", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                            this.textBox5.Clear();

                            this.textBox6.Clear();

                            this.textBox7.Clear();
                        }
                        else
                        {
                            MessageBox.Show("New Password Not Match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Current Password Not Correct.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);

                    }

                }

            }
            catch (Exception err)
            {

                MessageBox.Show("Something Wrong Here Plz Contact Your Developer. " + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
           c.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
           c.Open();
            try
            {
                SqlCommand q = new SqlCommand("Select UserName from Admin where AdminID =  '" + admin.A_ID + "'",c);
                SqlDataReader dr = q.ExecuteReader();
                if (dr.Read())
                {
                    if (dr["UserName"].ToString() == this.textBox3.Text)
                    {
                        if (this.textBox2.Text == this.textBox1.Text)
                        {

                            SqlCommand qq = new SqlCommand("Update Admin set [UserName]=@UserName  where [AdminID]='" + admin.A_ID + "' ",c);
                            qq.Parameters.AddWithValue("@UserName", this.textBox2.Text);
                            qq.ExecuteNonQuery();
                            this.textBox1.Clear();

                            this.textBox2.Clear();

                            this.textBox3.Clear();
                            MessageBox.Show(" UserName has been Changed.", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);

                        }
                        else
                        {
                            MessageBox.Show("New UserName Not Match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Current UserName Not Correct.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);

                    }

                }

            }
            catch (Exception err)
            {

                MessageBox.Show("Something Wrong Here Plz Contact Your Developer. " + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
           c.Close();
        }

        private void Admin_setting_Load(object sender, EventArgs e)
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
    }
}

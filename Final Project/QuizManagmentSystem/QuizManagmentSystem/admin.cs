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
    public partial class admin : Form
    {
        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\MuhammadZeeshan\Desktop\QuizManagmentSystem\QuizManagmentSystem\QUIZ.mdf;Integrated Security=True;Connect Timeout=30");
        public static string A_ID = "1";
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
        public admin()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                c.Open();
                SqlCommand q = new SqlCommand("Select UserName,Password,AdminID from Admin where UserName= '" + this.textBox1.Text + "' and Password='" + this.textBox2.Text + "' ", c);
                SqlDataReader dr = q.ExecuteReader();
                if (dr.Read())
                {
                    if (dr["UserName"].ToString() == this.textBox1.Text && dr["Password"].ToString() == this.textBox2.Text)
                    {
              
                        A_ID = dr["AdminID"].ToString();
                        A_dasboard a = new A_dasboard();
                        a.Show();
                        this.Hide();
                    }

                }
                else
                {

                    MessageBox.Show("Wrong User Name and Password.", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }

                c.Close();
            }
            catch (Exception err)
            {

                MessageBox.Show("SomethingWron Here Plz Contact Your Developer" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }

        }

        private void admin_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }
    }
}

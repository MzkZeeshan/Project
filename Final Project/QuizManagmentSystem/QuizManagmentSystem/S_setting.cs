using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizManagmentSystem
{
    public partial class S_setting : Form
    {
        public S_setting()
        {
            InitializeComponent();
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

        private void S_setting_Load(object sender, EventArgs e)
        {

        }
    }
}

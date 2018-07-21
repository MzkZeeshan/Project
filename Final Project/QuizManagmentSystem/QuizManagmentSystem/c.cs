using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizManagmentSystem
{
    public partial class c : Form
    {
        
        public c()
        {
            InitializeComponent();
        }

        private void c_Load(object sender, EventArgs e)
        {
            c c = new c();
            c.oleDbConnection1.Open();
            try
            {
                OleDbCommand q = new OleDbCommand("Select * from Enrollments where TeacherID= ", c.oleDbConnection1);
                OleDbDataReader dr = q.ExecuteReader();
                if(dr.Read())
                {

                }

            }
            catch (Exception err)
            {

                MessageBox.Show("Something Wrong Here Plz Contact Your Developer. " + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            c.oleDbConnection1.Close();
        }
    }
}

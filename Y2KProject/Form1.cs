using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace Y2KProject
{
    public partial class Form1 : Form
    {
        string user;
        OleDbConnection connection = new OleDbConnection();
       
        public Form1()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\khand\OneDrive\Desktop\Avi\Userid1.accdb";
            
        }

      

        private void lgnbtn_Click(object sender, EventArgs e)
        {
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            
            logincontroller adminlogin1 = new logincontroller();
             adminlogin1.adminlogin(txtuser.Text, txtpass.Text);
           
           // MessageBox.Show(user);
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            logincontroller userlogin1 = new logincontroller();
            userlogin1.userlogin(txtuser.Text, txtpass.Text);

           
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

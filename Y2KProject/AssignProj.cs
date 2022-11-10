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
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

namespace Y2KProject
{
    public partial class AssignProj : Form 
    {
        OleDbConnection connection = new OleDbConnection();
        logs log = new logs();
        
        public AssignProj()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\khand\OneDrive\Desktop\Avi\Userid1.accdb";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void AssignProj_Load(object sender, EventArgs e)
        {
            connection.Open();
            
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from Userdata";
          // command.CommandText = "select * from Project";
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["UName"]);
            //  comboBox2.Items.Add(reader["Project"]);
            }
          

            connection.Close();

         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
           
            command.CommandText = "select * from Project";
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
               // comboBox1.Items.Add(reader["UName"]);
                comboBox2.Items.Add(reader["Project"]);
            }


            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProjectController assign = new ProjectController();
            assign.assignproj(comboBox2.Text, comboBox1.Text, textBox2.Text, dateTimePicker1.Text, richTextBox1.Text, textBox3.Text, textBox4.Text);
            
        }
    }
}

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

     
    
    public partial class projectlog : Form
    {
        OleDbConnection connection = new OleDbConnection();
        public projectlog()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\khand\OneDrive\Desktop\Avi\Userid1.accdb";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from logs";
            OleDbDataReader reader = command.ExecuteReader();
            listBox1.Items.Clear();
            while (reader.Read())
            {
                
                listBox1.Items.Add(reader["Project"]);
                listBox1.ResetText();

            }
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            connection.Close();
        }

        private void projectlog_Load(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from logs";
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["Project"]);
                comboBox2.Items.Add(reader["Assigned"]);
            }
            connection.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from logs where Project ='" + comboBox1.Text + "'";
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listBox1.Items.Add(reader["Assigned"]);
                listBox1.Items.Add(reader["Status"]);
                listBox1.Items.Add(reader["Deadline"]);

            }
            connection.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from logs where Assigned ='" + comboBox2.Text + "'";
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
               // listBox1.Items.Add(reader["Assigned"]);
                listBox1.Items.Add(reader["Task"]);
                listBox1.Items.Add(reader["Status"]);
                listBox1.Items.Add(reader["Deadline"]);
            }
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
        }
    }
}

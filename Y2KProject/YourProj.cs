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
    public partial class YourProj : Form

    {
        string username;
        project projmodel = new project();
        OleDbConnection connection = new OleDbConnection();
        public YourProj()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\khand\OneDrive\Desktop\Avi\Userid1.accdb";
            projmodel.Username = username;
           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from logs";
            OleDbDataReader reader = command.ExecuteReader();
            Project.Items.Clear();
            while (reader.Read())
            {

                Project.Items.Add(reader["Project"]);
                Project.Items.Add(reader["Task"]);
                Project.ResetText();

            }
            Project.DataSource = null;
            Project.Items.Clear();
            connection.Close();
        }

        public void YourProj_Load(object sender, EventArgs er)
        {

           
        }
        public void your(string user)
        {
            projmodel.Username = user;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from logs where Assigned ='" + textBox1.Text + "'";
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Project.Items.Add(reader["Project"]);
                Project.Items.Add(reader["Task"]);
                Project.Items.Add(reader["Status"]);
                Project.Items.Add(reader["Deadline"]);
            }
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Project.ResetText();
            Project.Items.Clear();
            connection.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.ShowDialog();
        }
    }
}

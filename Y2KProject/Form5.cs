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
    public partial class Form5 : Form
    {
        OleDbConnection connection = new OleDbConnection();
        public Form5()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\khand\OneDrive\Desktop\Avi\Userid1.accdb";
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select Project from logs";
            
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["Project"]);
                //  comboBox2.Items.Add(reader["Project"]);
            }


            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserOpController statusup = new UserOpController();
            statusup.status(richTextBox1.Text, comboBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();

        }
    }
}

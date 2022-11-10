using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Y2KProject
{
    class addusercontroller
    {
        OleDbConnection connection = new OleDbConnection();
        Class1 usermodel = new Class1();
        project projmodel = new project();
        public void adduser(string name, string user, string pass, string empid)
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\khand\OneDrive\Desktop\Avi\Userid1.accdb";
            connection.Open();
            usermodel.Uname = name;
            usermodel.Username = user;
            usermodel.Password = pass;
            usermodel.empid = empid;
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "insert into Userdata values('" + usermodel.Uname + "','" + usermodel.Username + "','" + usermodel.Password + "','" + usermodel.empid + "')";
            OleDbDataReader reader = command.ExecuteReader();
            MessageBox.Show("User has been created");
            connection.Close();
        }
    }
}

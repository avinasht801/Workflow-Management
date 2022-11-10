using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace Y2KProject
{
    public class UserOpController
    {
        OleDbConnection connection = new OleDbConnection();
        Class1 usermodel = new Class1();
        project projmodel = new project();



        public string status (string status, string projname)
        {
            
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\khand\OneDrive\Desktop\Avi\Userid1.accdb";
            connection.Open();
            projmodel.status = status;
            projmodel.projectname = projname;
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "Update logs set Status ='" + projmodel.status + "' Where Project ='" + projmodel.projectname + "'";
            OleDbDataReader reader = command.ExecuteReader();
            MessageBox.Show("Status is Updated");
            connection.Close();
            return "Status is Updated";
        }
        public void projloload(string yourlist)
        {
            
        }

    }
}

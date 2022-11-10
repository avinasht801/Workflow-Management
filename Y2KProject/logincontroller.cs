using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace Y2KProject
{
   public class logincontroller
    {
        OleDbConnection connection = new OleDbConnection();
        Class1 usermodel = new Class1();
        project projmodel = new project();
        public string userlogin(string user, string pass)
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\khand\OneDrive\Desktop\Avi\Userid1.accdb";
            connection.Open();
            projmodel.Username = user;
            projmodel.Password = pass;
            string message = "authorized";
            //  YourProj yp = new YourProj(projmodel.Username);


            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "Select * from Userdata where Username='" + projmodel.Username + "'and Password ='" + projmodel.Password + "'";
            OleDbDataReader reader = command.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count = count + 1;
            }
            if (count == 1)
            {
               
                    MessageBox.Show(message);

                // this.Hide();
                Form3 f3 = new Form3();
                f3.ShowDialog();
              
            }
            else
            {
                string message1 = "unauthorized";
                MessageBox.Show("incorrect password");
               // return message1;
            }
            return message;

            connection.Close();

        }
        public string adminlogin(string user, string pass)
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\khand\OneDrive\Desktop\Avi\Userid1.accdb";
            connection.Open();
            projmodel.Username = user;
            projmodel.Password = pass;
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "Select * from Users where Username='" + projmodel.Username + "'and Password ='" + projmodel.Password + "'";
            OleDbDataReader reader = command.ExecuteReader();
           
            
            int count = 0;
            while (reader.Read())
            {
                count = count + 1;
            }
            if (count == 1)
            {
                MessageBox.Show("Access Granted");
                //  this.Hide();
                Form2 f2 = new Form2();

                f2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Incorrect Password! Try Again");

            }
            return projmodel.Username;
        }

    }
}

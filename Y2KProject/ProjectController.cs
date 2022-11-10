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
   public class ProjectController
    {
        OleDbConnection connection = new OleDbConnection();
        Class1 usermodel = new Class1();
        project projmodel = new project();



        public void assignproj(string projname, string name, string task, string date, string log, string email, string status)
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\khand\OneDrive\Desktop\Avi\Userid1.accdb";
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            projmodel.projectname = projname;
            projmodel.Uname = name;
            projmodel.Task = task;
            projmodel.deadline = date;
            projmodel.log = log;
            projmodel.status = status;
            command.CommandText = "insert into logs values('" + projmodel.projectname + "','" + projmodel.Uname + "','" + projmodel.Task + "','" + projmodel.deadline + "','" + projmodel.log + "','" + projmodel.status + "')";
            OleDbDataReader reader = command.ExecuteReader();
            MessageBox.Show("Project has been Assigned");
            connection.Close();
            Email(email, name, projname, task);
           
        }

        public string addproj(string projname, string projid)
        {
            string message = "Project is added";
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\khand\OneDrive\Desktop\Avi\Userid1.accdb";
            connection.Open();
            projmodel.projectname = projname;
            projmodel.projectid = projid;
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "insert into Project values('" + projmodel.projectname + "','" + projmodel.projectid + "')";
            OleDbDataReader reader = command.ExecuteReader();
            MessageBox.Show(message);

            connection.Close();
            return message;
        }
        //below code is I wrote is the example of a Emailing using C# example: https://stackoverflow.com/questions/449887/sending-e-mail-using-c-sharp
        public string Email(string email,string name,string projname,string date)
        {
            string EmailID = email;
            string User = name;
            string project = projname;
            string deadline = date;
            var fromID = new MailAddress("avinashtest51@gmail.com", "Avinash");
            var toID = new MailAddress(EmailID, User);
            const string EmailPass = "hferkqlscxyeteat";
            const string subject = "Project Assigned";
            string body = "Hello " + User + ", project " + project + " has been allocated to you with deadline of " + deadline;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromID.Address, EmailPass),
                Timeout = 10000
            };
            using (var message = new MailMessage(fromID, toID)
            {
                Subject = subject,
                Body = body
            })
            {
              smtp.Send(message);
                
            }
            return "Message sent";
            
        }
      
    }
}

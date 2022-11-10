using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
namespace Y2KProject
{
   public class Testclass
    {
 
        Class1 usermodel = new Class1();
        project projmodel = new project();
        public string Email(string email, string name, string projname, string date)
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

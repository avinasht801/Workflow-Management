using Microsoft.VisualStudio.TestTools.UnitTesting;
using Y2KProject;
using System.Data.SqlTypes;
using System.Net.Mail;


namespace Y2KTest
{
    [TestClass]
    public class UnitTest1
    {
        Testclass test = new Testclass();
        [TestMethod]
        public void TestMethod1()
        {

            string data = test.Email("getavi07@gmail.com", "Avinash", "Mscorp", "26/03/2022");
            string message = "Message sent";
           // UserOpController actual = new UserOpController();


            Assert.AreEqual(message,data);

           
        }
       
    }
}

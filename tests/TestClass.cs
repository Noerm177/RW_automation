using RW_Auto.core.TestBase;
using NUnit.Framework;
using System;
using System.Threading;
using RW_Auto.pages;

namespace RW_Auto.tests
{
   
    [TestFixture]
    public class TestClass : TestBase
    {
        string emailTxt = "sfasupport@igt.com";
        string passTxt = "DullSpongyIde@15";


        [Test]
        public void LoginTest()
        {
            Login LoginPAge = new Login(driver);
            LoginPAge.logIn(emailTxt, passTxt);
            LoginPAge.getTitle();
        }
    }
}
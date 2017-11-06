using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase

    { 

        

        [Test]
        public void GroupCreationTest()
        {
            navigator.OpenHomePage();
            loginHelper.Login(new AccountData("admin","secret") );
            navigator.GoToGroupPage();
            InitCreationGroup();
            GroupData group = new GroupData("Group 1");
            group.GroupHeader = "HEADER 1";
            group.GroupFooter = "FOOTER 1";
            FillGroupFields(group);
            SubmitGroupCreation();
            
        }

        

      
        
        
    }
}

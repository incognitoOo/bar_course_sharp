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
    public class CreationTest : TestBase
    {

        [Test]
        public void ContactCretionTest()
        {
            navigator.OpenHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            InitCreationContact();
            ContactData contact = new ContactData("FIRSTNAME", "LASTNAME", "ADDRESS");
            contact.Middlename = "MiddleName";
            contact.Work = "Work";
            FillContactData(contact);
            SubmitCreationContact();
            
        }
       
       
        private void SubmitCreationContact()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        private void FillContactData(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(contact.Address);
            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys(contact.Work);
        }

        private void InitCreationContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

       



    }
}

﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace  WebAddressbookTests
{ 
    [TestFixture]
    public class Untitled
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox\firefox.exe";
            options.UseLegacyImplementation = true;
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost/addressbook/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void ContactCretionTest()
    {
        OpenHomePage();
        Login(new AccountData("admin","secret"));
        InitCreationContact();
            ContactData contact = new ContactData("FIRSTNAME", "LASTNAME", "ADDRESS");
            contact.Middlename = "MiddleName";
            contact.Work = "Work";
        FillContactData(contact);
        SubmitCreationContact();
        NewMethod();
    }

    private void NewMethod()
    {
        driver.FindElement(By.LinkText("home page")).Click();
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

    private void Login(AccountData account)
    {
        driver.FindElement(By.Name("user")).Clear();
        driver.FindElement(By.Name("user")).SendKeys(account.Username);
        driver.FindElement(By.Name("pass")).Clear();
        driver.FindElement(By.Name("pass")).SendKeys(account.Userpassword);
        driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
    }


    private void OpenHomePage()
    {
        driver.Navigate().GoToUrl(baseURL);
    }

    private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}

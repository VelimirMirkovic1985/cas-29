using System;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace cas_31_lekcija
{
    class Selenium_Tests_QA_Shop
    {
        IWebDriver driver;
        WebDriverWait wait;

         string email= "Pobednik@Beograd";
         string password = "Kalemegdan1";
         string korisnicko = "Gladijator";

        [Test]
        [Category("SC")]        
        public void Registration()
        {
            Navigate("http://shop.qa.rs/");

            IWebElement register = driver.FindElement(By.XPath("//a[@href='/register']"));
            if (register.Enabled)
            {
                register.Click();

            }

            IWebElement FirstName = driver.FindElement(By.Name("ime"));
            if (FirstName.Enabled)
            {
                FirstName.SendKeys("Ivo");
            }


            IWebElement LastName = driver.FindElement(By.Name("prezime"));
            if (LastName.Enabled)
            {
                LastName.SendKeys("Andric");
            }

            IWebElement E_mail = driver.FindElement(By.Name("email"));
            if (E_mail.Enabled)
            {
                E_mail.SendKeys("email");
            }

            IWebElement UserName = driver.FindElement(By.Name("korisnicko"));
            if (UserName.Enabled)
            {
                UserName.SendKeys("korisnicko");
            }

            IWebElement Password = driver.FindElement(By.Name("lozinka"));
            if (Password.Enabled)
            {
                Password.SendKeys("password");
            }

            IWebElement ConfirmPassword = driver.FindElement(By.Name("lozinkaOpet"));
            if (ConfirmPassword.Enabled)
            {
                ConfirmPassword.SendKeys("password");
            }

            IWebElement Registerbutton = driver.FindElement(By.Name("register"));
            if (Registerbutton.Enabled)
            {
                Registerbutton.Click();
            }
       
         }
           
        
            [Test]
            [Category("SC")]           
       
            public void Login()
        {

            Navigate("http://shop.qa.rs");

            IWebElement SignIn = driver.FindElement(By.XPath("//a[@href='/login']"));
            if (SignIn.Enabled)
            {
                SignIn.Click();
            }

            IWebElement UserName = driver.FindElement(By.Name("username"));
            if (UserName.Enabled)
            {
                UserName.SendKeys("korisnicko");
            }


            IWebElement InputPassword = driver.FindElement(By.Name("password"));
            if (InputPassword.Enabled)
            {
                InputPassword.SendKeys("password");
            }

            IWebElement signin = driver.FindElement(By.Name("login"));
            if (signin.Enabled)
            {
                signin.Click();
            }
      
        }

        [Test]
        [Category("SC")]
        public void CheckCartIsEmpty()
        {
            Login();

            IWebElement signIn = driver.FindElement(By.XPath("//a[@href='/cart']"));
            if (signIn.Enabled)
            {
                signIn.Click();
            }

            IWebElement alert = driver.FindElement(By.XPath("//div[@class='alert alert-warning']"));
            if (alert.Enabled)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }


        [Test]
        [Category("SC")]
        [TestCase("Gladijator", "Kalemegdan1")]
        [TestCase("Gladijator", "pogresna sifra")]
        [TestCase("pogresno ime", "Kalemegdan1")]
        [TestCase("pogresno", "pogresno")]

        public void Login_annotation(string korisnickoIme, string sifra)
        {

            Navigate("http://shop.qa.rs");

            IWebElement SignIn = driver.FindElement(By.XPath("//a[@href='/login']"));
            if (SignIn.Enabled)
            {
                SignIn.Click();
            }

            IWebElement UserName = driver.FindElement(By.Name("username"));
            if (UserName.Enabled)
            {
                UserName.SendKeys("korisnickoIme");
            }


            IWebElement InputPassword = driver.FindElement(By.Name("password"));
            if (InputPassword.Enabled)
            {
                InputPassword.SendKeys("sifra");
            }

            IWebElement signin = driver.FindElement(By.Name("login"));
            if (signin.Enabled)
            {
                signin.Click();
            }

        }



        private void Navigate(string url)
        {
            driver.Navigate().GoToUrl(url);
        }



        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }




    }
}

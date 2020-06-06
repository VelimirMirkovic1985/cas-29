using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;




namespace cas_31_lekcija
{
    class Selenium_Tests
    {
        IWebDriver driver;
        WebDriverWait wait;
    
    [Test]
     public void KreirajNovogKorisnika()
        {
            Navigate("http://test.qa.rs/");

            IWebElement linkCreate = wait.Until(EC.ElementIsVisible(By.LinkText("Kreiraj novog korisnika")));
            if(linkCreate.Displayed && linkCreate.Enabled)
            {
                linkCreate.Click();
            }

            IWebElement inputName = driver.FindElement(By.Name("ime"));
            if(inputName.Enabled && inputName.Displayed)
            {
                inputName.SendKeys("Lazar");
            }

            IWebElement inputLastName = driver.FindElement(By.Name("prezime"));
            if (inputLastName.Enabled && inputLastName.Displayed)
            {
                inputLastName.SendKeys("Ristovski");
            }


            IWebElement inputUserName = driver.FindElement(By.Name("korisnicko"));
            if (inputUserName.Enabled && inputUserName.Displayed)
            {
                inputUserName.SendKeys("Lazaros");
            }


            IWebElement E_mail = driver.FindElement(By.Name("email"));
            if (E_mail.Enabled && E_mail.Displayed)
            {
                E_mail.SendKeys("Laki@Ristovski.com");
            }

            IWebElement PhoneNumber = driver.FindElement(By.Name("telefon"));
            if (PhoneNumber.Enabled && PhoneNumber.Displayed)
            {
                PhoneNumber.SendKeys("547689930");
            }

            IWebElement inputCountry = driver.FindElement(By.Name("zemlja"));
            if (inputCountry.Displayed)
            {
                SelectElement selectCountry = new SelectElement(inputCountry);
                selectCountry.SelectByText("Serbia");

            }

            IWebElement inputCity = wait.Until(EC.ElementIsVisible(By.Name("grad")));
            if (inputCity.Displayed)
            {
                SelectElement selectCity = new SelectElement(inputCity);
                selectCity.SelectByIndex(6);
            }

            IWebElement inputStreet = driver.FindElement(By.XPath("//div[@id='address']//input"));
            if (inputStreet.Displayed)
            {
                inputStreet.SendKeys("Narodnih Heroja 55");
            }

            IWebElement inputGender = driver.FindElement(By.Id("pol_m"));
            if (inputGender.Displayed)
            {
                inputGender.Click();
            }

            IWebElement registerButton = driver.FindElement(By.Name("register"));
            if (registerButton.Displayed)
            {
                registerButton.Click();
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

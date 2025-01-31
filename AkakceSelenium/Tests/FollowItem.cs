using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AkakceSelenium.Tests
{
    internal class FollowItem
    {
        [Test]
        public void Start()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.akakce.com/");
            Thread.Sleep(3000);
            driver.Manage().Window.Maximize();
            //Login Page
            var LoginButtonMain = driver.FindElement(By.XPath("//a[@href=\"/akakcem/giris/\"]"));
            LoginButtonMain.Click();
            var EmailText = driver.FindElement(By.Id("life"));
            //Credentials
            //Fill with mail address of an Akakce account
            EmailText.SendKeys(""); 
            var PasswordText = driver.FindElement(By.Id("lifp"));
            //Fill with password of an Akakce account
            PasswordText.SendKeys(""); 
            var LoginButton = driver.FindElement(By.Id("lfb"));
            LoginButton.Click();
            
            Thread.Sleep(2000);
            //After search
            driver.Navigate().GoToUrl("https://www.akakce.com/cep-telefonu/apple.html");
            Thread.Sleep(2000);
            //Add to followed items
            var FollowItem = driver.FindElement(By.XPath("//span[@class=\"ufo_v8\"]"));
            FollowItem.Click();

            driver.Quit();

            /*
            //SearchBar.Click();
            //Thread.Sleep(1000);
            //SearchBar.SendKeys("iphone");
            //var SearchBarButton = driver.FindElement(By.XPath("//i[normalize-space()='Ara']"));
            //SearchBarButton.Click();
            //var SearchBar = driver.FindElement(By.XPath("//input[@type=\"text\"]"));
            //var LoginButtonMain = driver.FindElement(By.XPath("//div[@id='H_rl_v8']//a[@rel='nofollow'][contains(text(),'Giriş Yap')]"));
            //var SearchBar = driver.FindElement(By.ClassName("frm_v8")); 
            //var SearchBar = driver.FindElement(By.XPath("//input"));
            //driver.FindElement(By.XPath("//input[@type=\"text\"]")).Click();
            //var SearchBar = driver.FindElement(By.XPath("//form[@id=\"H_s_v8\"]"));
            //var SearchBar2 = driver.FindElement(By.XPath("/ html[1] / body[1] / div[1] / header[1] / div[3] / form[1] / span[1] / input[1]"));
            //IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            //jse.ExecuteScript("document.getElementByXPath('//input[@type=\"text\"]').setAttribute('Neyi ucuza almak istersin?','iphone')");
             * */
        }
    }
}

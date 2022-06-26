using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BookmarksUtil.Pages
{
    public class HomePage : BasePage<HomePageElementsMap, HomePageValidator>
    {
        public HomePage() : base(@"https://archiveofourown.org/")
        {

        }

    }
        

    public class HomePageElementsMap : BasePageElementMap
    {
        public By UserInfoLocator = By.XPath("//ul[@class='user navigation actions']");
        public By TosDivLocator = By.Id("tos_prompt");
        public By TosAgreeInput = By.Id("tos_agree");

        public IWebElement TosOverlay
        {
            get
            {
                return this.browser.FindElement(TosDivLocator);
            }
        }

        public IWebElement TosAgreeElement
        {
            get
            {
                return this.browser.FindElement(TosAgreeInput);
            }
        }
        public IWebElement UserInfo
        {
            get
            {
                return this.browser.FindElement(UserInfoLocator);
            }
        }
    }

    public class HomePageValidator : BasePageValidator<HomePageElementsMap>
    {
        public bool IsUserLoggedIn()
        {
            var cookies = Driver.Browser.Manage().Cookies;
            Cookie userCreds;
            try
            {
                Console.WriteLine(cookies.GetCookieNamed("user_credentials"));
                userCreds = cookies.GetCookieNamed("user_credentials");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + this.Map.UserInfoLocator.ToString() + "' was not found.");
                throw;
            }

            if (userCreds == null)
            {
                return false;
            }
            else{
                return true;
            }

        }
        public void GetUserInfo()
        {
            Console.WriteLine(this.Map.UserInfo.Text);
        }

        public string GetTOSText()
        {
            var elements = 
        }
        public IWebElement WaitForTosLoad()
        {
            try
            {
                var wait = new WebDriverWait(Driver.Browser, TimeSpan.FromSeconds(30));

                return wait.Until(x => x.FindElement(this.Map.TosDivLocator));

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + this.Map.TosDivLocator.ToString() + "' was not found.");
                throw;
            }
        }

        public IWebElement WaitPageLoad()
        {
            try
            {
                var wait = new WebDriverWait(Driver.Browser, TimeSpan.FromSeconds(30));

                return wait.Until(x => x.FindElement(this.Map.UserInfoLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + this.Map.UserInfoLocator.ToString() + "' was not found.");
                throw;
            }
        }
    }
}

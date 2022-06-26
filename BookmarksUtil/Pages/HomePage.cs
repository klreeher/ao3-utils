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
        public By UserInfoList = By.XPath("//ul[@class='user navigation actions']");
        public IWebElement UserInfo
        {
            get
            {
                return this.browser.FindElement(UserInfoList);
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
                Console.WriteLine("Element with locator: '" + this.Map.UserInfoList.ToString() + "' was not found.");
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

        public IWebElement WaitPageLoad()
        {
            try
            {
                var wait = new WebDriverWait(Driver.Browser, TimeSpan.FromSeconds(30));

                return wait.Until(x => x.FindElement(this.Map.UserInfoList));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + this.Map.UserInfoList.ToString() + "' was not found.");
                throw;
            }
        }
    }
}

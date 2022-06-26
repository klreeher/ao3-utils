using OpenQA.Selenium;

namespace BookmarksUtil
{
    public class BasePageElementMap
    {
        protected IWebDriver browser;
        public BasePageElementMap()
        {
            this.browser = Driver.Browser;
        }
    }
}
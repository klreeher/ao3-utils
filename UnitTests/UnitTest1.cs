using Bookmarks.Pages;
using BookmarksUtil;
using BookmarksUtil.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;


namespace UnitTests
{
    [TestFixture]
    public class Tests
    {

        [SetUp]
        public void SetUp()
        {
            Driver.StartBrowser();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.StopBrowser();
        }

        [Test]
        public void homePageNotLoggedIn()
        {
            HomePage homePage = new HomePage();
            homePage.Navigate();
            var userLoggedIn = homePage.Validate().IsUserLoggedIn();
            Console.WriteLine($"is the user logged in? {userLoggedIn}");
            Assert.IsFalse(userLoggedIn);

        }

        [Test]
        public void homePageTosLoad()
        {
            HomePage homePage = new HomePage();
            homePage.Navigate();
            var userLoggedIn = homePage.Validate().IsUserLoggedIn();
            Console.WriteLine($"is the user logged in? {userLoggedIn}");

            homePage.Validate().WaitForTosLoad();
            Console.WriteLine(homePage.Validate().GetTOSText());

        }

        [Test]
        public void bookmarksPageTests()
        {
            BookmarksPage homePage = new BookmarksPage();
            homePage.Navigate();
            Console.WriteLine(Driver.Browser.Url);
        }
    }
}
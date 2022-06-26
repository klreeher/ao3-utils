using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

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
    }

    public class HomePageValidator : BasePageValidator<HomePageElementsMap>
    {
    }
}


using BookmarksUtil;
using OpenQA.Selenium;

namespace Bookmarks.Pages;

///
/// this class is for parsing the actual ui of the booksmarks pages
///https://archiveofourown.org/users/{username}/bookmarks
///
public class BookmarksPage : BasePage<BookmarksElementMap, BookmarksPageValidator>
{

	public BookmarksPage() : base(@"https://archiveofourown.org/users/madecunningly/bookmarks")
    {

    }

}

public class BookmarksElementMap : BasePageElementMap
{
}

public class BookmarksPageValidator : BasePageValidator<BookmarksElementMap>
{
}

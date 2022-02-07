using UsedBookStore.Web.Models;

namespace Test.ViewModels;
public class BookViewModel
{
    public IEnumerable<BookModel> Books { get; set; }
}

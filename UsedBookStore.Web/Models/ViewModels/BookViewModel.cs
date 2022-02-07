namespace UsedBookStore.Web.Models.ViewModels
{
    public class BookViewModel
    {
        public BookModel BookForm { get; set; }
        public IEnumerable<BookModel> Books { get; set; }
    }
}

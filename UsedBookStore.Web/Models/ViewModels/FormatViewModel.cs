namespace UsedBookStore.Web.Models.ViewModels
{
    public class FormatViewModel
    {
        public FormatModel FormatForm { get; set; }
        public IEnumerable<BookModel> BooksByFormat { get; set; }
    }
}

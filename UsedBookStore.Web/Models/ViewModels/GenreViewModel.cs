namespace UsedBookStore.Web.Models.ViewModels
{
    public class GenreViewModel
    {
        public GenreModel GenreForm { get; set; }
        public IEnumerable<GenreModel> Genres { get; set; }
        public IEnumerable<BookModel> BooksByGenre { get; set; }
    }
}

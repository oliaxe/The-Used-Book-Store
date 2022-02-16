namespace UsedBookStore.Web.Models
{
    public class GenreModel
    {
        public GenreModel()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookModel> BooksByGenre { get; set; }
    }
}

namespace UsedBookStore.Web.Models
{
    public class GenreModel
    {
        public GenreModel()
        {

        }
        public GenreModel(string name)
        {
            Name = name;
        }

        public GenreModel(List<BookModel> booksByGenre)
        {
            BooksByGenre = booksByGenre;
        }

        public GenreModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public GenreModel(int id, string name, List<BookModel> booksByGenre)
        {
            Id = id;
            Name = name;
            BooksByGenre = booksByGenre;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookModel> BooksByGenre { get; set; }
    }
}

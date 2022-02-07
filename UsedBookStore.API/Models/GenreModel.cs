namespace UsedBookStore.API.Models
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

        public GenreModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}

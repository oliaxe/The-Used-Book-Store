namespace UsedBookStore.API.Models
{
    public class FormatModel
    {

        public FormatModel()
        {

        }
        public FormatModel(string name)
        {
            Name = name;
        }

        public FormatModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

    }
}

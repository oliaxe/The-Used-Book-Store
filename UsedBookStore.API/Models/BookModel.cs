namespace UsedBookStore.API.Models
{
    public class BookModel
    {
        public BookModel()
        {

        }

        public BookModel(int id)
        {
            Id = id;
        }

        public BookModel(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public BookModel(string title, string author, string iSBN, decimal price)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            Price = price;
        }

        public BookModel(string title, string author, string imageUrl, string iSBN, string description, decimal price)
        {
            Title = title;
            Author = author;
            ImageUrl = imageUrl;
            Description = description;
            ISBN = iSBN;
            Price = price;
        }

        public BookModel(int id, string title, string author, string iSBN, decimal price, FormatModel format, GenreModel genre, ConditionModel condition)
        {
            Id = id;
            Title = title;
            Author = author;
            ISBN = iSBN;
            Price = price;
            Format = format;
            Genre = genre;
            Condition = condition;
        }

        public BookModel(int id, string title, string author, string imageUrl, string description, string iSBN, decimal price, FormatModel format, GenreModel genre, ConditionModel condition)
        {
            Id = id;
            Title = title;
            Author = author;
            ImageUrl = imageUrl;
            Description = description;
            ISBN = iSBN;
            Price = price;
            Format = format;
            Genre = genre;
            Condition = condition;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }


        public FormatModel Format { get; set; }
        public GenreModel Genre { get; set; }
        public ConditionModel Condition { get; set; }
    }
}

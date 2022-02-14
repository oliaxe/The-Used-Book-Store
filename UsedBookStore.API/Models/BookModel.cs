namespace UsedBookStore.API.Models
{
    public class BookModel
    {
        public BookModel()
        {

        }
        public BookModel(string title)
        {
            Title = title;

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
        public BookModel(string title, string author, string description)
        {
            Title = title;
            Author = author;
            Description = description;
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

        public BookModel(string title, string author, string imageUrl, string description, string iSBN, decimal price, FormatModel format, GenreModel genre, ConditionModel condition)
        {
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

        public BookModel(int id, string title, string author, string imageUrl, string description, string iSBN, decimal price, int formatId, int genreId, int conditionId)
        {
            Id = id;
            Title = title;
            Author = author;
            ImageUrl = imageUrl;
            Description = description;
            ISBN = iSBN;
            Price = price;
            FormatId = formatId;
            GenreId = genreId;
            ConditionId = conditionId;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public int FormatId { get; set; }
        public int GenreId { get; set; }
        public int ConditionId { get; set; }

        public FormatModel Format { get; set; }
        public GenreModel Genre { get; set; }
        public ConditionModel Condition { get; set; }
        public virtual ICollection<OrderRowModel> OrderRows { get; set; }

    }
}

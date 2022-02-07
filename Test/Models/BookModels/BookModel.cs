namespace UsedBookStore.Web.Models
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

        public BookModel(int id, string title, string author, string iSBN, decimal price, string format, string genre, string condition)
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


        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }


        public string Format { get; set; }
        public string Genre { get; set; }
        public string Condition { get; set; }
    }
}

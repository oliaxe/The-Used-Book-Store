
namespace UsedBookStore.Web.Models
{
    public class BookModel
    {
        public BookModel()
        {

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

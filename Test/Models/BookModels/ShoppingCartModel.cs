namespace UsedBookStore.Web.Models
{
    public class ShoppingCartModel
    {
        public ShoppingCartModel()
        {

        }
        public ShoppingCartModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public int BookId { get; set; }
        public ICollection<BookModel> BookList { get; set; }

    }
}

namespace UsedBookStore.API.Models
{
    public class ShoppingCartCreateModel
    {
        public int Id { get; set; }
        public ICollection<BookModel> BookList { get; set; }
    }
}

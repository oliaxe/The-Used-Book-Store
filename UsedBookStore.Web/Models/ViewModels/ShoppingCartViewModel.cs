namespace UsedBookStore.Web.Models.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel(int bookId, int userId, int count)
        {
            BookId = bookId;
            UserId = userId;
            Count = count;
        }

        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Count { get; set; }

    }
}

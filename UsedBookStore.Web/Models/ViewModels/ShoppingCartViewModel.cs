namespace UsedBookStore.Web.Models.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel(int userId, int count)
        {
            UserId = userId;
            Count = count;
        }

        public int UserId { get; set; }
        public int Count { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}

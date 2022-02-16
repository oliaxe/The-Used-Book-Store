namespace UsedBookStore.Web.Models.ViewModels
{
    public class ShoppingCartViewModel
    {
        public int UserId { get; set; }
        public int Count { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}

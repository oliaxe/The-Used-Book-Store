namespace UsedBookStore.API.Models
{
    public class OrderCreateModel
    {
        public OrderCreateModel()
        {

        }
        public OrderCreateModel(int id, int userId, int shoppingCartId, bool isCheckedOut)
        {
            Id = id;
            UserId = userId;
            ShoppingCartId = shoppingCartId;
            IsCheckedOut = isCheckedOut;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int ShoppingCartId { get; set; }
        public bool IsCheckedOut { get; set; }

    }
}

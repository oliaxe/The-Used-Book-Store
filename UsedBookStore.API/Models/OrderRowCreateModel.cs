namespace UsedBookStore.API.Models
{
    public class OrderRowCreateModel
    {
        public OrderRowCreateModel()
        {


        }
        public OrderRowCreateModel(int orderRowId, int orderId, int bookId, int quantity)
        {
            OrderRowId = orderRowId;
            OrderId = orderId;
            BookId = bookId;
            Quantity = quantity;
        }

        public int OrderRowId { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }

    }
}

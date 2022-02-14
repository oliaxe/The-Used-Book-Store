namespace UsedBookStore.API.Models
{
    public class OrderRowModel
    {
        public OrderRowModel()
        {

        }

        public OrderRowModel(int orderRowId, OrderModel order, BookModel book, int quantity)
        {
            OrderRowId = orderRowId;
            Order = order;
            Book = book;
            Quantity = quantity;
        }
        public OrderRowModel(int orderRowId, int orderId, int bookId, int quantity)
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
        public OrderModel Order { get; set; }
        public BookModel Book { get; set; }

    }
}

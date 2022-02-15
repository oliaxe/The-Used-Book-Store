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
        public OrderRowModel(int orderRowId, int bookId, int quantity)
        {
            OrderRowId = orderRowId;
            BookId = bookId;
            Quantity = quantity;
        }

        public OrderRowModel(int quantity, OrderModel order, BookModel book)
        {
            Quantity = quantity;
            Order = order;
            Book = book;
        }

        public int OrderRowId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public OrderModel Order { get; set; }
        public BookModel Book { get; set; }

    }
}

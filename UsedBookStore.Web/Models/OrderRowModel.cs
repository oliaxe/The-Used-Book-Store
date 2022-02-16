namespace UsedBookStore.Web.Models
{
    public class OrderRowModel
    {
        public int OrderRowId { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public OrderModel Order { get; set; }
        public BookModel Book { get; set; }
    }
}

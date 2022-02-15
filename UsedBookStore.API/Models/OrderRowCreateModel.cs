namespace UsedBookStore.API.Models
{
    public class OrderRowCreateModel
    {
        public OrderRowCreateModel()
        {


        }
        public OrderRowCreateModel(int bookId, int quantity)
        {
            BookId = bookId;
            Quantity = quantity;
        }
        public int OrderRowId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }

    }
}

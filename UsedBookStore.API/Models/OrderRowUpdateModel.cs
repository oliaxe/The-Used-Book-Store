namespace UsedBookStore.API.Models
{
    public class OrderRowUpdateModel
    {
        public int OrderRowId { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
}

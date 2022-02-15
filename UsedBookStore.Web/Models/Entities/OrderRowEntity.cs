namespace UsedBookStore.Web.Models.Entities
{
    public class OrderRowEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
}

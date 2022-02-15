namespace UsedBookStore.Web.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerEmail { get; set; }
        public OrderRowModel OrderRowModel { get; set; }
    }
}

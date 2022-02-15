namespace UsedBookStore.API.Models
{
    public class OrderUpdateModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string CustomerEmail { get; set; }
    }
}

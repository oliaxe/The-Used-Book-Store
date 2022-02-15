namespace UsedBookStore.API.Models
{
    public class OrderModel
    {

        public OrderModel(int id, DateTime orderDate, CustomerModel customer)
        {
            Id = id;
            OrderDate = orderDate;
            Customer = customer;
        }

        public OrderModel(int id, DateTime orderDate, string customerEmail)
        {
            Id = id;
            OrderDate = orderDate;
            CustomerEmail = customerEmail;
        }

        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string CustomerEmail { get; set; }
        public CustomerModel Customer { get; set; }
    }
}
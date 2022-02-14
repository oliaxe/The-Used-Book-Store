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

        public OrderModel(int id, DateTime orderDate, int customerId)
        {
            Id = id;
            OrderDate = orderDate;
            CustomerId = customerId;
        }

        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public int CustomerId { get; set; }
        public CustomerModel Customer { get; set; }
    }
}
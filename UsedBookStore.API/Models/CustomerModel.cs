namespace UsedBookStore.API.Models
{
    public class CustomerModel
    {

        public CustomerModel(string customerEmail)
        {
            CustomerEmail = customerEmail;
        }

        public CustomerModel(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string CustomerEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public ICollection<OrderModel> Orders { get; set; }
    }
}

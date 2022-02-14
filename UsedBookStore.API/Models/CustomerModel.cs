namespace UsedBookStore.API.Models
{
    public class CustomerModel
    {
        public CustomerModel(int id)
        {
            Id = id;
        }

        public CustomerModel(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public ICollection<OrderModel> Orders { get; set; }
    }
}

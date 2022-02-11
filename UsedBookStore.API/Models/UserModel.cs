namespace UsedBookStore.API.Models
{
    public class UserModel
    {
        public UserModel()
        {

        }
        public UserModel(int id)
        {
            Id = id;
        }

        public UserModel(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public UserModel(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public UserModel(string firstName, string lastName, string streetName, string postalCode, string city)
        {
            FirstName = firstName;
            LastName = lastName;
            StreetName = streetName;
            PostalCode = postalCode;
            City = city;
        }

        public UserModel(int id, string firstName, string lastName, string streetName, string postalCode, string city)
        {

            Id = id;
            FirstName = firstName;
            LastName = lastName;
            StreetName = streetName;
            PostalCode = postalCode;
            City = city;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
    }
}

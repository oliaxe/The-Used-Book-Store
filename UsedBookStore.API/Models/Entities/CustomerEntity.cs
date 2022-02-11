using System.ComponentModel.DataAnnotations;

namespace UsedBookStore.API.Models.Entities
{
    public class CustomerEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string StreetName { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string City { get; set; }
        public ICollection<OrderEntity> Orders { get; set; }
    }
}

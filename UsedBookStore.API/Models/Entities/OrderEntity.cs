
using System.ComponentModel.DataAnnotations;

namespace UsedBookStore.API.Models.Entities
{
    public class OrderEntity
    {
        public OrderEntity(DateTime orderDate, string customerEmail)
        {
            OrderDate = orderDate;
            CustomerEmail = customerEmail;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;
        [Required]
        public string CustomerEmail { get; set; }

        public CustomerEntity Customer { get; set; }
        public ICollection<OrderRowEntity> OrderRows { get; }

    }
}

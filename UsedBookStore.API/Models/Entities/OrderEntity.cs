using System.ComponentModel.DataAnnotations;

namespace UsedBookStore.API.Models.Entities
{
    public class OrderEntity
    {
        public OrderEntity(int id, DateTime orderDate, int customerId)
        {
            Id = id;
            OrderDate = orderDate;
            CustomerId = customerId;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;
        [Required]
        public int CustomerId { get; set; }

        public CustomerEntity Customer { get; set; }
        public ICollection<OrderRowEntity> OrderRows { get; }

    }
}

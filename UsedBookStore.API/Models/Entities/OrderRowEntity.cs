using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsedBookStore.API.Models.Entities
{
    public class OrderRowEntity
    {
        public OrderRowEntity(int bookId, int quantity, int quantity1)
        {
            BookId = bookId;
            Quantity = quantity;
        }

        public OrderRowEntity(int orderRowId, int orderId, int bookId, int quantity)
        {
            OrderRowId = orderRowId;
            OrderId = orderId;
            BookId = bookId;
            Quantity = quantity;
        }


        [Key]
        public int OrderRowId { get; set; }
        [Required]
        [ForeignKey("Orders")]
        public int OrderId { get; set; }
        [Required]
        [ForeignKey("Books")]
        public int BookId { get; set; }
        [Required]
        public int Quantity { get; set; }
        public OrderEntity Order { get; set; }
        public BookEntity Book { get; set; }
    }
}

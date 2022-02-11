using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsedBookStore.API.Models.Entities
{
    public class OrderRowEntity
    {
        [Key]
        public int OrderRowId { get; set; }
        [Required]
        [ForeignKey("Orders")]
        public int OrderId { get; set; }
        [Required]
        [ForeignKey("Products")]
        public int BookId { get; set; }
        [Required]
        public int Quantity { get; set; }
        public OrderEntity Order { get; set; }
        public BookEntity Book { get; set; }
    }
}

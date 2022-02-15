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

        //public OrderRowEntity(int orderRowId, OrderEntity order, BookEntity book, int quantity)
        //{
        //    OrderRowId = orderRowId;
        //    Order = order;
        //    Book = book;
        //    Quantity = quantity;

        //}

        public OrderRowEntity(int orderRowId, int orderId, int bookId, int quantity, OrderEntity order, BookEntity book)
        {
            OrderRowId = orderRowId;
            OrderId = orderId;
            BookId = bookId;
            Quantity = quantity;
            Order = order;
            Book = book;
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

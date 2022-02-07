using System.ComponentModel.DataAnnotations;

namespace UsedBookStore.API.Models.Entities
{
    public class ShoppingCartEntity
    {
        public ShoppingCartEntity()
        {

        }

        public ShoppingCartEntity(List<BookEntity> books)
        {
            Books = books;
        }

        public ShoppingCartEntity(int id, List<BookEntity> books)
        {
            Id = id;
            Books = books;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public virtual ICollection<BookEntity> Books { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace UsedBookStore.Web.Models.Entities
{
    public class GenreEntity
    {
        public GenreEntity()
        {

        }


        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }


        public virtual ICollection<BookEntity> Books { get; set; }

    }
}

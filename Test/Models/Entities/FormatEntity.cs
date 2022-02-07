using System.ComponentModel.DataAnnotations;

namespace UsedBookStore.Web.Models.Entities
{
    public class FormatEntity
    {
        public FormatEntity()
        {

        }
        public FormatEntity(string name)
        {
            Name = name;
        }

        public FormatEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public FormatEntity(int id, string name, List<BookEntity> books)
        {
            Id = id;
            Name = name;
            Books = books;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<BookEntity> Books { get; set; }
    }
}

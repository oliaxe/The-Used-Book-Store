using System.ComponentModel.DataAnnotations;

namespace UsedBookStore.API.Models.Entities
{
    public class GenreEntity
    {
        public GenreEntity()
        {

        }
        public GenreEntity(string name)
        {
            Name = name;
        }

        public GenreEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public GenreEntity(int id, string name, List<BookEntity> books)
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

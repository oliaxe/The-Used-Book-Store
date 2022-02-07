using System.ComponentModel.DataAnnotations;

namespace UsedBookStore.API.Models.Entities
{
    public class ConditionEntity
    {
        public ConditionEntity()
        {

        }
        public ConditionEntity(string name)
        {
            Name = name;
        }

        public ConditionEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public ConditionEntity(int id, string name, List<BookEntity> books)
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

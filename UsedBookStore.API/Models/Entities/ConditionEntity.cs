using System.ComponentModel.DataAnnotations;

namespace UsedBookStore.API.Models.Entities
{
    public class ConditionEntity
    {
        public ConditionEntity()
        {

        }

        public ConditionEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<BookEntity> Books { get; set; }
    }
}

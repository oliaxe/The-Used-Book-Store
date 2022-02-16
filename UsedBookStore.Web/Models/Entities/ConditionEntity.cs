using System.ComponentModel.DataAnnotations;

namespace UsedBookStore.Web.Models.Entities
{
    public class ConditionEntity
    {
        public ConditionEntity()
        {

        }


        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<BookEntity> Books { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace UsedBookStore.Web.Models.Entities
{
    public class BookEntity
    {
        public BookEntity()
        {

        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }

        [Required]
        public string ISBN { get; set; }
        [Required]
        [Range(1, 10000)]
        public decimal Price { get; set; }

        public int FormatID { get; set; }
        public int GenreId { get; set; }
        public int ConditionId { get; set; }


        [Required]
        public FormatEntity Format { get; set; }
        [Required]
        public GenreEntity Genre { get; set; }
        [Required]
        public ConditionEntity Condition { get; set; }



    }
}

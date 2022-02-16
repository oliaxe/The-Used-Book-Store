using System.ComponentModel.DataAnnotations;

namespace UsedBookStore.API.Models.Entities
{
    public class BookEntity
    {
        public BookEntity()
        {

        }

        public BookEntity(int id, string title, string author, string imageUrl, string description, string iSBN, decimal price, int formatID, int genreId, int conditionId)
        {
            Id = id;
            Title = title;
            Author = author;
            ImageUrl = imageUrl;
            Description = description;
            ISBN = iSBN;
            Price = price;
            FormatId = formatID;
            GenreId = genreId;
            ConditionId = conditionId;
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

        public int FormatId { get; set; }
        public int GenreId { get; set; }
        public int ConditionId { get; set; }


        [Required]
        public FormatEntity Format { get; set; }
        [Required]
        public GenreEntity Genre { get; set; }
        [Required]
        public ConditionEntity Condition { get; set; }
        [Required]
        public ICollection<OrderRowEntity> OrderRows { get; set; }


    }
}

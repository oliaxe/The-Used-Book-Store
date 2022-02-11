using System.ComponentModel.DataAnnotations;

namespace UsedBookStore.API.Models.Entities
{
    public class BookEntity
    {
        public BookEntity()
        {

        }

        public BookEntity(int id)
        {
            Id = id;
        }

        public BookEntity(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public BookEntity(string title, string author, string iSBN, decimal price)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            Price = price;
        }

        public BookEntity(string title, string author, string description, string iSBN)
        {
            Title = title;
            Author = author;
            Description = description;
            ISBN = iSBN;
        }

        public BookEntity(string title, string author, string imageUrl, string description, string iSBN, decimal price)
        {
            Title = title;
            Author = author;
            ImageUrl = imageUrl;
            Description = description;
            ISBN = iSBN;
            Price = price;
        }

        public BookEntity(int id, string title, string author, string iSBN, decimal price, FormatEntity format, GenreEntity genre, ConditionEntity condition)
        {
            Id = id;
            Title = title;
            Author = author;
            ISBN = iSBN;
            Price = price;
            Format = format;
            Genre = genre;
            Condition = condition;
        }

        public BookEntity(int id, string title, string author, string iSBN, decimal price, int formatID, int genreId, int conditionId)
        {
            Id = id;
            Title = title;
            Author = author;
            ISBN = iSBN;
            Price = price;
            FormatId = formatID;
            GenreId = genreId;
            ConditionId = conditionId;
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

        public BookEntity(int id, string title, string author, string iSBN, decimal price, FormatEntity format, GenreEntity genre, ConditionEntity condition, int formatID, int genreId, int conditionId)
        {
            Id = id;
            Title = title;
            Author = author;
            ISBN = iSBN;
            Price = price;
            Format = format;
            Genre = genre;
            Condition = condition;
            FormatId = formatID;
            GenreId = genreId;
            ConditionId = conditionId;
        }

        public BookEntity(int id, string title, string author, string description, string iSBN, decimal price, int formatID, int genreId, int conditionId, FormatEntity format, GenreEntity genre, ConditionEntity condition)
        {
            Id = id;
            Title = title;
            Author = author;
            Description = description;
            ISBN = iSBN;
            Price = price;
            FormatId = formatID;
            GenreId = genreId;
            ConditionId = conditionId;
            Format = format;
            Genre = genre;
            Condition = condition;
        }

        public BookEntity(int id, string title, string author, string imageUrl, string description, string iSBN, decimal price, int formatID, int genreId, int conditionId, FormatEntity format, GenreEntity genre, ConditionEntity condition)
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
            Format = format;
            Genre = genre;
            Condition = condition;
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

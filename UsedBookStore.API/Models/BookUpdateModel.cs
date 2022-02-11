namespace UsedBookStore.API.Models
{
    public class BookUpdateModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public int FormatId { get; set; }
        public int GenreId { get; set; }
        public int ConditionId { get; set; }

    }
}

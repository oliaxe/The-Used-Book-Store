namespace UsedBookStore.Web.Models.Entities
{
    public class ShoppingCartEntity
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public BookEntity Book { get; set; }
        public int Count { get; set; }
        public AppUser User { get; set; }
    }
}

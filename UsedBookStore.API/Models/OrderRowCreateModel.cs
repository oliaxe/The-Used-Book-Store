namespace UsedBookStore.API.Models
{
    public class OrderRowCreateModel
    {
        public OrderRowCreateModel()
        {


        }

        public int OrderRowId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }

    }
}

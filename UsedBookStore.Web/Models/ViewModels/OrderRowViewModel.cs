namespace UsedBookStore.Web.Models.ViewModels;


public class OrderRowViewModel
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int BookId { get; set; }
    public int Quantity { get; set; }
    public IEnumerable<OrderRowModel> OrderRows { get; set; }
    public IEnumerable<BookModel> Books { get; set; }

}


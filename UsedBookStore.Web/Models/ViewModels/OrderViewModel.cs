namespace UsedBookStore.Web.Models.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserEmail { get; set; }
        public OrderModel Order { get; set; }
        public IEnumerable<OrderModel> Orders { get; set; }
        public IEnumerable<OrderRowModel> OrderRows { get; set; }
        public OrderRowViewModel OrderRow { get; set; }

    }
}

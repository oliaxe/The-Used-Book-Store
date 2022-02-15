namespace UsedBookStore.Web.Models.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public IEnumerable<OrderRowViewModel> OrderRows { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserEmail { get; set; }
        public IEnumerable<OrderModel> Orders { get; set; }
        public OrderRowViewModel OrderRow { get; set; }

    }
}

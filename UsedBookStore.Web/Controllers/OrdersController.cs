using Microsoft.AspNetCore.Mvc;
using UsedBookStore.Web.Models;
using UsedBookStore.Web.Models.ViewModels;

namespace UsedBookStore.Web.Controllers
{
    public class OrdersController : Controller
    {
        List<OrderViewModel> orders;
        OrderViewModel orderModel;
        public async Task<IActionResult> Index()
        {
            var orders = new OrderViewModel();
            orders.Orders = new List<OrderModel>();
            using (var client = new HttpClient())
            {
                orders.Orders = await client.GetFromJsonAsync<List<OrderModel>>("https://localhost:7090/api/Orders");
            }
            ViewBag.Orders = orders.Orders;

            return View(orders);
        }
    }
}

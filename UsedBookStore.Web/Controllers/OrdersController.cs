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
            var orderRows = new OrderRowViewModel();
            orders.Orders = new List<OrderModel>();
            orderRows.OrderRows = new List<OrderRowModel>();

            using (var client = new HttpClient())
            {
                orders.Orders = await client.GetFromJsonAsync<List<OrderModel>>("https://localhost:7090/api/Orders?key=gorbatjov");
            }

            ViewBag.OrderRows = orderRows.OrderRows;
            ViewBag.Orders = orders.Orders;

            return View(orders);
        }

        public async Task<IActionResult> Details(int id)
        {
            var orders = new OrderViewModel();
            var orderRows = new OrderRowViewModel();
            orders.Orders = new List<OrderModel>();
            orderRows.OrderRows = new List<OrderRowModel>();

            List<OrderRowModel> orderRowModelsId = new List<OrderRowModel>();

            using (var client = new HttpClient())
            {
                orders.Order = await client.GetFromJsonAsync<OrderModel>("https://localhost:7090/api/Orders/" + id + "?key=gorbatjov");
                orderRows.OrderRows = await client.GetFromJsonAsync<List<OrderRowModel>>("https://localhost:7090/api/OrderRows?key=gorbatjov");

            }

            foreach (var orderRow in orderRows.OrderRows)
            {
                if (orderRow.Order.Id == id)
                {
                    orderRowModelsId.Add(orderRow);
                }
            }

            ViewBag.OrderRowsId = orderRowModelsId;

            return View(orders);

        }

    }
}

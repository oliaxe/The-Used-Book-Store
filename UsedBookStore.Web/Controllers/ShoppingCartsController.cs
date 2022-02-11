using Microsoft.AspNetCore.Mvc;

namespace UsedBookStore.Web.Controllers
{
    public class ShoppingCartsController : Controller
    {
        public IActionResult Index()
        {
            return View();

        }
    }
}

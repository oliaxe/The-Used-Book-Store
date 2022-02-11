using Microsoft.AspNetCore.Mvc;
using UsedBookStore.Web.Models;
using UsedBookStore.Web.Models.ViewModels;

namespace UsedBookStore.Web.Controllers
{
    public class FormatsController : Controller
    {
        public async Task<IActionResult> Index(int id)
        {
            var formatModel = new FormatViewModel();
            formatModel.BooksByFormat = new List<BookModel>();

            using (var client = new HttpClient())
            {
                formatModel.BooksByFormat = await client.GetFromJsonAsync<IEnumerable<BookModel>>("https://localhost:7090/api/Books");
            }


            using (var client = new HttpClient())
            {
                formatModel.FormatForm = await client.GetFromJsonAsync<FormatModel>("https://localhost:7090/api/Formats/" + id);
            }


            return View(formatModel);

        }

    }
}
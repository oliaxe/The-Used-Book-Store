using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Test.ViewModels;
using UsedBookStore.Web.Models;

namespace UsedBookStore.Web.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var bookModel = new BookViewModel();
            bookModel.Books = new List<BookModel>();

            using (var client = new HttpClient())
            {
                bookModel.Books = await client.GetFromJsonAsync<IEnumerable<BookModel>>("https://localhost:7090/api/Books");
            }

            return View(bookModel);
            //}
        }
    }
}
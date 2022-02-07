using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsedBookStore.Web.Models;
using UsedBookStore.Web.Models.ViewModels;

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
        }
        public async Task<IActionResult> Details(int id)
        {
            var bookModel = new BookViewModel();

            using (var client = new HttpClient())
            {
                bookModel.BookForm = await client.GetFromJsonAsync<BookModel>("https://localhost:7090/api/Books/" + id);
            }

            return View(bookModel);

        }

    }

}

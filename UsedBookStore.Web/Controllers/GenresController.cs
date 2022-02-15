using Microsoft.AspNetCore.Mvc;
using UsedBookStore.Web.Models;
using UsedBookStore.Web.Models.ViewModels;

namespace UsedBookStore.Web.Controllers
{
    public class GenresController : Controller
    {
        public async Task<IActionResult> Index(int id)
        {
            var genreModel = new GenreViewModel();
            genreModel.BooksByGenre = new List<BookModel>();

            using (var client = new HttpClient())
            {
                genreModel.BooksByGenre = await client.GetFromJsonAsync<IEnumerable<BookModel>>("https://localhost:7090/api/Books?key=gorbatjov");
            }


            using (var client = new HttpClient())
            {
                genreModel.GenreForm = await client.GetFromJsonAsync<GenreModel>("https://localhost:7090/api/Genres/" + id + "?key=gorbatjov");
            }


            return View(genreModel);

        }

    }
}
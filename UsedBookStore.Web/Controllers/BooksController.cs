using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsedBookStore.Web.Helpers;
using UsedBookStore.Web.Models;
using UsedBookStore.Web.Models.ViewModels;

namespace UsedBookStore.Web.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        List<ShoppingCartItem> shoppingCart;
        BookViewModel bookModel;
        List<BookModel> bookModelList;
        ShoppingCartViewModel shoppingCartViewModel;

        public async Task<IActionResult> Index()
        {
            var bookModel = new BookViewModel();
            bookModel.Books = new List<BookModel>();

            using (var client = new HttpClient())
            {
                bookModel.Books = await client.GetFromJsonAsync<IEnumerable<BookModel>>("https://localhost:7090/api/Books");
            }

            ViewBag.Books = bookModel.Books;
            ViewBag.ShoppingCart = SessionHelper.GetObjectAsJson<List<ShoppingCartItem>>(HttpContext.Session, "shoppingCart");

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



        public async Task<IActionResult> AddToCart(int id)
        {
            bookModel = new BookViewModel();
            bookModel.Books = new List<BookModel>();


            using (var client = new HttpClient())
            {
                bookModel.Books = await client.GetFromJsonAsync<IEnumerable<BookModel>>("https://localhost:7090/api/Books");
            }


            ViewBag.Books = bookModel.Books;
            ViewBag.ShoppingCart = SessionHelper.GetObjectAsJson<List<ShoppingCartItem>>(HttpContext.Session, "shoppingCart");


            if (SessionHelper.GetObjectAsJson<List<ShoppingCartItem>>(HttpContext.Session, "shoppingCart") == null)
            {
                shoppingCart = new List<ShoppingCartItem>();
                shoppingCart.Add(new ShoppingCartItem() { Book = bookModel.Books.FirstOrDefault(x => x.Id == id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "shoppingCart", shoppingCart);
            }

            else
            {
                List<ShoppingCartItem> shoppingCart = SessionHelper.GetObjectAsJson<List<ShoppingCartItem>>(HttpContext.Session, "shoppingCart");
                int index = ItemExists(id);
                if (index != -1)
                    shoppingCart[index].Quantity++;
                else
                    shoppingCart.Add(new ShoppingCartItem() { Book = bookModel.Books.FirstOrDefault(x => x.Id == id), Quantity = 1 });

                SessionHelper.SetObjectAsJson(HttpContext.Session, "shoppingCart", shoppingCart);
            }


            return RedirectToAction("Index");
        }


        public async Task<IActionResult> CheckOut(List<ShoppingCartItem> shoppingCartItems)
        {

            ViewBag.ShoppingCart = SessionHelper.GetObjectAsJson<List<ShoppingCartItem>>(HttpContext.Session, "shoppingCart");


            return View("CheckOut");
        }


        public int ItemExists(int id)
        {
            List<ShoppingCartItem> shoppingCart = SessionHelper.GetObjectAsJson<List<ShoppingCartItem>>(HttpContext.Session, "shoppingCart");
            for (int i = 0; i < shoppingCart.Count; i++)
            {
                if (shoppingCart[i].Book.Id == id)
                    return i;
            }

            return -1;
        }

    }

}

using Microsoft.AspNetCore.Mvc;
using UsedBookStore.Web.Models;
using UsedBookStore.Web.Models.ViewModels;

namespace UsedBookStore.Web.Controllers
{
    public class ConditionsController : Controller
    {
        public async Task<IActionResult> Index(int id)
        {
            var conditionModel = new ConditionViewModel();
            conditionModel.BooksByCondition = new List<BookModel>();

            using (var client = new HttpClient())
            {
                conditionModel.BooksByCondition = await client.GetFromJsonAsync<IEnumerable<BookModel>>("https://localhost:7090/api/Books?key=gorbatjov");
            }


            using (var client = new HttpClient())
            {
                conditionModel.ConditionForm = await client.GetFromJsonAsync<ConditionModel>("https://localhost:7090/api/Conditions/" + id + "?key=gorbatjov");
            }


            return View(conditionModel);

        }

    }
}
using Microsoft.AspNetCore.Mvc;

namespace Life_Balance.WebApp.Controllers.API
{
    public class DiaryController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}
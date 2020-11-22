using Microsoft.AspNetCore.Mvc;

namespace Life_Balance.WebApp.Controllers
{
    public class DiaryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
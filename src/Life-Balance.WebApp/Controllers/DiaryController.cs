using System.Threading.Tasks;
using Life_Balance.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Life_Balance.WebApp.Controllers
{
    public class DiaryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        /// <summary>
        /// For new diary entry
        /// </summary>
        /// <returns>View page</returns>
        public IActionResult DiaryEntry()
        {
            return View();
        }
        
        /// <summary>
        /// For new diary entry
        /// </summary>
        /// <param name="model">Diary ViewModel</param>
        /// <returns></returns>
        public async Task<IActionResult> DiaryEntry(DiaryEntryViewModel model)
        {
            return View(model);
        }
    }
}
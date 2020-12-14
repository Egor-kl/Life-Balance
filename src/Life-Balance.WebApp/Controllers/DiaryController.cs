using System;
using System.Threading.Tasks;
using Life_Balance.BLL.Interfaces;
using Life_Balance.BLL.ModelsDTO;
using Life_Balance.Common.Interfaces;
using Life_Balance.DAL.Models;
using Life_Balance.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Life_Balance.WebApp.Controllers
{
    public class DiaryController : Controller
    {
        private readonly IDiaryService _diaryService;
        private readonly IRepository<Diary> _diaryRepository;
        private readonly ILogger _logger;
        private readonly IIdentityService _identityService;

        public DiaryController(IDiaryService diaryService,
                               IRepository<Diary> diaryRepository, 
                               ILogger<DiaryController> logger, 
                               IIdentityService identityService)
        {
            _diaryRepository = diaryRepository ?? throw new ArgumentNullException(nameof(diaryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _diaryService = diaryService ?? throw new ArgumentNullException(nameof(diaryService));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        /// <summary>
        /// Add new entry.
        /// </summary>
        /// <param name="model">DiaryEntryViewModel</param>
        /// <returns>View</returns>
        [HttpPost]
        public async Task<IActionResult> Create(DiaryEntryViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = await _identityService.GetUserIdByNameAsync(User.Identity.Name);
                    model.UserId = userId;
                    await _diaryService.CreateNewEntry(model.Title, model.Entry, DateTime.Now, userId);
                
                    _logger.LogInformation($"{User.Identity.Name} successfully created diary with id {model.Id}.");
                
                    return RedirectToAction("Index", "Profile");
                }
                catch (Exception e)
                {
                    _logger.LogError($"There was an error while adding new diary {e.Message}");
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var diaryDto = new DiaryDTO();

            var model = new DiaryEntryViewModel()
            {
                Id = diaryDto.Id,
                UserId = diaryDto.UserId,
                Title = diaryDto.Title,
                Entry = diaryDto.Entries,
                Date = diaryDto.Date
            };
            
            return View(model);
        }

        /// <summary>
        /// Update diary
        /// </summary>
        /// <param name="model">DiaryEntryViewModel</param>
        /// <returns>View</returns>
        public async Task<IActionResult> Edit(DiaryEntryViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = await _identityService.GetUserIdByNameAsync(User.Identity.Name);

                    await _diaryService.UpdateEntry(model.Title, model.Entry, DateTime.Now);

                    _logger.LogInformation($"{User.Identity.Name} successfully edited entry with id: {model.Id}.");
                
                    RedirectToAction("Index", "Profile");
                }
                catch (Exception e)
                {
                    _logger.LogError($"There was an error while update diary {e.Message}");
                }
            }
            return View(model);
        }

        /// <summary>
        /// Delete entry by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var userId = await _identityService.GetUserIdByNameAsync(User.Identity.Name);

                await _diaryService.DeleteEntry(id);
                _logger.LogInformation($"{User.Identity.Name} successfully deleted diary with id: {id}.");
            }
            catch (Exception e)
            {
                _logger.LogInformation($"{User.Identity.Name} can't delete diary with id: {id}.");
            }
            
            return RedirectToAction("Index", "Profile");
        }

        /// <summary>
        /// View for info about entry
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public async Task<IActionResult> Info(int id)
        {
                var userId = await _identityService.GetUserIdByNameAsync(User.Identity.Name);
                
                _logger.LogInformation($"{User.Identity.Name} view info about entry.");
                
                return View(await _diaryService.GetEntryById(id));
        }
    }
}
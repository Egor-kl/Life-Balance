using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Life_Balance.BLL.Interfaces;
using Life_Balance.Common.Interfaces;
using Life_Balance.DAL.Models;
using Life_Balance.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Life_Balance.WebApp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ILogger _logger;
        private readonly IIdentityService _identityService;
        private readonly IProfileService _profileService;

        public ProfileController(ILogger<ProfileController> logger,  IIdentityService identityService, IRepository<Profile> diaryRepository, IProfileService profileService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _profileService = profileService ?? throw new ArgumentNullException(nameof(profileService));
        }

        /// <summary>
        /// Get profile
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var userId = await _identityService.GetUserIdByNameAsync(User.Identity.Name);

            var profileDto = _profileService.GetAllDiary(userId).GetAwaiter().GetResult();
            
            _logger.LogInformation($"{profileDto.Count} diaries showed for user {User.Identity.Name}.");

            var diaryEntryViewModel = new List<DiaryEntryViewModel>();

            profileDto.ForEach(a =>
            {
                var diary = new DiaryEntryViewModel()
                {
                    Id = a.Id,
                    UserId = a.UserId,
                    Title = a.Title,
                    Entry = a.Entries,
                    Date = a.Date
                };
                
                diaryEntryViewModel.Add(diary);
            });
            
            return View(diaryEntryViewModel);
        }

        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProfileViewModel model)
        {
            var user = _profileService.UpdateProfile(model.UserName, model.Avatar);
            return ViewBag(model);
        }
    }
}
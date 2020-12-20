using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Life_Balance.BLL.Interfaces;
using Life_Balance.BLL.ModelsDTO;
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

        public ProfileController(ILogger<ProfileController> logger, IIdentityService identityService, IProfileService profileService)
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

            var profileDto = await _profileService.GetAllDiary(userId);
            
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

        /// <summary>
        /// Edit page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit()
        {
            var profileDto = new ProfileDTO();

            var model = new ProfileViewModel()
            {
                Avatar = profileDto.Avatar,
                UserName = profileDto.UserName
            };
            
            return View(model);
        }

        /// <summary>
        /// Edit profile
        /// </summary>
        /// <param name="model">profile view model</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(ProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _profileService.UpdateProfile(model.UserName, model.Avatar);
                    
                    _logger.LogInformation($"{User.Identity.Name} edit profile");

                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    _logger.LogInformation($"{User.Identity.Name} don't edit profile. Error on the server side. {e.Message}");
                }
            }
            
            return View(model);
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Life_Balance.BLL.Interfaces;
using Life_Balance.BLL.ModelsDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Life_Balance.WebApp.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
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
        /// Get profile.
        /// </summary>
        /// <returns></returns>
        [HttpGet("profile")]
        [Authorize]
        public async Task<Dictionary<int, object>> GetProfile()
        {
            var userId = await _identityService.GetUserIdByNameAsync(User.Identity.Name);

            Dictionary<int, object> profile = new Dictionary<int, object>();
            
            var eventByUserId= await _profileService.GetAllEventByUserId(userId);
            var taskByUserId = await _profileService.GetAllTaskByUserId(userId);
            var diaryByUserId = await _profileService.GetAllDiaryByUserId(userId);

            profile.Add(1, eventByUserId);
            profile.Add(2, taskByUserId);
            profile.Add(3, diaryByUserId);

            return profile;
        }

        /// <summary>
        /// Get all diary by user id.
        /// </summary>
        /// <returns>json</returns>
        [HttpGet("diaries")]
        [Authorize]
        public async Task<IActionResult> GetAllDiary()
        {
            var userId = await _identityService.GetUserIdByNameAsync(User.Identity.Name);

            var profileDto = await _profileService.GetAllDiaryByUserId(userId);
            
            _logger.LogInformation($"{profileDto.Count} diaries showed for user {User.Identity.Name}.");

            return Ok(profileDto);
        }

        /// <summary>
        /// Get all events by user id.
        /// </summary>
        /// <returns>json</returns>
        [HttpGet("events")]
        [Authorize]
        public async Task<IActionResult> GetAllEvents()
        {
            var userId = await _identityService.GetUserIdByNameAsync(User.Identity.Name);

            var eventsDto = await _profileService.GetAllEventByUserId(userId);
            
            _logger.LogInformation($"{eventsDto.Count} diaries showed for user {User.Identity.Name}.");

            return Ok(eventsDto);
        }
        
        /// <summary>
        /// Get all tasks by user id.
        /// </summary>
        /// <returns>json</returns>
        [HttpGet("tasks")]
        [Authorize]
        public async Task<IActionResult> GetAllTask()
        {
            var userId = await _identityService.GetUserIdByNameAsync(User.Identity.Name);

            var taskDto = await _profileService.GetAllTaskByUserId(userId);
            
            _logger.LogInformation($"{taskDto.Count} diaries showed for user {User.Identity.Name}.");

            return Ok(taskDto);
        }
    }
}
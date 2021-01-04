using System;
using System.Threading.Tasks;
using Life_Balance.BLL.Interfaces;
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
        /// Get profile
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = await _identityService.GetUserIdByNameAsync(User.Identity.Name);

            var profileDto = await _profileService.GetAllDiaryByUserId(userId);
            
            _logger.LogInformation($"{profileDto.Count} diaries showed for user {User.Identity.Name}.");

            return Ok(profileDto);
        }
    }
}
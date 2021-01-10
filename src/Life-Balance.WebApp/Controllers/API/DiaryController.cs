using System;
using System.Threading.Tasks;
using Life_Balance.BLL.Interfaces;
using Life_Balance.BLL.ModelsDTO;
using Life_Balance.Common.Interfaces;
using Life_Balance.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Life_Balance.WebApp.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiaryController : ControllerBase
    {
        private readonly IDiaryService _diaryService;
        private readonly IRepository<Diary> _diaryRepository;
        private readonly ILogger _logger;
        private readonly IIdentityService _identityService;
        private readonly IProfileService _profileService;

        public DiaryController(IDiaryService diaryService,
                               IRepository<Diary> diaryRepository, 
                               ILogger<DiaryController> logger,
                               IIdentityService identityService,
                               IProfileService profileService)
        {
            _diaryRepository = diaryRepository ?? throw new ArgumentNullException(nameof(diaryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _diaryService = diaryService ?? throw new ArgumentNullException(nameof(diaryService));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _profileService = profileService ?? throw new ArgumentNullException(nameof(profileService));
        }
        
        /// <summary>
        /// Get diary by id
        /// </summary>
        /// <param name="id">diary id.</param>
        /// <returns>json result</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var diary = await _diaryService.GetEntryById(id);
            
            _logger.LogInformation($"Successfully sent diary with Id.");
           
            return Ok(diary);
        }

        /// <summary>
        /// Get all diary
        /// </summary>
        /// <returns>json result</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var diaries = await _diaryService.GetAll();

            _logger.LogInformation($"Successfully sent diary all diary.");
           
            return Ok(diaries);
        }

        /// <summary>
        /// Delete by id.
        /// </summary>
        /// <param name="id">Diary id.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            await _diaryService.DeleteEntry(id);
            
            return NoContent();
        }

        /// <summary>
        /// Update entry.
        /// </summary>
        /// <param name="diaryDto">model</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]DiaryDTO diaryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _diaryService.UpdateEntry(diaryDto);
            
            _logger.LogInformation($"Diary has been update");

            return Ok();
        }

        /// <summary>
        /// Create new entry.
        /// </summary>
        /// <param name="diaryDto">model</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]DiaryDTO diaryDto)
        {
            var userId = _identityService.GetUserIdByNameAsync(User.Identity.Name).ToString();

            await _diaryService.CreateNewEntry(diaryDto, "433e1e16-f773-4bbe-9bc1-334c2a9ad54a");
            
            _logger.LogInformation($"{userId} add new entry");
            
            return Ok();
        }
    }
}
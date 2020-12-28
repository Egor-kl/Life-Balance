using System;
using System.Threading.Tasks;
using Life_Balance.BLL.Interfaces;
using Life_Balance.BLL.ModelsDTO;
using Life_Balance.Common.Interfaces;
using Life_Balance.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Life_Balance.WebApp.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiaryController : Controller
    {
        private readonly IDiaryService _diaryService;
        private readonly IRepository<Diary> _diaryRepository;
        private readonly ILogger _logger;

        public DiaryController(IDiaryService diaryService,
                               IRepository<Diary> diaryRepository, 
                               ILogger<DiaryController> logger)
        {
            _diaryRepository = diaryRepository ?? throw new ArgumentNullException(nameof(diaryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _diaryService = diaryService ?? throw new ArgumentNullException(nameof(diaryService));
        }

        /// <summary>
        /// Get diary by date
        /// </summary>
        /// <param name="dateTime">date of entry</param>
        /// <returns>json result</returns>
        public async Task<IActionResult> GetByDate(DateTime dateTime)
        {
           var diary = await _diaryService.GetEntryByDate(dateTime);
           
           _logger.LogInformation($"Successfully sent diary with date: {diary.Date}.");
           
           return Json(diary);
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
            
            _logger.LogInformation($"Successfully sent diary with Id: {diary.Id}.");
           
            return Json(diary);
        }

        /// <summary>
        /// Get all diary
        /// </summary>
        /// <returns>json result</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var diaries = await _diaryRepository.GetAll().ToListAsync();

            _logger.LogInformation($"Successfully sent diary all diary: {diaries.Count}.");
           
            return Json(diaries);
        }

        /// <summary>
        /// Delete by id.
        /// </summary>
        /// <param name="id">Diary id.</param>
        /// <returns>No content</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            await _diaryService.DeleteEntry(id);
            
            return NoContent();
        }

        /// <summary>
        /// Update entry
        /// </summary>
        /// <param name="title">Diary title</param>
        /// <param name="entries">Diary entry</param>
        /// <param name="userId">user id</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(string title, string entries, string userId)
        {
            await _diaryService.UpdateEntry(title, entries, userId);

            return Ok();
        }

        /// <summary>
        /// Create new entry.
        /// </summary>
        /// <param name="title">diary title.</param>
        /// <param name="entry">diary entry.</param>
        /// <param name="userId">user id.</param>
        /// <returns>Ok</returns>
        [HttpPost]
        public async Task<IActionResult> Create(string title, string entry, string userId)
        {
            await _diaryService.CreateNewEntry(title, entry, userId);

            return Ok();
        }
    }
}
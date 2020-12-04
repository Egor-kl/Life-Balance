using System;
using System.Threading.Tasks;
using Life_Balance.BLL.Interfaces;
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

        public DiaryController(IDiaryService diaryService,IRepository<Diary> diaryRepository, ILogger logger)
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
        [HttpGet]
        public async Task<IActionResult> GetByDate([FromQuery] DateTime dateTime)
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
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var diary = await _diaryService.GetEntryById(id);
            
            _logger.LogInformation($"Successfully sent diary with Id: {diary.Date}.");
           
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
    }
}
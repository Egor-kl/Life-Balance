using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Life_Balance.BLL.Interfaces;
using Life_Balance.BLL.ModelsDTO;
using Life_Balance.Common.Interfaces;
using Life_Balance.DAL.Models;
using Life_Balance.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Life_Balance.WebApp.Controllers.API
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DiaryController : ControllerBase
    {
        private readonly IDiaryService _diaryService;
        private readonly IRepository<Diary> _diaryRepository;

        public DiaryController(IDiaryService diaryService,IRepository<Diary> diaryRepository)
        {
            _diaryRepository = diaryRepository ?? throw new ArgumentNullException(nameof(diaryRepository));
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
           var x = await _diaryService.GetEntryByDate(dateTime);
           return Ok(x);

        }

        /// <summary>
        /// Get diary by id
        /// </summary>
        /// <param name="id">diary id.</param>
        /// <returns>json result</returns>
        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var x = await _diaryService.GetEntryById(id);
            return Ok(x);
        }

        /// <summary>
        /// Get all diary
        /// </summary>
        /// <returns>json result</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var diaries = await _diaryRepository.GetAll().ToListAsync();

            return Ok(diaries);
        }
    }
}
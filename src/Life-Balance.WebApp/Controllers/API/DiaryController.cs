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
        private readonly IMapper _mapper;

        public DiaryController(IDiaryService diaryService,IRepository<Diary> diaryRepository, IMapper mapper)
        {
            _diaryRepository = diaryRepository ?? throw new ArgumentNullException(nameof(diaryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _diaryService = diaryService ?? throw new ArgumentNullException(nameof(diaryService));
        }
        
        /// <summary>
        /// Add new entry
        /// </summary>
        /// <param name="model">Diary view model</param>
        /// <returns></returns>
        [HttpPost]
        public async Task AddNewEntry(DiaryEntryViewModel model)
        {
            var userId = User.Claims.FirstOrDefault(claim => claim.Type.Contains("nameidentifier")).Value;
            await _diaryService.CreateNewEntry(model.Title, model.Entry, model.Date, userId);
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

        /// <summary>
        /// Delete by id
        /// </summary>
        /// <param name="id">entry id</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task DeleteEntry(int id)
        {
            await _diaryService.DeleteEntry(id);
        }

        /// <summary>
        /// Edit entry
        /// </summary>
        /// <param name="title">title</param>
        /// <param name="description">entries</param>
        /// <param name="dateTime">date</param>
        /// <returns></returns>
        [HttpPut]
        public async Task EditEntry([FromBody] string title, string description, DateTime dateTime)
        {
            await _diaryService.UpdateEntry(title, description, dateTime);
        }
    }
}
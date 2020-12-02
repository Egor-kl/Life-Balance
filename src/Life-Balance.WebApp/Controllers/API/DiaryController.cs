using System;
using System.Threading.Tasks;
using AutoMapper;
using Life_Balance.BLL.Interfaces;
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
        
        [HttpPost]
        public async Task AddNewEntry(DiaryEntryViewModel model)
        {
            await _diaryService.CreateNewEntry(model.Title, model.Entry, model.Date);
        }

        [HttpGet]
        public async Task<IActionResult> GetByDate([FromBody] DateTime dateTime)
        {
           var x = await _diaryService.GetEntryByDate(dateTime);
           return Ok(x);

        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var x = await _diaryService.GetEntryById(id);
            return Ok(x);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var diaries = await _diaryRepository.GetAll().ToListAsync();

            return Ok(diaries);
        }
    }
}
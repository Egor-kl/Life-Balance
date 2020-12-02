using System;
using System.Threading.Tasks;
using AutoMapper;
using Life_Balance.BLL.Interfaces;
using Life_Balance.Common.Interfaces;
using Life_Balance.DAL.Models;
using Life_Balance.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Life_Balance.WebApp.Controllers.API
{
    [Route("api/[controller]")]
    public class DiaryController : Controller
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
        public async Task AddNewEntry([FromBody] DiaryEntryViewModel model)
        {
            await _diaryService.CreateNewEntry(model.Title, model.Entry, model.Date);
        }
    }
}
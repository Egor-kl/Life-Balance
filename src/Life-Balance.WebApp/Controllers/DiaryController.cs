using System;
using System.Threading.Tasks;
using AutoMapper;
using Life_Balance.BLL.Interfaces;
using Life_Balance.BLL.Models;
using Life_Balance.BLL.ModelsDTO;
using Life_Balance.Common.Interfaces;
using Life_Balance.DAL.Models;
using Life_Balance.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Life_Balance.WebApp.Controllers
{
    public class DiaryController : Controller
    {
        private readonly IDiaryService _diaryService;
        private readonly IRepository<Diary> _diaryRepository;
        private readonly IMapper _mapper;

        public DiaryController(IDiaryService diaryService,IRepository<Diary> diaryRepository, IMapper mapper, IEmailService email)
        {
            _diaryRepository = diaryRepository ?? throw new ArgumentNullException(nameof(diaryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _diaryService = diaryService ?? throw new ArgumentNullException(nameof(diaryService));
        }
        
        public IActionResult Index()
        {
            return View();
        }
        
        /// <summary>
        /// For new diary entry
        /// </summary>
        /// <returns>View page</returns>
        public IActionResult DiaryEntry()
        {
            return View();
        }
        
        /// <summary>
        /// For new diary entry
        /// </summary>
        /// <param name="model">Diary ViewModel</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DiaryEntry(DiaryEntryViewModel model)
        {
            if(ModelState.IsValid)
            {
                var diaryDto = new DiaryDTO { Title = model.Title, Date = model.Date, Entries = model.Entry};
                var result = _mapper.Map<Diary>(diaryDto);
                await _diaryService.CreateNewEntry(result, model.Title, model.Entry, DateTime.Now);
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var diaryDto = new DiaryDTO {Id = id};
            var result = _mapper.Map<Diary>(diaryDto);
            await _diaryService.DeleteEntry(result, id);

            return View();
        }
    }
}
using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Life_Balance.BLL.Interfaces;
using Life_Balance.Common.Interfaces;
using Life_Balance.DAL;
using Life_Balance.DAL.Models;

namespace Life_Balance.BLL.Services
{
    public class DiaryService : IDiaryService
    {
        private readonly IRepository<Diary> _diaryRepository;
        private readonly IMapper _mapper; 

        public DiaryService(IRepository<Diary> diaryRepository, IMapper mapper)
        {
            _diaryRepository = diaryRepository ?? throw new ArgumentNullException();
            _mapper = mapper ?? throw new ArgumentNullException();
        }

        public Task<Diary> GetEntryByDate(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public Task CreateNewEntry(string title, string description, DateTime dateTime)
        {
            throw new NotImplementedException();
        }
    }
}
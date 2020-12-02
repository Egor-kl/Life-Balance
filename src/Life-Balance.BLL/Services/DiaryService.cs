using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Life_Balance.BLL.Interfaces;
using Life_Balance.BLL.ModelsDTO;
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
            return _diaryRepository.GetEntityAsync(x => x.Date == dateTime);
        }

        public async Task CreateNewEntry(string title, string description, DateTime dateTime)
        {
            var diaryDto = new DiaryDTO();
            var entry = _mapper.Map<Diary>(diaryDto);
            await _diaryRepository.AddAsync(entry);
            await _diaryRepository.SaveChangesAsync();
        }

        public async Task DeleteEntry(int entryId)
        {
            var entry = new Diary() {Id = entryId};
            _diaryRepository.Delete(entry);
            await _diaryRepository.SaveChangesAsync();
        }
    }
}
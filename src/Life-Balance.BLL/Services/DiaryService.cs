using System;
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

        /// <inheritdoc />
        public async Task GetEntryByDate(Diary diary, DateTime dateTime)
        {
            var dataDiary = _mapper.Map<Diary>(diary);
            dataDiary.Date = dateTime;
            await _diaryRepository.AddAsync(dataDiary);
            await _diaryRepository.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task CreateNewEntry(Diary diary, string title, string entries, DateTime dateTime)
        {
            var dataDiary = _mapper.Map<Diary>(diary);
            dataDiary.Title = title;
            dataDiary.Entries = entries;
            dataDiary.Date = dateTime;
            await _diaryRepository.AddAsync(dataDiary);
            await _diaryRepository.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task DeleteEntry(Diary diary, int entryId)
        {
            var dataDiary = _mapper.Map<Diary>(diary);
            dataDiary.Id = entryId;
            _diaryRepository.Delete(dataDiary);
            await _diaryRepository.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task UpdateEntry(Diary diary, string title, string entries)
        {
            var dataDiary = _mapper.Map<Diary>(diary);
            dataDiary.Title = title;
            dataDiary.Entries = entries;
            await _diaryRepository.AddAsync(dataDiary);
            await _diaryRepository.SaveChangesAsync();
        }
    }
}
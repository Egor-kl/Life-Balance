using System;
using System.Threading.Tasks;
using AutoMapper;
using Life_Balance.BLL.Interfaces;
using Life_Balance.BLL.ModelsDTO;
using Life_Balance.Common.Interfaces;
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

        /// <summary>
        /// Get entry by date
        /// </summary>
        /// <param name="dateTime">date of diary</param>
        /// <returns></returns>
        public Task<Diary> GetEntryByDate(DateTime dateTime)
        {
            return _diaryRepository.GetEntityAsync(x => x.Date == dateTime);
        }

        /// <summary>
        /// Get entry by id
        /// </summary>
        /// <param name="id">id entry</param>
        /// <returns></returns>
        public Task<Diary> GetEntryById(int id)
        {
            return _diaryRepository.GetEntityAsync(x => x.Id == id);
        }

        /// <summary>
        /// Add new entry
        /// </summary>
        /// <param name="title">title of entry</param>
        /// <param name="description">description of entry</param>
        /// <param name="dateTime">date of entry</param>
        /// <param name="userId">user id</param>
        /// <returns></returns>
        public async Task CreateNewEntry(string title, string description, DateTime dateTime, string userId)
        {
            var diaryDto = new DiaryDTO() {Title = title, Entries = description};
            var entry = _mapper.Map<Diary>(diaryDto);
            entry.UserId = userId;
            await _diaryRepository.AddAsync(entry);
            await _diaryRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Delete by id
        /// </summary>
        /// <param name="entryId">entry id</param>
        /// <returns></returns>
        public async Task DeleteEntry(int entryId)
        {
            var entry = new Diary() {Id = entryId};
            _diaryRepository.Delete(entry);
            await _diaryRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Edit entry
        /// </summary>
        /// <param name="diary"></param>
        /// <returns></returns>
        public async Task UpdateEntry(DiaryDTO diary)
        {
            var entry = new Diary() {Title = diary.Title, Entries = diary.Entries, UserId = diary.UserId, Id = diary.Id};
            _diaryRepository.Update(entry);
            await _diaryRepository.SaveChangesAsync();
        }
    }
}
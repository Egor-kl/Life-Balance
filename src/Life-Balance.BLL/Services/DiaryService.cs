using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Life_Balance.BLL.Interfaces;
using Life_Balance.BLL.ModelsDTO;
using Life_Balance.Common.Interfaces;
using Life_Balance.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Life_Balance.BLL.Services
{
    public class DiaryService : IDiaryService
    {
        private readonly IRepository<Diary> _diaryRepository;
        private readonly IProfileService _profileService;
        private readonly IMapper _mapper; 

        public DiaryService(IRepository<Diary> diaryRepository, IMapper mapper, IProfileService profileService)
        {
            _diaryRepository = diaryRepository ?? throw new ArgumentNullException();
            _mapper = mapper ?? throw new ArgumentNullException();
            _profileService = profileService ?? throw new ArgumentNullException();
        }

        /// <inheritdoc />
        public Task<Diary> GetEntryByDate(DateTime dateTime)
        {
            return _diaryRepository.GetEntityAsync(x => x.Date == dateTime);
        }

        /// <inheritdoc />
        public Task<Diary> GetEntryById(int id)
        {
            return _diaryRepository.GetEntityAsync(x => x.Id == id);
        }

        /// <inheritdoc />
        public async Task CreateNewEntry(DiaryDTO diaryDto, string userId)
        {
            var entry = _mapper.Map<Diary>(diaryDto);
            var profile = await _profileService.GetProfileIdByUserId(userId);
            entry.UserId = userId;
            
            if (profile != null)
                entry.ProfileId = profile.Id.ToString();
            
            await _diaryRepository.AddAsync(entry);
            await _diaryRepository.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task DeleteEntry(int entryId)
        {
            var entry = new Diary() {Id = entryId};
            _diaryRepository.Delete(entry);
            await _diaryRepository.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task UpdateEntry(DiaryDTO diary)
        {
            var entry = new Diary() {Title = diary.Title, Entries = diary.Entries, UserId = diary.UserId, Id = diary.Id, Date = DateTime.Now};
            _diaryRepository.Update(entry);
            await _diaryRepository.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task<Diary> GetDiaryByUserId(string userId)
        { 
            var diary = await _diaryRepository.GetEntityAsync(x => x.UserId == userId);

            return diary;
        }

        /// <inheritdoc />
        public async Task<List<Diary>> GetAll()
        {
            var diaries = await _diaryRepository.GetAll().ToListAsync();

            return diaries;
        }
    }
}
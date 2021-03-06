using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Life_Balance.BLL.Interfaces;
using Life_Balance.BLL.ModelsDTO;
using Life_Balance.Common.Interfaces;
using Life_Balance.DAL;
using Life_Balance.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Profile = Life_Balance.DAL.Models.Profile;

namespace Life_Balance.BLL.Services
{
    public class ProfileService : IProfileService
    {
        private readonly LifeBalanceDbContext _db;
        private readonly IMapper _mapper;
        private readonly IRepository<Profile> _profileRepository;

        public ProfileService(LifeBalanceDbContext db, IMapper mapper, IRepository<Profile> profileRepository)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _profileRepository = profileRepository ?? throw new ArgumentNullException(nameof(profileRepository));
        }
        
        /// <inheritdoc />
        public async Task AddNewProfile(string userName, string userId)
        {
            var profile = new Profile() {UserName = userName, UserId = userId};
            await _profileRepository.AddAsync(profile);
            await _profileRepository.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task UpdateProfile(string userName, byte[] avatar)
        {
            var profile = new Profile() {UserName = userName, Avatar = avatar};
            _profileRepository.Update(profile);
            await _profileRepository.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task<List<EventDTO>> GetAllEventByUserId(string userId)
        {
            var listEvent = await _db.Events.Where(a => a.UserId == userId).ToListAsync();

            var events = _mapper.Map<List<EventDTO>>(listEvent);
            return events;
        }

        /// <inheritdoc/>
        public async Task<List<ToDoDTO>> GetAllTaskByUserId(string userId)
        {
            var listTask = await _db.ToDos.Where(a => a.UserId == userId).ToListAsync();

            var tasks = _mapper.Map<List<ToDoDTO>>(listTask);
            return tasks;
        }

        /// <inheritdoc />
        public async Task<Profile> GetProfileIdByUserId(string userId)
        {
            var profile = await _db.Profiles.FirstOrDefaultAsync(a => a.UserId == userId);
            
            return profile;
        }

        /// <inheritdoc />
        public async Task<List<DiaryDTO>> GetAllDiaryByUserId(string id)
        {
            var diary = await _db.Diary.Where(a => a.UserId == id).ToListAsync();

            var diaries = _mapper.Map<List<DiaryDTO>>(diary);
            return diaries;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Life_Balance.BLL.Interfaces;
using Life_Balance.BLL.ModelsDTO;
using Life_Balance.Common.Interfaces;
using Life_Balance.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Life_Balance.BLL.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IRepository<ToDo> _toDoRepository;
        private readonly IMapper _mapper;
        private readonly IProfileService _profileService;

        public ToDoService(IRepository<ToDo> toDoRepository, IMapper mapper, IProfileService profileService)
        {
            _toDoRepository = toDoRepository ?? throw new ArgumentNullException(nameof(toDoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _profileService = profileService ?? throw new ArgumentNullException(nameof(profileService));
        }
        
        /// <inheritdoc />
        public async Task AddNewTask(ToDoDTO toDoDto, string userId)
        {
            var todo = _mapper.Map<ToDo>(toDoDto);
            var profile = await _profileService.GetProfileIdByUserId(userId);
            todo.UserId = userId;
            
            if (profile != null)
                todo.ProfileId = profile.Id.ToString();
            
            await _toDoRepository.AddAsync(todo);
            await _toDoRepository.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task UpdateTask(ToDoDTO toDoDto)
        {
            var update = _mapper.Map<ToDo>(toDoDto);
            _toDoRepository.Update(update);
            await _toDoRepository.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task DeleteTask(int id)
        {
            var todo = new ToDo() {Id = id};
            _toDoRepository.Delete(todo);
            await _toDoRepository.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task<List<ToDo>> GetAllTask()
        {
            return await _toDoRepository.GetAll().ToListAsync();
        }

        /// <inheritdoc />
        public async Task<List<ToDo>> GetCompleteTask()
        {
            return await _toDoRepository.GetAll().Where(a => a.IsComplete == true).ToListAsync();
        }
        
        /// <inheritdoc />
        public async Task<List<ToDo>> GetUncompletedTask()
        {
            return await _toDoRepository.GetAll().Where(a => a.IsComplete == false).ToListAsync();
        }

        /// <inheritdoc />
        public Task<ToDo> GetById(int id)
        {
            return _toDoRepository.GetEntityAsync(a => a.Id == id);
        }
    }
}
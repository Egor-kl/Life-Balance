using Life_Balance.BLL.Interfaces;
using Life_Balance.BLL.ModelsDTO;
using Life_Balance.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Life_Balance.DAL.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Life_Balance.BLL.Services
{
    public class EventService : IEventService
    {
        private readonly IRepository<Event> _eventRepository;
        private readonly IMapper _mapper;

        public EventService(IRepository<Event> eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <inheritdoc />
        public async Task Create(EventDTO events, string userId)
        {
            var newEvent = _mapper.Map<Event>(events);
            newEvent.UserId = userId;
            await _eventRepository.AddAsync(newEvent);
            await _eventRepository.SaveChangesAsync();
        }

        /// <inheritdoc />
        public Task<Event> GetById(int id)
        {
            return _eventRepository.GetEntityAsync(e => e.Id == id);
        }

        /// <inheritdoc />
        public async Task<List<Event>> GetAll()
        {
           return await _eventRepository.GetAll().ToListAsync();
        }

        /// <inheritdoc />
        public async Task DeleteEvent(int id)
        {
            var events = new Event(){Id = id};
            _eventRepository.Delete(events);
            await _eventRepository.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task UpdateEvent(EventDTO eventDto)
        {
            var update = _mapper.Map<Event>(eventDto);
            _eventRepository.Update(update);
            await _eventRepository.SaveChangesAsync();
        }

        /// <inheritdoc />
        public Task<Event> GetEventByUserId(string userId)
        {
            var events = _eventRepository.GetEntityAsync(x => x.UserId == userId);

            return events;
        }
    }
}

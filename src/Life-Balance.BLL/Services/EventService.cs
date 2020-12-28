using Life_Balance.BLL.Interfaces;
using Life_Balance.BLL.ModelsDTO;
using Life_Balance.Common.Interfaces;
using System;
using System.Threading.Tasks;
using Life_Balance.DAL.Models;
using AutoMapper;

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
        public async Task Create(string title, string note, string start, string end, string userId)
        {
            var eventDto = new EventDTO(){Title = title, Note = note, Start = start, End = end};
            var events = _mapper.Map<Event>(eventDto);
            await _eventRepository.AddAsync(events);
            await _eventRepository.SaveChangesAsync();
        }
        
        /// <inheritdoc />
        public async Task UpdateEvent(string title, string note, string start, string end, string userId)
        {
            var eventDto = new EventDTO() {Title = title, Note = note, Start = start, End = end};
            var events = _mapper.Map<Event>(eventDto);
            _eventRepository.Update(events);
            await _eventRepository.SaveChangesAsync();
        }

        /// <inheritdoc />
        public Task<Event> GetById(int id)
        {
            return _eventRepository.GetEntityAsync(e => e.Id == id);
        }

        /// <inheritdoc />
        public async Task DeleteEvent(int id)
        {
            var events = new Event(){Id = id};
            _eventRepository.Delete(events);
            await _eventRepository.SaveChangesAsync();
        }
    }
}

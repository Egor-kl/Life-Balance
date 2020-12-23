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
        public async Task Create(EventDTO events, string userId)
        {
            var newEvent = _mapper.Map<Event>(events);
            newEvent.UserId = userId;
            await _eventRepository.AddAsync(newEvent);
            await _eventRepository.SaveChangesAsync();
        }
    }
}

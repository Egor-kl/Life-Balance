using System;
using System.Threading.Tasks;
using AutoMapper;
using Life_Balance.BLL.Interfaces;
using Life_Balance.BLL.ModelsDTO;
using Life_Balance.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Life_Balance.WebApp.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalendarController : Controller
    {
        private readonly IEventService _eventService;
        private readonly ILogger _logger;
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public CalendarController(IEventService eventService,
                               ILogger<CalendarController> logger,
                               IIdentityService identityService,
                               IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _eventService = eventService ?? throw new ArgumentNullException(nameof(eventService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Add new event.
        /// </summary>
        /// <param name="model">Event view model.</param>
        /// <returns>View</returns>
        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody]EventViewModel model)
        {
            var userId = await _identityService.GetUserIdByNameAsync(User.Identity.Name);

            var events = _mapper.Map<EventDTO>(model);
            await _eventService.Create(events, userId);
            
            return Json(events);
        }

        /// <summary>
        /// Get event by id.
        /// </summary>
        /// <param name="id">event id</param>
        /// <returns></returns>
        public async Task<IActionResult> GetEventById(int id)
        {
            var evenTask = await _eventService.GetById(id);

            return Json(evenTask);
        }

        /// <summary>
        /// Delete event by id.
        /// </summary>
        /// <param name="id">event id</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            await _eventService.DeleteEvent(id);
            return Ok();
        }

        /// <summary>
        /// Update event.
        /// </summary>
        /// <param name="model">View model.</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateEvent(EventViewModel model)
        {
            var eventDto = new EventDTO()
            {
                Title = model.Title,
                Note = model.Note,
                Start = model.Start,
                End = model.End
            };
            
            await _eventService.UpdateEvent(eventDto);
            return NoContent();
        }
    }
}

using System;
using System.Threading.Tasks;
using Life_Balance.BLL.Interfaces;
using Life_Balance.BLL.ModelsDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Life_Balance.WebApp.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalendarController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly ILogger _logger;
        private readonly IIdentityService _identityService;

        public CalendarController(IEventService eventService,
                               ILogger<CalendarController> logger,
                               IIdentityService identityService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _eventService = eventService ?? throw new ArgumentNullException(nameof(eventService));
        }

        /// <summary>
        /// Get all event.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _eventService.GetAll();
            
            _logger.LogInformation("Successfully sent all event.");

            return Ok(events);
        }

        /// <summary>
        /// Get event by id.
        /// </summary>
        /// <param name="id">event id.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var events = await _eventService.GetById(id);
            
            _logger.LogInformation($"Successfully sent event with id = {id}.");

            return Ok(events);
        }

        /// <summary>
        /// Delete event by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            await _eventService.DeleteEvent(id);
            
            _logger.LogInformation($"Successfully delete event with id = {id}.");

            return Ok();
        }
        
        /// <summary>
        /// Update event.
        /// </summary>
        /// <param name="eventDto">model</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]EventDTO eventDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _eventService.UpdateEvent(eventDto);
            
            _logger.LogInformation($"User modified event.");

            return Ok();
        }

        /// <summary>
        /// Create event.
        /// </summary>
        /// <param name="eventDto">model</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]EventDTO eventDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var userId = _identityService.GetUserIdByNameAsync(User.Identity.Name).ToString();

            await _eventService.Create(eventDto, userId);
            
            _logger.LogInformation($"{userId} add new event");
            
            return Ok();
        }
    }
}

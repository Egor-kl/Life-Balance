using AutoMapper;
using Life_Balance.BLL.Interfaces;
using Life_Balance.BLL.ModelsDTO;
using Life_Balance.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Life_Balance.WebApp.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly ILogger _logger;
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public EventController(IEventService eventService,
                               ILogger<EventController> logger,
                               IIdentityService identityService,
                               IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _eventService = eventService ?? throw new ArgumentNullException(nameof(eventService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// View form for create new event.
        /// </summary>
        /// <returns>View model</returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Add new event.
        /// </summary>
        /// <param name="model">Event view model.</param>
        /// <returns>View</returns>
        [HttpPost]
        public async Task<IActionResult> Create(EventViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = await _identityService.GetUserIdByNameAsync(User.Identity.Name);

                    var events = _mapper.Map<EventDTO>(model);
                    await _eventService.Create(events, userId);

                    _logger.LogInformation($"{User.Identity.Name} add new event");
                    RedirectToAction("Index", "Profile");
                }
                catch (ArgumentException ex)
                {
                    _logger.LogError($"Event model is not valid {ex.Message}");
                }
            }

            return View(model);
        }
    }
}

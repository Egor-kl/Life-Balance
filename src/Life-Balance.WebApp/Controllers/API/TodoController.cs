using System;
using System.Threading.Tasks;
using Life_Balance.BLL.Interfaces;
using Life_Balance.BLL.ModelsDTO;
using Life_Balance.Common.Interfaces;
using Life_Balance.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Life_Balance.WebApp.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IToDoService _toDoService;
        private readonly IRepository<ToDo> _toDoRepository;
        private readonly ILogger _logger;
        private readonly IIdentityService _identityService;
        private readonly IProfileService _profileService;

        public TodoController(IToDoService toDoService,
                             IRepository<ToDo> toDoRepository, 
                             ILogger<TodoController> logger,
                             IIdentityService identityService,
                             IProfileService profileService)
        {
            _toDoRepository = toDoRepository ?? throw new ArgumentNullException(nameof(toDoRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _toDoService = toDoService ?? throw new ArgumentNullException(nameof(toDoService));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _profileService = profileService ?? throw new ArgumentNullException(nameof(profileService));
        }
        
        /// <summary>
        /// Get task by id
        /// </summary>
        /// <param name="id">diary id.</param>
        /// <returns>json result</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _toDoService.GetById(id);
            
            _logger.LogInformation($"Successfully sent task with Id: {task.Id}.");
           
            return Ok(task);
        }

        /// <summary>
        /// Get all Task
        /// </summary>
        /// <returns>json result</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var todo = await _toDoService.GetAllTask();

            _logger.LogInformation($"Successfully sent all task: {todo.Count}.");
           
            return Ok(todo);
        }

        /// <summary>
        /// Get all completed task.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Completed")]
        public async Task<IActionResult> GetCompleteTask()
        {
            var task = await _toDoService.GetCompleteTask();
            
            _logger.LogInformation($"Successfully sent all task: {task.Count}.");
            
            return Ok(task);
        }
        
        /// <summary>
        /// Get all uncompleted task.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Uncompleted")]
        public async Task<IActionResult> GetUnCompleteTask()
        {
            var task = await _toDoService.GetUncompletedTask();
            
            _logger.LogInformation($"Successfully sent all task: {task.Count}.");
            
            return Ok(task);
        }

        /// <summary>
        /// Delete by id.
        /// </summary>
        /// <param name="id">Task id.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            await _toDoService.DeleteTask(id);
            
            return NoContent();
        }

        /// <summary>
        /// Update task.
        /// </summary>
        /// <param name="toDoDto">model</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]ToDoDTO toDoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _toDoService.UpdateTask(toDoDto);
            
            _logger.LogInformation($"ToDo has been update");

            return Ok();
        }

        /// <summary>
        /// Create new task.
        /// </summary>
        /// <param name="toDoDto">model</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ToDoDTO toDoDto)
        {
            var userId = _identityService.GetUserIdByNameAsync(User.Identity.Name).ToString();
            
            await _toDoService.AddNewTask(toDoDto, "userid"); // userid replace later
            
            return Ok();
        }
    }
}
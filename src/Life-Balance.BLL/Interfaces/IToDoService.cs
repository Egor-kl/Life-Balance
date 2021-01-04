using System.Collections.Generic;
using System.Threading.Tasks;
using Life_Balance.BLL.ModelsDTO;
using Life_Balance.DAL.Models;

namespace Life_Balance.BLL.Interfaces
{
    public interface IToDoService
    {
        /// <summary>
        /// Add new task.
        /// </summary>
        /// <returns></returns>
        public Task AddNewTask(ToDoDTO toDoDto, string userId);

        /// <summary>
        /// Update task.
        /// </summary>
        /// <param name="toDoDto">dto model.</param>
        /// <returns></returns>
        public Task UpdateTask(ToDoDTO toDoDto);

        /// <summary>
        /// Delete task by Id.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns></returns>
        public Task DeleteTask(int id);

        /// <summary>
        /// Get all task.
        /// </summary>
        /// <returns></returns>
        public Task GetAllTask();

        /// <summary>
        /// Get complete task.
        /// </summary>
        /// <returns></returns>
        public Task GetCompleteTask();

        /// <summary>
        /// Get uncompleted task
        /// </summary>
        /// <returns></returns>
        public Task GetUncompletedTask();
    }
}
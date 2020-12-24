using Life_Balance.BLL.ModelsDTO;
using System.Threading.Tasks;
using Life_Balance.DAL.Models;

namespace Life_Balance.BLL.Interfaces
{
    public interface IEventService
    {
        /// <summary>
        /// Create new event
        /// </summary>
        /// <param name="events">Event DTO</param>
        /// <param name="userId">User Id.</param>
        /// <returns></returns>
        public Task Create(EventDTO events, string userId);

        /// <summary>
        /// Get event by id.
        /// </summary>
        /// <param name="id">event id</param>
        /// <returns></returns>
        public Task<Event> GetById(int id);

        /// <summary>
        /// Delete eveny by id.
        /// </summary>
        /// <param name="id">Event id.</param>
        /// <returns></returns>
        public Task DeleteEvent(int id);

        /// <summary>
        /// Update event.
        /// </summary>
        /// <param name="eventDto">Event dto model.</param>
        /// <returns></returns>
        public Task UpdateEvent(EventDTO eventDto);
    }
}

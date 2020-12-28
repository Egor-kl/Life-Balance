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
        /// <param name="title">Event title</param>
        /// <param name="note">Event note</param>
        /// <param name="start">Start event</param>
        /// <param name="end">End event</param>
        /// <param name="userId">user id</param>
        /// <returns></returns>
        public Task Create(string title, string note, string start, string end, string userId);

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
        /// Update entry.
        /// </summary>
        /// <param name="title">Event title</param>
        /// <param name="note">Event note</param>
        /// <param name="start">Start event</param>
        /// <param name="end">End event</param>
        /// <param name="userId">user id</param>
        /// <returns></returns>
        public Task UpdateEvent(string title, string note, string start, string end, string userId);
    }
}

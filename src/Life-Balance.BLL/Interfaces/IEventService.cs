using Life_Balance.BLL.ModelsDTO;
using System.Threading.Tasks;

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
    }
}

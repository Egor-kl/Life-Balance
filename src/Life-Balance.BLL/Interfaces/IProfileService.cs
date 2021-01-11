using System.Collections.Generic;
using System.Threading.Tasks;
using Life_Balance.BLL.ModelsDTO;
using Life_Balance.DAL.Models;

namespace Life_Balance.BLL.Interfaces
{
    /// <summary>
    /// Profile interface.
    /// </summary>
    public interface IProfileService
    {
        /// <summary>
        /// Get profile diary.
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns></returns>
        public Task<List<DiaryDTO>> GetAllDiaryByUserId(string id);
        
        /// <summary>
        /// Get event by user id
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns></returns>
        public Task<List<EventDTO>> GetAllEventByUserId(string userId);

        /// <summary>
        /// Get all task by user id.
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns></returns>
        public Task<List<ToDoDTO>> GetAllTaskByUserId(string userId);

        /// <summary>
        /// Add new profile
        /// </summary>
        /// <param name="userName">username</param>
        /// <param name="userId">user id</param>
        /// <returns></returns>
        public Task AddNewProfile(string userName, string userId);

        /// <summary>
        /// Update profile.
        /// </summary>
        /// <param name="userName">User Name</param>
        /// <param name="avatar">Avatar</param>
        /// <returns></returns>
        public Task UpdateProfile(string userName, byte[] avatar);

        /// <summary>
        /// Get profile id by user id.
        /// </summary>
        /// <param name="userId">user id.</param>
        /// <returns></returns>
        public Task<Profile> GetProfileIdByUserId(string userId);
    }
}

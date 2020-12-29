using System;
using System.Threading.Tasks;
using Life_Balance.BLL.ModelsDTO;
using Life_Balance.DAL.Models;

namespace Life_Balance.BLL.Interfaces
{
    /// <summary>
    /// Diary interface.
    /// </summary>
    public interface IDiaryService
    {
        /// <summary>
        /// Get by date
        /// </summary>
        /// <param name="dateTime">date</param>
        /// <returns></returns>
        public Task<Diary> GetEntryByDate(DateTime dateTime);
        
        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id">entry id</param>
        /// <returns></returns>
        public Task<Diary> GetEntryById(int id);

        /// <summary>
        /// Add new diary entry
        /// </summary>
        /// <param name="diaryDto">diaryDto model.</param>
        /// /// <param name="userId">User id.</param>
        /// <returns></returns>
        public Task CreateNewEntry(DiaryDTO diaryDto, string userId);

        /// <summary>
        /// Delete entry by id;
        /// </summary>
        /// <param name="entryId">entry id</param>
        /// <returns></returns>
        public Task DeleteEntry(int entryId);

        /// <summary>
        /// Update entry
        /// </summary>
        /// <param name="diaryDto"></param>
        /// <returns></returns>
        public Task UpdateEntry(DiaryDTO diaryDto);

        /// <summary>
        /// Get diary by user id.
        /// </summary>
        /// <returns></returns>
        public Task<Diary> GetDiaryByUserId(string userId);
    }
}
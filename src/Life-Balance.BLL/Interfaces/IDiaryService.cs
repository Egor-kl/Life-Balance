using System;
using System.Threading.Tasks;
using Life_Balance.DAL.Models;

namespace Life_Balance.BLL.Interfaces
{
    public interface IDiaryService
    {
        /// <summary>
        /// Get entry by date.
        /// </summary>
        /// <param name="diary">Db Diary</param>
        /// <param name="dateTime">Date for search.</param>
        /// <returns></returns>
        public Task GetEntryByDate(Diary diary, DateTime dateTime);

        /// <summary>
        /// Create new entry.
        /// </summary>
        /// <param name="diary">Diary db</param>
        /// <param name="title">Title entry.</param>
        /// <param name="entries">Notes</param>
        /// <param name="dateTime">Date</param>
        /// <returns></returns>
        public Task CreateNewEntry(Diary diary, string title, string entries, DateTime dateTime);

        /// <summary>
        /// Delete by id.
        /// </summary>
        /// <param name="diary">Diary db</param>
        /// <param name="entryId">Id entry.</param>
        /// <returns></returns>
        public Task DeleteEntry(Diary diary, string entryId);

        /// <summary>
        /// Update entry.
        /// </summary>
        /// <param name="diary">Diary db</param>
        /// <param name="title"></param>
        /// <param name="entries"></param>
        /// <returns></returns>
        public Task UpdateEntry(Diary diary, string title, string entries);
    }
}
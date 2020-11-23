using System;
using System.Threading.Tasks;

namespace Life_Balance.BLL.Interfaces
{
    public interface IDiaryService
    {
        /// <summary>
        /// Get entry by date.
        /// </summary>
        /// <param name="dateTime">Date for search.</param>
        /// <returns></returns>
        public Task GetEntryByDate(DateTime dateTime);

        /// <summary>
        /// Create new entry.
        /// </summary>
        /// <param name="title">Title entry.</param>
        /// <param name="entries">Notes</param>
        /// <param name="dateTime">Date</param>
        /// <returns></returns>
        public Task CreateNewEntry(string title, string entries, DateTime dateTime);

        /// <summary>
        /// Delete by id.
        /// </summary>
        /// <param name="entryId">Id entry.</param>
        /// <returns></returns>
        public Task DeleteEntry(string entryId);

        /// <summary>
        /// Update entry.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="entries"></param>
        /// <returns></returns>
        public Task UpdateEntry(string title, string entries);
    }
}
using System;
using System.Threading.Tasks;
using Life_Balance.DAL.Models;

namespace Life_Balance.BLL.Interfaces
{
    public interface IDiaryService
    {
        /// <summary>
        /// Get by date
        /// </summary>
        /// <param name="dateTime">date</param>
        /// <returns></returns>
        public Task<Diary> GetEntryByDate(DateTime dateTime);

        /// <summary>
        /// Add new entry
        /// </summary>
        /// <param name="title">title entry</param>
        /// <param name="description">description entry</param>
        /// <param name="dateTime">date</param>
        /// <returns></returns>
        public Task CreateNewEntry(string title, string description, DateTime dateTime);
    }
}
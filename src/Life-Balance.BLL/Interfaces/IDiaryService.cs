using System;
using System.Threading.Tasks;
using Life_Balance.BLL.ModelsDTO;
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
        /// Get by id
        /// </summary>
        /// <param name="id">entry id</param>
        /// <returns></returns>
        public Task<Diary> GetEntryById(int id);

        /// <summary>
        /// Add new entry
        /// </summary>
        /// <param name="title">title entry</param>
        /// <param name="description">description entry</param>
        /// <param name="dateTime">date</param>
        /// <param name="userId">user id</param>
        /// <returns></returns>
        public Task CreateNewEntry(string title, string description, DateTime dateTime, string userId);

        /// <summary>
        /// Delete entry by id;
        /// </summary>
        /// <param name="entryId">entry id</param>
        /// <returns></returns>
        public Task DeleteEntry(int entryId);

        /// <summary>
        /// Edit entry
        /// </summary>
        /// <param name="title">title entry</param>
        /// <param name="description">description entry</param>
        /// <param name="dateTime">date</param>
        /// <returns></returns>
        public Task UpdateEntry(DiaryDTO diaryDto);
    }
}
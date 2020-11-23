using System;
using System.Threading.Tasks;
using Life_Balance.BLL.Interfaces;

namespace Life_Balance.BLL.Services
{
    public class DiaryService : IDiaryService
    {
        public Task GetEntryByDate(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public Task CreateNewEntry(string title, string entries, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntry(string entryId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntry(string title, string entries)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Threading.Tasks;
using Life_Balance.BLL.Interfaces;
using Life_Balance.Common.Interfaces;
using Life_Balance.DAL;
using Life_Balance.DAL.Models;

namespace Life_Balance.BLL.Services
{
    public class DiaryService : IDiaryService
    {
        private  readonly IRepository<Diary> _diaryRepository;
        private readonly LifeBalanceDbContext _dbContext;

        public DiaryService(IRepository<Diary> diaryRepository, LifeBalanceDbContext lifeBalanceDbContext)
        {
            _diaryRepository = diaryRepository ?? throw new ArgumentNullException();
            _dbContext = lifeBalanceDbContext ?? throw new ArgumentNullException();
        }
    
        public Task GetEntryByDate(Diary diary, DateTime dateTime)
        {
            
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
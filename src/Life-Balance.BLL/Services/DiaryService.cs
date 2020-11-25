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
            throw new NotImplementedException();
        }

        public Task CreateNewEntry(Diary diary, string title, string entries, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntry(Diary diary, string entryId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntry(Diary diary, string title, string entries)
        {
            throw new NotImplementedException();
        }
    }
}
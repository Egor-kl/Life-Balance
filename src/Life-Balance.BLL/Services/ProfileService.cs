using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Life_Balance.BLL.Interfaces;
using Life_Balance.BLL.ModelsDTO;
using Life_Balance.Common.Interfaces;
using Life_Balance.DAL;
using Life_Balance.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Profile = Life_Balance.DAL.Models.Profile;

namespace Life_Balance.BLL.Services
{
    public class ProfileService : IProfileService
    {
        private readonly LifeBalanceDbContext _db;
        private readonly IMapper _mapper;

        public ProfileService(LifeBalanceDbContext db, IMapper mapper)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <inheritdoc />
        public List<DiaryDTO> GetAllDiary(string userId)
        {
            var diary =  _db.Diary.Where(a => a.UserId == userId).ToListAsync();

            return  _mapper.Map<List<DiaryDTO>>(diary);
        }
    }
}
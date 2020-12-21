using Life_Balance.BLL.ModelsDTO;
using Life_Balance.DAL.Models;
using Profile = AutoMapper.Profile;

namespace Life_Balance.BLL.Mapping
{
    /// <summary>
    /// Diary Mapper.
    /// </summary>
    public class DiaryProfile : Profile
    {
        public DiaryProfile()
        {
            CreateMap<Diary, DiaryDTO>().ReverseMap();
        }
    }
}
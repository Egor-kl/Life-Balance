using AutoMapper;
using Life_Balance.BLL.ModelsDTO;

namespace Life_Balance.BLL.Mapping
{
    public class ProfileMapperProfile : Profile
    {
        public ProfileMapperProfile()
        {
            CreateMap<Profile, ProfileDTO>().ReverseMap();
        }
    }
}
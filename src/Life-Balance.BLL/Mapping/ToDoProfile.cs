using Life_Balance.BLL.ModelsDTO;
using Life_Balance.DAL.Models;
using Profile = AutoMapper.Profile;

namespace Life_Balance.BLL.Mapping
{
    public class ToDoProfile : Profile
    {
        public ToDoProfile()
        {
            CreateMap<ToDo, ToDoDTO>();
        }
    }
}
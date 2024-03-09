using AutoMapper;
using UserManagement_Data;
using UserManagement_Client.VM;

namespace Tangy_Business.Mapper
{
	public class MappingProfile : Profile
	{
        public MappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}


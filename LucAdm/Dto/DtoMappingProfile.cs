using AutoMapper;

namespace LucAdm
{
    public class DtoMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<User, UserDto>();
            Mapper.CreateMap<User, UserItemDto>();
        }
    }
}
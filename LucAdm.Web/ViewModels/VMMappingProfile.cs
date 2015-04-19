using AutoMapper;

namespace LucAdm.Web
{
    public class VmMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<User, UserVm>();
            Mapper.CreateMap<User, UserItemVm>();
        }
    }
}
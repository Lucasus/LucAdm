using AutoMapper;

namespace LucAdm.Web
{
    public class VMMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<User, UserVM>();
        }
    }
}
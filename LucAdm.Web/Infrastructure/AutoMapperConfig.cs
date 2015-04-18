using AutoMapper;

namespace LucAdm.Web
{
    public static class AutoMapperConfig
    {
        public static void Register()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile(new VmMappingProfile());
            });
        }
    }
}
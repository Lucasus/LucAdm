using AutoMapper;

namespace LucAdm.Web
{
    public class AutoMapperConfig
    {
        public static void Register()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile(new VMMappingProfile());
            });
        }
    }
}
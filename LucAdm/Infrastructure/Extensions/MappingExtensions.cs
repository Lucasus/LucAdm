using AutoMapper;

namespace LucAdm
{
	public static class MappingExtensions
	{
        public static T ToDto<T>(this object entity)
        {
            return (T)Mapper.Map(entity, entity.GetType(), typeof(T));
        }
    }
}

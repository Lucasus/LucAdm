using AutoMapper;

namespace LucAdm.Web
{
	public static class MappingExtensions
	{
        public static T ToViewModel<T>(this object entity)
        {
            return (T)Mapper.Map(entity, entity.GetType(), typeof(T));
        }

        public static TEntity ToEntity<TViewModel, TEntity>(this TViewModel viewModel, TEntity loadedEntity)
        {
            return Mapper.Map<TViewModel, TEntity>(viewModel, loadedEntity);
        }
    }
}

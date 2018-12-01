namespace Core.Services
{
    using Core.DataProvider;
    using Core.Entities;

    public class EntityService<T> : EfRepository<T>, IEntityService<T> where T : BaseEntity
    {
        public EntityService(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
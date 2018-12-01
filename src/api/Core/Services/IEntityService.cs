namespace Core.Services
{
    using Core.DataProvider;
    using Core.Entities;

    public interface IEntityService<T> : IRepository<T> where T : BaseEntity
    {
    }
}
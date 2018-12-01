namespace Core.Entities
{
    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        T IEntity<T>.Id
        {
            get; set;
        }
    }
}
namespace Core.Entities
{
    public abstract class AuditableEntity<T> : Entity<T>, IAuditableEntity
    {
        // public string Name { get; set; }
    }
}
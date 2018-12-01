namespace Core.Domain
{
    using Core.Entities;

    public class Account : AccountEntity
    {
        public string Avatar { get; set; }

        public bool? IsLockedOut { get; set; } = false;
    }
}
namespace Core.Entities
{
    using System;

    public class AccountEntity : AuditableEntity<int>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsApproved { get; set; } = true;

        public DateTime? DateCreated { get; set; } = DateTime.Now;

        public DateTime? DateModified { get; set; }

        public string FullName => $"{this.FirstName} {this.LastName}";
    }
}
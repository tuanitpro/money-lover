using System;

namespace Core.Entities
{
    public class AuditTime
    {
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
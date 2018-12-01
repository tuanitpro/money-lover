namespace Core.Domain
{
    using System;
    using Core.Entities;

    public class Expense : AuditableEntity<int>
    {
        public string GuidId { get; set; } = Guid.NewGuid().ToString();

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public decimal Money { get; set; }

        public string Note { get; set; }

        public int ExpenseType { get; set; } = (int)ExpenseTypeEnum.Expense;

        public string CreatedBy { get; set; }

        public DateTimeOffset? CreatedDate { get; set; } = DateTime.Now;

        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
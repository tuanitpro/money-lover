namespace Core.Models
{
    using System;

    public class ExpenseModel
    {
        public int Id { get; set; }

        public string GuidId { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public decimal Money { get; set; }

        public string Note { get; set; }

        public int ExpenseType { get; set; }

        public string CreatedBy { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
    }
}
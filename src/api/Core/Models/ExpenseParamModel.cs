namespace Core.Models
{
    using System;

    public class ExpenseParamModel
    {
        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        public string CreatedBy { get; set; }
    }
}
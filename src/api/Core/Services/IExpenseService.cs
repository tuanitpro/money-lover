namespace Core.Services
{
    using System.Collections.Generic;
    using Core.Domain;
    using Core.Models;

    public interface IExpenseService : IEntityService<Expense>
    {
        IEnumerable<Expense> SeedData();

        IEnumerable<Expense> GetExpenseByUser(ExpenseParamModel paramModel);
    }
}
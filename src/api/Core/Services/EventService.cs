namespace Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Entities;
    using Core.Models;
    using Core.Utilities;

    public class EventService : IEventService
    {
        private readonly IExpenseService expenseService;

        public EventService(IExpenseService expenseService)
        {
            this.expenseService = expenseService;
        }

        public IEnumerable<Event> GetEvents(DateTime? start, DateTime? end)
        {
            if (!start.HasValue)
            {
                var now = DateTime.Today;
                DateTime date = new DateTime(now.Year, now.Month, 1).FirstDayOfWeek();

                start = date.StartOfDate();
            }
            if (!end.HasValue)
            {
                end = start.Value.AddDays(41).EndOfDate();
            }
            var param = new ExpenseParamModel
            {
                Start = start,
                End = end,
                CreatedBy = ""
            };

            var events = new List<Event>();
            var expenses = expenseService.GetExpenseByUser(param);
            events = expenses.Select(x => new Event
            {
                Id = x.GuidId,
                Title = x.Money.ToString() + ": " + x.CategoryName,
                Start = x.CreatedDate.Value,
                Color = x.ExpenseType == (int)ExpenseTypeEnum.Expense ? "red" : "green",
                Description = x.Note,
                IsFullDay = true
            }).ToList();
            return events;
        }
    }
}
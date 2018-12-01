using System;
using System.Threading.Tasks;
using Core.Domain;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService eventService;

        private readonly IExpenseService expenseService;

        public EventsController(IEventService eventService, IExpenseService expenseService)
        {
            this.eventService = eventService;
            this.expenseService = expenseService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DateTime? start, DateTime? end)
        {
            var events = eventService.GetEvents(start, end);
            return Ok(new ResponseResultModel
            {
                Data = events,
                Code = 200,
                Message = "OK"
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ExpenseModel model)
        {
            var expense = new Expense
            {
                CategoryId = model.CategoryId,
                CategoryName = model.CategoryName,
                Money = model.Money,
                CreatedDate = model.CreatedDate,
                ExpenseType = model.ExpenseType,
                Note = model.Note
            };
            expenseService.Insert(expense);

            return Ok(new ResponseResultModel
            {
                Data = expense,
                Code = 200,
                Message = "OK"
            });
        }
    }
}
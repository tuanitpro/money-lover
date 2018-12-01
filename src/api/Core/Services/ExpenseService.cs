namespace Core.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Core.DataProvider;
    using Core.Domain;
    using Core.Models;
    using Faker;

    public class ExpenseService : EfRepository<Expense>, IExpenseService
    {
        public ExpenseService(DataContext context) : base(context)
        {
        }

        public IEnumerable<Expense> GetExpenseByUser(ExpenseParamModel paramModel)
        {
            return Table.Where(x => x.CreatedDate >= paramModel.Start && x.CreatedDate <= paramModel.End).OrderBy(x => x.CreatedDate).ToList();
        }

        public IEnumerable<Expense> SeedData()
        {
            var events = new List<Expense>();
            var categories = new List<CategoryModel>
            {
                new CategoryModel{Id = 1, Name="Ăn uống"},
                new CategoryModel{Id = 2, Name="Thời trang"},
                new CategoryModel{Id = 3, Name="Du lịch"},
                new CategoryModel{Id = 4, Name="Học tập"},
                new CategoryModel{Id = 5, Name="Sức khỏe"},
                new CategoryModel{Id = 6, Name="Xe cộ"},
                new CategoryModel{Id = 7, Name="Khác"},
            };

            System.Random random = new System.Random();
            var fromDate = new System.DateTime(2018, 1, 1);
            var toDate = fromDate.AddMonths(12);
            for (int i = 0; i < 500; i++)
            {
                var startDate = DateTimeFaker.DateTime(fromDate, toDate);
                var item = new Expense
                {
                    Note = TextFaker.Sentence(),
                    CategoryId = random.Next(1, 6),
                    CreatedDate = startDate,
                    Money = NumberFaker.Number(10000, 500000),
                    ExpenseType = i % 2,
                    CreatedBy = "tuanitpro@gmail.com",
                    CategoryName = categories[random.Next(0, 6)].Name
                };

                events.Add(item);
            }
            Insert(events);

            return events;
        }
    }
}
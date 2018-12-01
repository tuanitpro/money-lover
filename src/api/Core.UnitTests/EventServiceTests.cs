using Xunit;
using Core.Services;
using NSubstitute;

namespace Core.UnitTests
{
    public class EventServiceTests
    {
        [Fact]
        public void GetEvents_ListEvents()
        {
            var expenseService = Substitute.For<IExpenseService>();

            var eventService = new EventService(expenseService);

            var actualResult = eventService.GetEvents(null, null);

            var expected = 0;
        }
    }
}
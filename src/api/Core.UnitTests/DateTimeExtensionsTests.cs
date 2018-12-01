using System;
using Core.Utilities;
using Xunit;

namespace Core.UnitTests
{
    public class DateTimeExtensionsTests
    {
        [Fact]
        public void FirstDayOfWeek_StartAt_Monday()
        {
            // Arrange
            var dateTime = new DateTime(2018, 12, 2);

            // Act
            var actualResult = DateTimeExtensions.FirstDayOfWeek(dateTime, DayOfWeek.Monday);

            // Assert
            var dateTimeExpected = new DateTime(2018, 11, 26);
            Assert.Equal(dateTimeExpected, actualResult);
        }

        [Fact]
        public void FirstDayOfWeek_StartAt_Sunday()
        {
            // Arrange
            var dateTime = new DateTime(2018, 12, 1);

            // Act
            var actualResult = DateTimeExtensions.FirstDayOfWeek(dateTime);

            // Assert
            var dateTimeExpected = new DateTime(2018, 11, 25);
            Assert.Equal(dateTimeExpected, actualResult);
        }

        [Fact]
        public void EndDayOfMonth()
        {
            // Arrange
            var dateTime = new DateTime(2018, 10, 29);

            // Act
            var actualResult = dateTime.AddDays(41);

            // Assert
            var dateTimeExpected = new DateTime(2018, 12, 9);
            Assert.Equal(dateTimeExpected, actualResult);
        }
    }
}
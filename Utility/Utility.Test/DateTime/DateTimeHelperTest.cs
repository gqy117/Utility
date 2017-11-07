namespace Utility.Test
{
    using System;
    using System.Collections.Generic;
    using FluentAssertions;
    using Xunit;

    public class DateTimeHelperTest
    {
        public static IEnumerable<object[]> LeapYear => new[] { new object[] { new DateTime(2016, 1, 1), new DateTime(2016, 12, 31), 1M },};
        public static IEnumerable<object[]> NormalYear => new[] { new object[] { new DateTime(2017, 1, 1), new DateTime(2017, 12, 31), 1M },};


        [Theory]
        [MemberData(nameof(LeapYear))]
        public void DiffYears_ShouldReturn1_WhenItIsLeapYear(DateTime startDate, DateTime endDate, decimal expected)
        {
            // Act
            decimal actual = startDate.DiffYears(endDate);

            // Assert
            actual.ShouldBeEquivalentTo(expected);
        }
    }
}

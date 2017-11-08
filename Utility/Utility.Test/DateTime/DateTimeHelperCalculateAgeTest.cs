namespace Utility.Test
{
    using System;
    using System.Collections.Generic;
    using FluentAssertions;
    using Xunit;

    public class DateTimeHelperCalculateAgeTest
    {
        public static IEnumerable<object[]> HalfYear => new[] { new object[] { new DateTime(2016, 1, 1), new DateTime(2016, 7, 2), 0 } };
        public static IEnumerable<object[]> ThreeYears => new[] { new object[] { new DateTime(2015, 1, 1), new DateTime(2018, 1, 1), 3 } };
        public static IEnumerable<object[]> FiveYears => new[] { new object[] { new DateTime(2015, 1, 1), new DateTime(2020, 1, 1), 5 } };
        public static IEnumerable<object[]> ZeroDay => new[] { new object[] { new DateTime(2015, 1, 1), new DateTime(2015, 1, 1), 0 } };
        public static IEnumerable<object[]> Negative => new[] { new object[] { new DateTime(2017, 1, 1), new DateTime(2016, 1, 1), -1 } };
        public static IEnumerable<object[]> OneDay => new[] { new object[] { new DateTime(2015, 1, 1), new DateTime(2015, 1, 2), 0 } };
        public static IEnumerable<object[]> OneYear => new[] { new object[] { new DateTime(2016, 1, 1), new DateTime(2017, 1, 1), 1 } };
        public static IEnumerable<object[]> OneYearOneDay => new[] { new object[] { new DateTime(2017, 1, 1), new DateTime(2018, 1, 2), 1 } };
        public static IEnumerable<object[]> StartDateIsMiddleOfYear => new[] { new object[] { new DateTime(2015, 4, 17), new DateTime(2016, 4, 17), 1 } };

        [Theory]
        [MemberData(nameof(OneYear))]
        [MemberData(nameof(HalfYear))]
        [MemberData(nameof(ThreeYears))]
        [MemberData(nameof(FiveYears))]
        [MemberData(nameof(StartDateIsMiddleOfYear))]
        [MemberData(nameof(ZeroDay))]
        [MemberData(nameof(OneDay))]
        [MemberData(nameof(OneYearOneDay))]
        [MemberData(nameof(Negative))]
        public void CalculateAgeTests(DateTime startDate, DateTime endDate, int expected)
        {
            // Act
            decimal actual = startDate.CalculateAge(endDate);

            // Assert
            actual.ShouldBeEquivalentTo(expected);
        }
    }
}

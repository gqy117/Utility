namespace Utility.Test
{
    using System;
    using System.Collections.Generic;
    using FluentAssertions;
    using Xunit;

    public class DateTimeHelperTest
    {
        public static IEnumerable<object[]> OneLeapYear => new[] { new object[] { new DateTime(2016, 1, 1), new DateTime(2017, 1, 1), 1M } };
        public static IEnumerable<object[]> OneYear => new[] { new object[] { new DateTime(2017, 1, 1), new DateTime(2018, 1, 1), 1M } };
        public static IEnumerable<object[]> HalfYear => new[] { new object[] { new DateTime(2016, 1, 1), new DateTime(2016, 7, 2), 0.5M } };
        public static IEnumerable<object[]> ThreeYears => new[] { new object[] { new DateTime(2015, 1, 1), new DateTime(2018, 1, 1), 3M } };
        public static IEnumerable<object[]> ZeroDay => new[] { new object[] { new DateTime(2015, 1, 1), new DateTime(2015, 1, 1), 0M } };
        public static IEnumerable<object[]> OneDay => new[] { new object[] { new DateTime(2015, 1, 1), new DateTime(2015, 1, 2), 1 / 365M } };
        public static IEnumerable<object[]> TwoDays => new[] { new object[] { new DateTime(2015, 1, 1), new DateTime(2015, 1, 3), 2 / 365M } };
        public static IEnumerable<object[]> OneDayLeapYear => new[] { new object[] { new DateTime(2016, 1, 1), new DateTime(2016, 1, 2), 1 / 366M } };
        public static IEnumerable<object[]> TwoDaysLeapYear => new[] { new object[] { new DateTime(2016, 1, 1), new DateTime(2016, 1, 3), 2 / 366M } };
        public static IEnumerable<object[]> OneYearOneDayLeapYear => new[] { new object[] { new DateTime(2015, 1, 1), new DateTime(2016, 1, 2), 1 + 1 / 366M } };
        public static IEnumerable<object[]> OneYearOneDay => new[] { new object[] { new DateTime(2017, 1, 1), new DateTime(2018, 1, 2), 1 + 1 / 365M } };
        public static IEnumerable<object[]> Negative => new[] { new object[] { new DateTime(2017, 1, 1), new DateTime(2016, 1, 1), -1M } };

        [Theory]
        [MemberData(nameof(OneLeapYear))]
        [MemberData(nameof(OneYear))]
        [MemberData(nameof(HalfYear))]
        [MemberData(nameof(ThreeYears))]
        [MemberData(nameof(ZeroDay))]
        [MemberData(nameof(OneDay))]
        [MemberData(nameof(TwoDays))]
        [MemberData(nameof(OneDayLeapYear))]
        [MemberData(nameof(TwoDaysLeapYear))]
        [MemberData(nameof(OneYearOneDayLeapYear))]
        [MemberData(nameof(OneYearOneDay))]
        [MemberData(nameof(Negative))]
        public void DiffYearsTests(DateTime startDate, DateTime endDate, decimal expected)
        {
            // Act
            decimal actual = startDate.DiffYears(endDate);

            // Assert
            actual.ShouldBeEquivalentTo(expected);
        }
    }
}

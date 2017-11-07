namespace Utility.Test
{
    using System;
    using System.Collections.Generic;
    using FluentAssertions;
    using Xunit;

    public class DateTimeHelperTest
    {
        public static IEnumerable<object[]> LeapYear => new[] { new object[] { new DateTime(2016, 1, 1), new DateTime(2016, 12, 31), 1M } };
        public static IEnumerable<object[]> NormalYear => new[] { new object[] { new DateTime(2017, 1, 1), new DateTime(2017, 12, 31), 1M } };
        public static IEnumerable<object[]> HalfYear => new[] { new object[] { new DateTime(2016, 1, 1), new DateTime(2016, 7, 1), 0.5M } };
        public static IEnumerable<object[]> ThreeYears => new[] { new object[] { new DateTime(2015, 1, 1), new DateTime(2017, 12, 31), 3M } };
        public static IEnumerable<object[]> OneDayNormalYear => new[] { new object[] { new DateTime(2015, 1, 1), new DateTime(2015, 1, 1), 1 / 365M } };
        public static IEnumerable<object[]> TwoDaysNormalYear => new[] { new object[] { new DateTime(2015, 1, 1), new DateTime(2015, 1, 2), 2 / 365M } };
        public static IEnumerable<object[]> OneDayLeapYear => new[] { new object[] { new DateTime(2016, 1, 1), new DateTime(2016, 1, 1), 1 / 366M } };
        public static IEnumerable<object[]> TwoDaysLeapYear => new[] { new object[] { new DateTime(2016, 1, 1), new DateTime(2016, 1, 2), 2 / 366M } };
        public static IEnumerable<object[]> OneYearOneDayLeapYear => new[] { new object[] { new DateTime(2015, 1, 1), new DateTime(2016, 1, 1), 1 + 1 / 366M } };
        public static IEnumerable<object[]> OneYearOneDayNormalYear => new[] { new object[] { new DateTime(2017, 1, 1), new DateTime(2018, 1, 1), 1 + 1 / 365M } };
        public static IEnumerable<object[]> Negative => new[] { new object[] { new DateTime(2017, 1, 2), new DateTime(2016, 1, 1), -1M } };

        [Theory]
        [MemberData(nameof(LeapYear))]
        [MemberData(nameof(NormalYear))]
        [MemberData(nameof(HalfYear))]
        [MemberData(nameof(ThreeYears))]
        [MemberData(nameof(OneDayNormalYear))]
        [MemberData(nameof(TwoDaysNormalYear))]
        [MemberData(nameof(OneDayLeapYear))]
        [MemberData(nameof(TwoDaysLeapYear))]
        [MemberData(nameof(OneYearOneDayLeapYear))]
        [MemberData(nameof(OneYearOneDayNormalYear))]
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

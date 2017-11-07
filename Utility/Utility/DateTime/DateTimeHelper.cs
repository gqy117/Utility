namespace Utility
{
    using System;

    public static class DateTimeHelper
    {
        public static decimal DiffYears(this DateTime startDate, DateTime endDate)
        {
            endDate = endDate.AddDays(1);

            int intYears = endDate.Year - startDate.Year;
            DateTime lastYear = startDate.AddYears(intYears);
            if (lastYear > endDate)
            {
                lastYear = lastYear.AddYears(-1);
                intYears--;
            }

            DateTime nextYear = lastYear.AddYears(1);

            int yearDays = (nextYear - lastYear).Days;
            int days = (endDate - lastYear).Days;

            decimal exactAge = intYears + (days / yearDays);

            return exactAge;
        }
    }
}

namespace Utility
{
    using System;

    public static class DateTimeHelper
    {
        public static decimal DiffYears(this DateTime startDate, DateTime endDate)
        {
            int intYears = endDate.Year - startDate.Year;
            DateTime lastYear = startDate.AddYears(intYears);
            if (lastYear > endDate)
            {
                lastYear = lastYear.AddYears(-1);
                intYears--;
            }

            DateTime nextYear = lastYear.AddYears(1);

            decimal yearDays = (nextYear - lastYear).Days;
            decimal days = (endDate - lastYear).Days;

            decimal exactAge = intYears + (days / yearDays);

            return exactAge;
        }

        public static int CalculateAge(this DateTime startDate, DateTime endDate)
        {
            int age = endDate.Year - startDate.Year;

            // Go back to the year the person was born in case of a leap year
            if (startDate > endDate.AddYears(-age))
                age--;

            return age;
        }
    }
}

namespace Utility.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DateTimeHelperTest
    {
        [TestMethod]
        public void DiffYears_ShouldReturn1_WhenItIsLeapYear()
        {
            // Arrange
            DateTime startDate = new DateTime(2016, 1, 1);
            DateTime endDate = new DateTime(2016, 12, 31);

            // Act
            decimal years = startDate.DiffYears(endDate);

            // Assert
            decimal expected = 1M;

            Assert.AreEqual(expected, years);
        }

        [TestMethod]
        public void DiffYears_ShouldReturn1_WhenItIsNotLeapYear()
        {
            // Arrange
            DateTime startDate = new DateTime(2017, 1, 1);
            DateTime endDate = new DateTime(2017, 12, 31);

            // Act
            decimal years = startDate.DiffYears(endDate);

            // Assert
            decimal expected = 1M;

            Assert.AreEqual(expected, years);
        }
    }
}

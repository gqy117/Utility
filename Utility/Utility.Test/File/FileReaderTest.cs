namespace Utility.Test
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using FluentAssertions;

    [TestClass]
    public class FileReaderTest
    {
        private FileReader FileReader { get; set; }

        [TestInitialize]
        public void Init()
        {
            FileReader = new FileReader();
        }

        [TestMethod]
        public void ReadStringTest()
        {
            // Arrange
            string expected = "1";
            string fileName = "File\\FileReaderTest.txt";

            // Act
            string actual = FileReader.ReadString(fileName);

            // Assert
            actual.ShouldBeEquivalentTo(expected);
        }
    }
}

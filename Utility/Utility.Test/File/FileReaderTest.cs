namespace Utility.Test
{
    using Xunit;
    using FluentAssertions;

    public class FileReaderTest
    {
        private FileReader FileReader { get; set; }

        public FileReaderTest()
        {
            FileReader = new FileReader();
        }

        [Fact]
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

namespace Utility.Test
{
    using System.Security.Cryptography;
    using System.Text;
    using FluentAssertions;
    using Xunit;

    public class PasswordWithSaltHasherTest
    {
        private PasswordWithSaltHasher PasswordWithSaltHasher;

        public PasswordWithSaltHasherTest()
        {
            this.PasswordWithSaltHasher = new PasswordWithSaltHasher();
        }

        [Fact]
        public void HashWithSalt_ShouldReturnEncryptedString_WhenTheInputIs1()
        {
            // Arrange
            string plaintext = "1";
            byte[] saltBytes = Encoding.ASCII.GetBytes("tgGoZ5PobQD4LZFdclx9FyL5vsqvVDrPnTIblUmJLZmQsGjawWlun5ZK0M3l2Vzc30UE+vWaYaPi791rJVw1uA==");
            
            // Act
            var actual = this.PasswordWithSaltHasher.HashWithSalt(plaintext, saltBytes, SHA256.Create());

            // Assert
            var expected = "4EG42q/MwrOzefVzehXlrJkrVuRlaXVVRG2LO1NX3G0=";

            actual.Digest.ShouldBeEquivalentTo(expected);
        }
    }
}

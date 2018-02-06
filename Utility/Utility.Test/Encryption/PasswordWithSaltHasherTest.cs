namespace Utility.Test
{
    using System.Security.Cryptography;
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

            // Act
            var actual = this.PasswordWithSaltHasher.HashWithSalt(plaintext, 64, SHA256.Create());

            // Assert
            var expected = "a4ayc/80/OGda4BO/1o/V0etpOqiLx1JwB5S3beHW0s=";

            actual.Digest.ShouldBeEquivalentTo(expected);
        }
    }
}

namespace Utility.Test
{
    using System;
    using System.Security.Cryptography;
    using System.Text;
    using FluentAssertions;
    using Xunit;

    public class PasswordHashTest
    {
        [Fact]
        public void HashWithSalt_ShouldReturnEncryptedString_WhenTheInputIs1()
        {
            // Arrange
            string plaintext = "1";
            string passwordBase64 = "/jXZiDyCmhbrOMKpQ9owOJrGjyk=";
            string saltBase64 = "bB9D1uRu5HLfhA0g4aHOtw==";

            var hasher = new PasswordHash();

            // Act
            var actual = hasher.Verify(saltBase64, passwordBase64, plaintext);

            // Assert
            var expected = true;

            actual.ShouldBeEquivalentTo(expected);
        }
    }
}

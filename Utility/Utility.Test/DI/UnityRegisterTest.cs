
namespace Utility.Test
{
    using FluentAssertions;
    using System.Linq;
    using Microsoft.Practices.Unity;
    using Xunit;
    using Utility.UnityRegister;

    public class UnityRegisterTest
    {
        [Fact]
        public void ReadStringTest()
        {
            // Arrange
            IUnityContainer unityContainer = new UnityContainer();

            // Act
            UnityRegister.RegisterTypes(unityContainer);

            // Assert
            unityContainer.Resolve<FileReader>().Should().NotBeNull();
        }
    }
}

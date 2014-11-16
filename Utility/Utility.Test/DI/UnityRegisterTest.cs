

namespace Utility.Test
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using FluentAssertions;
    using System.Linq;
    using Microsoft.Practices.Unity;
    using Utility.UnityRegister;

    [TestClass]
    public class UnityRegisterTest
    {
        [TestMethod]
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

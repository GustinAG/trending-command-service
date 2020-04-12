using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trending.Command.Api.Controllers;

namespace Trending.Command.Api.Tests
{
    [TestClass]
    public class DefaultControllerUnitTests
    {
        [TestMethod]
        public void Get_ShouldReturnSomething()
        {
            // Arrange
            var controller = new DefaultController();

            // Act
            var text = controller.Get();

            // Assert
            Console.WriteLine(text);
            text.Should().NotBeNullOrWhiteSpace("in root level we expect some text to get");
        }
    }
}

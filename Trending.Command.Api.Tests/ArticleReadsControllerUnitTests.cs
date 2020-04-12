using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Trending.Command.Api.Controllers;
using Trending.Command.Contracts;

namespace Trending.Command.Api.Tests
{
    [TestClass]
    public class ArticleReadsControllerUnitTests
    {
        [TestMethod]
        public void Post_ShouldCallScorer()
        {
            // Arrange
            const int articleId = 1;
            const int readingLevel = 2;
            var mockedScorer = Substitute.For<IArticleReadScorer>();
            var controller = new ArticleReadsController(mockedScorer);

            // Act
            controller.Post(articleId, readingLevel);

            // Assert
            mockedScorer.Received(1).ScoreArticleRead(articleId, readingLevel);
        }
    }
}

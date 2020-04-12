using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Trending.Command.Contracts;

namespace Trending.Command.BusinessLogic.Tests
{
    [TestClass]
    public class ScorerUnitTests
    {
        [TestMethod]
        public void ScoreArticleRead_ShouldCallRepository()
        {
            // Arrange
            const int articleId = 1;
            const int readingLevel = 2;
            var mockedRepository = Substitute.For<IArticlesRepository>();
            var scorer = new Scorer(mockedRepository);

            // Act
            scorer.ScoreArticleRead(articleId, readingLevel);

            // Assert
            mockedRepository.Received(1).AddScore(articleId, Arg.Any<int>());
        }

        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataTestMethod]
        public void ScoreArticleRead_ShouldGivePositiveScore(int readingLevel)
        {
            // Arrange
            const int articleId = 1;
            var mockedRepository = Substitute.For<IArticlesRepository>();
            var scorer = new Scorer(mockedRepository);

            // Act
            scorer.ScoreArticleRead(articleId, readingLevel);

            // Assert
            mockedRepository.Received(1).AddScore(articleId, Arg.Is<int>(s => s > 0));
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Trending.Command.Repositories.Tests
{
    [TestClass]
    public class ArticlesRepositoryIntegrationTests
    {
        // TODO: This doesn't work - no idea why!
        // See also: https://stackoverflow.com/questions/31314245/a-timeout-occured-after-30000ms-selecting-a-server-using-compositeserverselector
        [TestMethod]
        public void AddScore_ShouldRunWithoutException()
        {
            // Arrange
            var repository = new ArticlesRepository();

            // Act
            repository.AddScore(8, 2);
        }
    }
}

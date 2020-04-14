using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trending.Command.Contracts;

namespace Trending.Command.Repositories.Tests
{
    [TestClass]
    public class ArticlesRepositoryIntegrationTests
    {
        private const string LocalIp = "127.0.0.1";
        private static readonly IMongoConfig Config = new MongoConfig(LocalIp);

        [TestMethod]
        public void AddScore_ShouldRunWithoutException()
        {
            // Arrange
            var repository = new ArticlesRepository(Config);

            // Act
            repository.AddScore(8, 2);
        }
    }
}

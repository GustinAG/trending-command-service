using Trending.Command.Contracts;

namespace Trending.Command.Repositories.Tests
{
    public class MongoConfig : IMongoConfig
    {
        private readonly string _hostName;

        public MongoConfig(string hostName)
        {
            _hostName = hostName;
        }

        public string MongoUrl => $"mongodb://{_hostName}:27017";
    }
}

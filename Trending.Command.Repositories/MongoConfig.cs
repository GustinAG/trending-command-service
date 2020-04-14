using Trending.Command.Contracts;

namespace Trending.Command.Repositories
{
    public class MongoConfig : IMongoConfig
    {
        private readonly string _ip;

        public MongoConfig(string ip)
        {
            _ip = ip;
        }

        public string MongoUrl => $"mongodb://{_ip}:27017";
    }
}

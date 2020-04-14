using System;
using MongoDB.Bson;
using MongoDB.Driver;
using Trending.Command.Contracts;

namespace Trending.Command.Repositories
{
    public class ArticlesRepository : IArticlesRepository
    {
        private const string DbName = "trendingevents";
        private const string CollectionName = "articleevents";
        private readonly IMongoConfig _config;

        public ArticlesRepository(IMongoConfig config)
        {
            _config = config;
        }

        public void AddScore(int articleId, int score)
        {
            var dbClient = new MongoClient(_config.MongoUrl);
            var db = dbClient.GetDatabase(DbName);
            var events = db.GetCollection<BsonDocument>(CollectionName);
            var timeStamp = DateTime.UtcNow.ToString("s");
            var newEvent = new BsonDocument { { "timestamp", timeStamp }, { "article_Id", articleId }, { "score", score } };

            events.InsertOne(newEvent);
        }
    }
}

using System;
using MongoDB.Bson;
using MongoDB.Driver;
using Trending.Command.Contracts;

namespace Trending.Command.Repositories
{
    public class ArticlesRepository : IArticlesRepository
    {
        private const string MongoIp = "172.17.0.3";     // TODO: Fix this magic IP in Docker Compose!
        private const string MongoUrl = "mongodb://" + MongoIp + ":27017";
        private const string DbName = "trendingevents";
        private const string CollectionName = "articleevents";

        public void AddScore(int articleId, int score)
        {
            var dbClient = new MongoClient(MongoUrl);
            var db = dbClient.GetDatabase(DbName);
            var events = db.GetCollection<BsonDocument>(CollectionName);
            var timeStamp = DateTime.UtcNow.ToString("s");
            var newEvent = new BsonDocument { { "timestamp", timeStamp }, { "article_Id", articleId }, { "score", score } };

            events.InsertOne(newEvent);
        }
    }
}

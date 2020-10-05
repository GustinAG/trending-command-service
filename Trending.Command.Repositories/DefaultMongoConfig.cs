using System;
using System.Collections.Generic;
using Trending.Command.Contracts;

namespace Trending.Command.Repositories
{
    public sealed class DefaultMongoConfig : IMongoConfig
    {
        public string MongoUrl { get; } = GetEnvironmentVariable("MONGODB");

        private static string GetEnvironmentVariable(string name)
        {
            var value = Environment.GetEnvironmentVariable(name);
            if (string.IsNullOrWhiteSpace(value)) throw new KeyNotFoundException($"Missing environment variable '{name}'!");
            return value;
        }
    }
}

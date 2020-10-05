namespace Trending.Command.Repositories
{
    public sealed class LocalDockerMongoConfig : MongoConfig
    {
        private const string DockerServiceName = "mongodb";

        public LocalDockerMongoConfig() : base(DockerServiceName)
        { }
    }
}

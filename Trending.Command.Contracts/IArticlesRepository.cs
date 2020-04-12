namespace Trending.Command.Contracts
{
    public interface IArticlesRepository
    {
        void AddScore(int articleId, int score);
    }
}

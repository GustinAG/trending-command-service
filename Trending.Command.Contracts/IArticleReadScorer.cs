namespace Trending.Command.Contracts
{
    public interface IArticleReadScorer
    {
        void ScoreArticleRead(int articleId, int readingLevel);
    }
}

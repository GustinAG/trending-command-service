using Dawn;
using Trending.Command.Contracts;

namespace Trending.Command.BusinessLogic
{
    public class Scorer : IArticleReadScorer
    {
        private const int MinLevel = 1;
        private const int MaxLevel = 3;

        private readonly IArticlesRepository _repository;

        public Scorer(IArticlesRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Scores an article read event.
        /// </summary>
        /// <param name="articleId">Article's ID that's been read.</param>
        /// <param name="readingLevel">Level of reading (1, 2, 3) - indicating how long the reader has already been reading the article now.</param>
        public void ScoreArticleRead(int articleId, int readingLevel)
        {
            Guard.Argument(articleId, nameof(articleId)).Positive();
            Guard.Argument(readingLevel, nameof(readingLevel)).InRange(MinLevel, MaxLevel);

            var score = readingLevel switch
            {
                1 => 2,
                2 => 3,
                3 => 5,
                _ => 0
            };

            _repository.AddScore(articleId, score);
        }
    }
}

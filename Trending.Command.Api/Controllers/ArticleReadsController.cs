using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Trending.Command.Contracts;

namespace Trending.Command.Api.Controllers
{
    [Route("article-reads")]
    [ApiController]
    public class ArticleReadsController : ControllerBase
    {
        private readonly IArticleReadScorer _scorer;

        public ArticleReadsController(IArticleReadScorer scorer)
        {
            _scorer = scorer;
        }

        /// <summary>
        /// Adds an article read event on a certain level - based on how long the article has already been read by the reader.
        /// </summary>
        /// <param name="articleId">Article's ID that's been read.</param>
        /// <param name="readingLevel">Level of reading (1, 2, 3) - indicating how long the reader has already been reading the article now.</param>
        [HttpPost, Route("{articleId}")]
        public void Post(int articleId, [FromBody, Required] int readingLevel)
        {
            _scorer.ScoreArticleRead(articleId, readingLevel);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using MyApp.Helper;
using MyApp.Interfaces.IManagers;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Managers
{
    public class ArticleManager : IArticleManager
    {
        private readonly AppDbContext appDbContext;

        public ArticleManager(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<List<Article>> GetArticles()
        {
            return await appDbContext.Articles.ToListAsync();
        }

        public async Task<Article> LikeArticles(int articleId)
        {
            var article = await appDbContext.Articles.FirstOrDefaultAsync(a => a.Id == articleId);

            if (article == null)
            {
                throw new DataNotFoundException("Article Not Found");
            }

            var like = article.Likes + 1;
            article.Likes = like;
            await appDbContext.SaveChangesAsync();
            return article;
        }
    }
}

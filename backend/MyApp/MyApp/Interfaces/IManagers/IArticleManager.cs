using MyApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Interfaces.IManagers
{
    public interface IArticleManager
    {
        Task<List<Article>> GetArticles();
        Task<Article> LikeArticles(int articleId);
    }
}
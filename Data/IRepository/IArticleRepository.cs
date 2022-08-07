using FitnessWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWebAPI.Data.IRepository
{
    public interface IArticleRepository
    {
        void AddArticle(Article category);
        void UpdateArticle(Article category);
        IEnumerable<Article> ArticleList();
        IEnumerable<Article> BindVisibleArticle();
        Article GetArticleById(int id);
        void DeleteArticle(int id);
        IEnumerable<Article> BindVisibleArticleFrontend(int catId);
    }
}

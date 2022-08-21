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
        IEnumerable<Article> BindVisibleArticleFrontend(int catId,int take);
        IEnumerable<Article> BindVisibleArticleBySubCategoryId(int subCatId,int take);
        IEnumerable<Article> BindMoreVisibleArticleFrontend(int skp, int take);
        IEnumerable<Article> BindTopPopularArticles(int take);
    }
}

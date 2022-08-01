using FitnessWebAPI.Data.IRepository;
using FitnessWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWebAPI.Data.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationDbContext _db;
        public ArticleRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void AddArticle(Article article)
        {
            _db.Articles.Add(article);
        }
        public void UpdateArticle(Article article)
        {
            var art = GetArticleById(article.Id);
            art.CategoryId = article.CategoryId;
            art.SubCategoryId = article.SubCategoryId;
            art.HeadingName = article.HeadingName;
            art.ShortArticle = article.ShortArticle;
            art.Image = article.Image;
            art.ArticleInEnglish = article.ArticleInEnglish;
            art.ArticleInHindi = article.ArticleInHindi;
            art.Visible = article.Visible;
            _db.Articles.Update(art);
        }

        public IEnumerable<Article> ArticleList()
        {
            return _db.Articles.ToList();
        }
        public IEnumerable<Article> BindVisibleArticle()
        {
            return _db.Articles.Where(x=>x.Visible==true);
        }

        public void DeleteArticle(int id)
        {
            var entity = _db.Articles.Find(id);
            _db.Articles.Remove(entity);
        }

        public Article GetArticleById(int id)
        {
            return _db.Articles.Find(id);
        }
    }
}

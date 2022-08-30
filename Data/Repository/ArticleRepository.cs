using FitnessWebAPI.Data.IRepository;
using FitnessWebAPI.Models;
using Microsoft.EntityFrameworkCore;
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
            _db.Articles.Update(article);
        }

        public IEnumerable<Article> ArticleList()
        {
            return _db.Articles.Include(x => x.SubCategory).ThenInclude(x => x.Category).ToList();
        }
        public IEnumerable<Article> BindVisibleArticle()
        {
            return _db.Articles.Where(x => x.Visible == true).Include(x => x.SubCategory).ThenInclude(x => x.Category).ToList();
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
        public IEnumerable<Article> BindVisibleArticleFrontend(int catId,int take)
        {
            //return _db.Articles.Include(x => x.SubCategory).ThenInclude(x => x.Category).Where(x => x.CategoryId == catId).ToList();
            if (catId == 0)
                return _db.Articles.Where(x => x.Visible == true).Take(take).Include(x => x.SubCategory).ThenInclude(x => x.Category).ToList();
            else
                return _db.Articles.Where(x => x.CategoryId == catId && x.Visible == true).Take(take).Include(x => x.SubCategory).ThenInclude(x => x.Category).ToList();
        }
        public IEnumerable<Article> BindVisibleArticleBySubCategoryId(int subCatId, int take)
        {
                return _db.Articles.Where(x=>x.Visible == true && x.SubCategoryId==subCatId).Take(take).Include(x => x.SubCategory).ThenInclude(x => x.Category).ToList();
        }
        public IEnumerable<Article> BindMoreVisibleArticleFrontend(int skp, int take)
        {
                return _db.Articles.Where(x => x.Visible == true).Skip(skp).Take(take).Include(x => x.SubCategory).ThenInclude(x => x.Category).ToList();
        }
        public IEnumerable<Article> BindTopPopularArticles(int take)
        {
                return _db.Articles.Where(x => x.Visible == true).OrderByDescending(x => x.Views).Take(take).Include(x => x.SubCategory).ThenInclude(x => x.Category).ToList();
        }
        public IEnumerable<Article> BindBasicArticleforHome(int take)
        {
            var result = _db.Articles.Where(x => x.Visible == true).Include(x => x.SubCategory).ThenInclude(x => x.Category);
            return result.Where(x => x.SubCategory.Category.Name == "Basics").Take(take).ToList();
        }
    }
}

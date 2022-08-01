﻿using FitnessWebAPI.Data.IRepository;

namespace FitnessWebAPI.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ICategoryRepository CategoryRepository { get; }
        public ISubCategoryRepository SubCategoryRepository { get; }
        public IArticleRepository ArticleRepository { get; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            CategoryRepository = new CategoryRepository(_db);
            SubCategoryRepository = new SubCategoryRepository(_db);
            ArticleRepository = new ArticleRepository(_db);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}

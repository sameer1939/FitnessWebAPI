using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWebAPI.Data.IRepository
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }
        public ISubCategoryRepository SubCategoryRepository { get; }
        public IArticleRepository ArticleRepository { get; }
        public IUserRepository UserRepository { get; }
        public ISubscribersRepository SubscribersRepository { get; }
        public IStoriesRepository StoriesRepository { get; }
        void SaveChanges();
    }
}

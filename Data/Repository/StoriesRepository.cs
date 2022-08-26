using FitnessWebAPI.Data.IRepository;
using FitnessWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWebAPI.Data.Repository
{
    public class StoriesRepository : IStoriesRepository
    {
        private readonly ApplicationDbContext _db;
        public StoriesRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void AddStory(Story story)
        {
            _db.Stories.Add(story);
        }
        public void UpdateStory(Story story)
        {
            _db.Stories.Update(story);
        }

        public IEnumerable<Story> StoryList()
        {
            return _db.Stories.ToList();
        }
        public IEnumerable<Story> BindVisibleStory()
        {
            return _db.Stories.Where(x=>x.Visible==true);
        }

        public void DeleteStory(int id)
        {
            var entity = _db.Stories.Find(id);
            _db.Stories.Remove(entity);
        }

        public Story GetStoryById(int id)
        {
            return _db.Stories.Find(id);
        }
    }
}

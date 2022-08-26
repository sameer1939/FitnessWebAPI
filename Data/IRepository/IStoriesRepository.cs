using FitnessWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWebAPI.Data.IRepository
{
    public interface IStoriesRepository
    {
        void AddStory(Story story);
        void UpdateStory(Story story);
        IEnumerable<Story> StoryList();
        IEnumerable<Story> BindVisibleStory();
        Story GetStoryById(int id);
        void DeleteStory(int id);
    }
}

using AutoMapper;
using FitnessWebAPI.Data.IRepository;
using FitnessWebAPI.DTOs;
using FitnessWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FitnessWebAPI.Controllers
{

    public class StoriesController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StoriesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost("add")]
        public IActionResult AddStory(StoryDTO dtos)
        {
            Story story = new Story();

            story.InsertedDate = DateTime.Now;
            story.InsertedBy = 1;
            story.Visible = dtos.Visible;
            story.VideoUrl = dtos.VideoUrl;
            story.VideoTitle = dtos.VideoTitle;
            _unitOfWork.StoriesRepository.AddStory(story);
            _unitOfWork.SaveChanges();
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult UpdateStory(StoryDTO storyDTO)
        {
            var st = _unitOfWork.StoriesRepository.GetStoryById(storyDTO.Id);

            st.VideoTitle = storyDTO.VideoTitle;
            st.Visible = storyDTO.Visible;
            st.VideoUrl = storyDTO.VideoUrl;

            _unitOfWork.StoriesRepository.UpdateStory(st);
            _unitOfWork.SaveChanges();
            return Ok();
        }

        [HttpGet("bindStories")]
        public IActionResult StoryList()
        {
            var result = _unitOfWork.StoriesRepository.StoryList();
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpGet("bindVisibleStory")]
        public IActionResult BindVisibleStory()
        {
            var result = _unitOfWork.StoriesRepository.BindVisibleStory();
            return Ok(result);
        }

        [HttpDelete("deleteStory/{id}")]
        public IActionResult DeleteStory(int id)
        {
            _unitOfWork.StoriesRepository.DeleteStory(id);
            _unitOfWork.SaveChanges();
            return Ok();
        }
        [AllowAnonymous]
        [HttpGet("StoryById/{id}")]
        public IActionResult CategoryById(int id)
        {
            var result = _unitOfWork.StoriesRepository.GetStoryById(id);
            return Ok(result);
        }
    }
}

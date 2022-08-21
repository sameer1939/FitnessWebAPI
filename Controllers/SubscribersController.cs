using FitnessWebAPI.Data.IRepository;
using FitnessWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FitnessWebAPI.Controllers
{

    public class SubscribersController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubscribersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [AllowAnonymous]
        [HttpPost("subscribe")]
        public IActionResult AddSubscribers(Subscriber model)
        {
            var alreadyExist = _unitOfWork.SubscribersRepository.AlreadyExist(model.Email);
            if (alreadyExist)
                return BadRequest("Subscriber already exists");
            model.InsertedDate = DateTime.Now;
            model.InsertedBy = 1;
            _unitOfWork.SubscribersRepository.AddSubscribers(model);
            _unitOfWork.SaveChanges();
            return Ok();
        }

    }
}
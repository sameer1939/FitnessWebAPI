using FitnessWebAPI.DTOs;
using FitnessWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWebAPI.Data.IRepository
{
    public interface ISubscribersRepository
    {
        void AddSubscribers(Subscriber userReqDTO);
        bool AlreadyExist(string email);
    }
}

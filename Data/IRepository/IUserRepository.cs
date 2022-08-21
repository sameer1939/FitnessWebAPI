using FitnessWebAPI.DTOs;
using FitnessWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWebAPI.Data.IRepository
{
    public interface IUserRepository
    {
        Task<User> Authenticate(string username, string password);
        void Register(UserReqDTO userReqDTO);
        Task<bool> UserAlreadyExists(string username);
    }
}

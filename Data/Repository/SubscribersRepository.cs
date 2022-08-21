using FitnessWebAPI.Data.IRepository;
using FitnessWebAPI.DTOs;
using FitnessWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FitnessWebAPI.Data.Repository
{
    public class SubscribersRepository : ISubscribersRepository
    {
        private readonly ApplicationDbContext _db;
        public SubscribersRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void AddSubscribers(Subscriber model)
        {
            _db.Subscribers.Add(model);
        }
        public bool AlreadyExist(string email)
        {
            var isexist = _db.Subscribers.FirstOrDefault(x => x.Email == email);
            if (isexist!=null)
                return true;
            return false;
        }
    }
}

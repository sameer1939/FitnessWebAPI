﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWebAPI.DTOs
{
    public class UserReqDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

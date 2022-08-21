using AutoMapper;
using FitnessWebAPI.APIErrors;
using FitnessWebAPI.Data.IRepository;
using FitnessWebAPI.DTOs;
using FitnessWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FitnessWebAPI.Controllers
{
    
    public class AccountController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public AccountController(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserReqDTO userReqDTO)
        {
            ApiError apiError = new ApiError();
            var user = await _unitOfWork.UserRepository.Authenticate(userReqDTO.Username, userReqDTO.Password);
            if (user == null)
            {
                apiError.ErrorCode = BadRequest().StatusCode;
                apiError.ErrorMessage = "Invalid Username and Password";
                apiError.ErrorDescription = "Please check username and password you entered is incorrect";
                return Unauthorized(apiError.ToString());
            }

            var resDTO = new UserResDTO();
            resDTO.Username = user.Username;
            resDTO.Token = CreateJWT(user);
            return Ok(resDTO);
        }
        //[HttpPost("register")]
        //public async Task<IActionResult> Register(UserReqDTO userReqDTO)
        //{
        //    ApiError aPIError = new ApiError();
        //    if (string.IsNullOrEmpty(userReqDTO.Username) || string.IsNullOrEmpty(userReqDTO.Password))
        //    {
        //        aPIError.ErrorCode = BadRequest().StatusCode;
        //        aPIError.ErrorMessage = "Username and password are required";
        //        aPIError.ErrorDescription = "Please enter username and password because these fields are mandatory";
        //        return BadRequest(aPIError.ToString());
        //    }

        //    var user = await _unitOfWork.UserRepository.UserAlreadyExists(userReqDTO.Username);
        //    if (user)
        //    {
        //        aPIError.ErrorCode = BadRequest().StatusCode;
        //        aPIError.ErrorMessage = "User already exists please try something else";
        //        aPIError.ErrorDescription = "Please check username you entered is already there please change another one";
        //        return BadRequest(aPIError.ToString());
        //    }

        //    _unitOfWork.UserRepository.Register(userReqDTO);
        //    _unitOfWork.SaveChanges();
        //    return Ok();
        //}
        [ApiExplorerSettings(IgnoreApi = true)]
        public string CreateJWT(User user)
        {
            var secretKey = _configuration.GetSection("AppSettings:Key").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name,user.Username),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            };

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = signingCredentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

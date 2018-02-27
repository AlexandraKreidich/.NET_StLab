using System;
using System.Net;
using System.Threading.Tasks;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using Common.Extensions;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Contracts;
using WebAPI.Models.User;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        private readonly IJWTService _jwtService;

        public AccountController(IUserService userService, IJWTService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        // POST /account/login
        [HttpPost]
        public async Task<IActionResult> Login([NotNull] [FromBody]LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserModel user = await _userService.Login(model.Email, model.Password);

            string token = _jwtService.GenerateJwtToken(user);

            return Ok(new ResponseModel()
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Id = user.Id,
                    Role = user.Role,
                    Token = token
                });
        }

        // POST /account/register
        [HttpPost]
        public ResponseModel Register([NotNull] [FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new ApplicationException("INVALID_MODEL_STATE");
            }

            RegisterUserModel regModel = new RegisterUserModel
            (
                model.Email,
                model.FirstName,
                model.LastName,
                model.Password
            );

            UserModel user = _userService.Register(regModel);

            string token = _jwtService.GenerateJwtToken(user);

            if (token != null)
            {
                return new ResponseModel()
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Id = user.Id,
                    Role = user.Role,
                    Token = token
                };
            }

            throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
        }
    }
}
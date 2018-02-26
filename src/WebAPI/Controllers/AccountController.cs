using System;
using System.Net;
using System.Threading.Tasks;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using LoginModel = WebAPI.Models.LoginModel;
using RegisterModel = WebAPI.Models.RegisterModel;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        // POST /account/login
        [HttpPost]
        public string Login([FromBody]LoginModel model)
        {
            string tokenStr = _userService.Login(model.Email, model.Password);

            if (tokenStr != null)
            {
                return tokenStr;
            }
            else
            {
                throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
            }
        }

        // POST /account/register
        [HttpPost]
        public string Register([FromBody]RegisterModel model)
        {
            BusinessLayer.Models.RegisterModel regModel = new BusinessLayer.Models.RegisterModel()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password
            };

            string newUserToken = _userService.Register(regModel);

            if (newUserToken != null)
            {
                return newUserToken;
            }
            else
            {
                throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
            }
        }
    }
}
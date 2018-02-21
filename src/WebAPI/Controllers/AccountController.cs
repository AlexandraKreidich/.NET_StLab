using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        //private readonly IUserService _userService;


        //public AccountController(IUserService userService)
        //{
        //    _userService = userService;
        //}


        // POST /account/login
        [HttpPost]
        public LoginModel Login([FromBody]LoginModel model)
        {
           // UserDto userDto = _userService.GetUser(model.Login, model.Password);
            return model;
        }

        // POST /account/register
        [HttpPost]
        public RegisterModel Register([FromBody]RegisterModel model)
        {
            return model;
        }
    }
}
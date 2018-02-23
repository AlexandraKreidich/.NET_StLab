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
        public  IActionResult /*async Task<object>*/ Login([FromBody]LoginModel model)
        {

            HttpStatusCode code = _userService.Login(model.Email, model.Password);
            return StatusCode((int)code);

            // var result = await _userService.Login(model.Email, model.Password);
        }

        // POST /account/register
        [HttpPost]
        public UserModel Register([FromBody]RegisterModel model)
        {
            BusinessLayer.Models.RegisterModel regModel = new BusinessLayer.Models.RegisterModel()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password
            };

            UserModel newUser = _userService.Register(regModel);

            // should return token
            return newUser;
        }
    }
}
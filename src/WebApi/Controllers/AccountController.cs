using System.Threading.Tasks;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contracts;
using WebApi.Models.User;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        [NotNull]
        private readonly IUserService _userService;

        [NotNull]
        private readonly IJwtService _jwtService;

        public AccountController([NotNull] IUserService userService, [NotNull] IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        // POST /account/login
        [NotNull]
        [HttpPost]
        public async Task<IActionResult> Login([NotNull] [FromBody]LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserModel user = await _userService.Login(model.Email, model.Password);

            string token = _jwtService.GenerateJwtToken(user);

            return Ok(new ResponseModel
            (
                user.Id,
                user.Role,
                user.FirstName,
                user.LastName,
                user.Email,
                token
            ));
        }

        // POST /account/register
        [NotNull]
        [HttpPost]
        public async Task<IActionResult> Register([NotNull] [FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RegisterUserModel registerUserModel = new RegisterUserModel
            (
                model.Email,
                model.FirstName,
                model.LastName,
                model.Password
            );

            UserModel user = await _userService.Register(registerUserModel);

            string token = _jwtService.GenerateJwtToken(user);

            return Ok(new ResponseModel
                (
                    user.Id,
                    user.Role,
                    user.FirstName,
                    user.LastName,
                    user.Email,
                    token
                ));
        }
    }
}
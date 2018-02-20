using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        // POST /account/login
        [HttpPost]
        public LoginModel Login([FromBody]LoginModel model)
        {
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
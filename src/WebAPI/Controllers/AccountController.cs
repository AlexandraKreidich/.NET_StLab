using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        // GET api/account/login
        [HttpGet]
        public string Login()
        {
            return "login";
        }
    }
}
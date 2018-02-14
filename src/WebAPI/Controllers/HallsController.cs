using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Halls")]
    public class HallsController : Controller
    {
        // POST /halls/{session-id}/hall-scheme
        // POST /halls/{session-id}/places
        // POST /halls/{cinema-id}
        // DELETE /halls/{hall-id}
        // POST /halls/add
        // PUT /halls/add
    }
}
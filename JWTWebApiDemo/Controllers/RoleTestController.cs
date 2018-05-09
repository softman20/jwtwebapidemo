using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTWebApiDemo.Controllers
{
    [Produces("application/json")]
   
    public class RoleTestController : Controller
    {

        [HttpGet]
        [Authorize(Roles ="Administrator", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("api/admin")]
        public IActionResult Get()
        {
            return Ok("hello admin");
        }

        [HttpGet]
        [Authorize(Roles = "Viewer",AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("api/viewer")]
        public IActionResult GetViewer()
        {
            return Ok("hello viewer");
        }
    }
}
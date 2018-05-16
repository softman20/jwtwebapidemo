using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IM.TCM.Api.Controllers
{
    public class HomeController : Controller
    {
        [Route("api/[controller]")]
        public IActionResult Get()
        {
            return Ok("hello");
        }
    }
}
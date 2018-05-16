using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IM.TCM.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IM.TCM.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Role")]
    public class RoleController : Controller
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        public RoleController(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Get()
        {
            var roles =  _roleManager.Roles.Select(e=>new { e.Id, e.Name }).OrderBy(e=>e.Name).ToList();
            return Ok(roles);
        }
    }
}
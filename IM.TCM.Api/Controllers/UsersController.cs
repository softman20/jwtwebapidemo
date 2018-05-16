using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IM.TCM.Domain.Models;
using IM.TCM.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using IM.TCM.Core.Authentication.SaintGobain;
using IM.TCM.Domain.Dtos;
using System.Security.Claims;
using System.Net;

namespace IM.TCM.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
  //  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsersController : Controller
    {
        private readonly IApplicationUserService _applicationUserService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UsersController(RoleManager<ApplicationRole> roleManager, IApplicationUserService applicationUserService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _applicationUserService = applicationUserService;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        // GET: api/Users
        [HttpGet]
        public IActionResult GetUsers()
        {
            //   System.Threading.Thread.Sleep(3000);
            var res = _applicationUserService.GetAllUsers();
            return Ok(res);

        }

        // GET: api/Users/5
        [HttpGet("{sgid}")]
        public  IActionResult GetUser([FromRoute] string sgid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserDto user = _applicationUserService.GetUser(sgid);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [HttpPut("{sgid}")]
        public async Task<IActionResult> PutUser([FromRoute] string sgid, [FromBody] UserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (sgid != user.SgId)
            {
                return BadRequest();
            }

            await _applicationUserService.UpdateUserAsync(user);
            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] UserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //check if user exist
            ApplicationUser userInDb = await _userManager.FindByLoginAsync(SaintGobainDefaults.DisplayName, user.SgId);
            if (userInDb != null)
                return Ok(false);
            else
            {
                UserDto newUser = await _applicationUserService.AddUserAsync(user);

                return Created("", true);
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{sgid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] string sgid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _applicationUserService.DeleteUserAsync(sgid);

            return Ok();
        }


    }
}
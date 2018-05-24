using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IM.TCM.Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IM.TCM.Api.Controllers
{
    /// <summary>
    /// BaseController
    /// </summary>
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// UserId
        /// </summary>
        protected int UserId
        {
            get
            {
                if (User != null)
                {
                    return  Convert.ToInt32(User.FindFirst("ID").Value);
                }
                return 0;
            }
        }

        /// <summary>
        /// UserId
        /// </summary>
        protected string UserSGId
        {
            get
            {
                if (User != null)
                {
                    return User.FindFirst(ClaimTypes.NameIdentifier).Value;
                }
                return string.Empty;
            }
        }

        private readonly UserManager<ApplicationUser> UserManager;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userManager"></param>
        public BaseController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public BaseController()
        {
        }
    }
}
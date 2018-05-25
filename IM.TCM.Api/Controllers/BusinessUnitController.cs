using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IM.TCM.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using IM.TCM.Services.Interfaces;

namespace IM.TCM.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/BusinessUnit")]
    public class BusinessUnitController : BaseController
    {
        private readonly IBusinessUnitService _businessUnitService;
        private readonly IApplicationUserService _applicationUserService;
        public BusinessUnitController(IBusinessUnitService businessUnitService, IApplicationUserService applicationUserService)
        {
            _businessUnitService = businessUnitService;
            _applicationUserService = applicationUserService;
        }

        public IActionResult Get()
        {
            var all = _businessUnitService.GetAll()./*Select(e=>new BusinessUnit {Name=e.Name,Id=e.Id }) .*/OrderBy(e=>e.Name);
            return Ok(all);
        }

        [HttpGet("/api/BusinessUnitByIds")]
        public IActionResult GetByIds([FromQuery] int[] ids)
        {
            var all = _applicationUserService.GetUserBUWithRolesByIDs(UserId, ids);
            return Ok(all);
        }
    }
}
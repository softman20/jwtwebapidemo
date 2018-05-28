using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IM.TCM.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using IM.TCM.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using IM.TCM.Domain.Dtos;

namespace IM.TCM.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/AccountGroup")]
    public class AccountGroupController : BaseController
    {
        private readonly IAccountGroupService _accountGroupService;
        public AccountGroupController(IAccountGroupService accountGroupService)
        {
            _accountGroupService = accountGroupService;
        }

        [HttpGet("{businessUnitId}/{processTypeId}")]
        public IActionResult Get(int businessUnitId, int processTypeId)
        {
            var all = _accountGroupService.GetAccountGroupsByBUAndProcessType(businessUnitId,processTypeId).Select(e=> new MasterDto { Id = e.Id, Name = e.Name });
            return Ok(all);
        }

        
        [HttpGet("GetByBU/{businessUnitId}")]
        public IActionResult GetByBU(int businessUnitId)
        {
        
            var all = _accountGroupService.GetAccountGroupsByBU(businessUnitId);
            return Ok(all);
        }

        [HttpGet("/api/CompanyById")]
        public IActionResult GetById(int id)
        {
              return Ok();
        }
    }
}
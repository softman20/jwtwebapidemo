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
    [Route("api/ValidationRule")]
    public class ValidationRuleController : BaseController
    {
        private readonly IValidationRuleService _validationRuleService;
        public ValidationRuleController(IValidationRuleService validationRuleService)
        {
            _validationRuleService = validationRuleService;
        }

        [HttpPost("GetUsers")]       
        public IActionResult GetValidationRulePotentielUsers([FromBody] ValidationRuleDto validationRule)
        {
            var all = _validationRuleService.GetValidationRulePotentielUsers(validationRule);
            return Ok(all);
        }

        
        [HttpGet("GetByBU/{businessUnitId}")]
        public IActionResult GetByBU(int businessUnitId)
        {
        
            //var all = _validationRuleService.GetAccountGroupsByBU(businessUnitId);
            return Ok();
        }

        [HttpGet("/api/CompanyById")]
        public IActionResult GetById(int id)
        {
              return Ok();
        }
    }
}
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

        [HttpPost("GetValidationRuleUserRoles")]
        public IActionResult GetValidationRuleUserRoles([FromBody] ValidationRuleDto validationRule)
        {
            var all = _validationRuleService.GetValidationRuleUserRoles(validationRule);
            return Ok(all);
        }

        [HttpPost]
        public IActionResult PostValidationRule([FromBody] ValidationRuleDto validationRule)
        {
            int id = _validationRuleService.AddValidationRule(validationRule);
            return Ok(id);
        }

        [HttpPost("AddFromCopy")]
        public IActionResult AddValidationRuleFromCopy([FromBody] ValidationRuleCopyFromDto validationRules)
        {
            int id = _validationRuleService.AddValidationRuleFromCopy(validationRules.ValidationRule, validationRules.ValidationRuleCopyFrom);
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteValidationRule([FromRoute] int id)
        {
            _validationRuleService.Delete(id);
            return Ok();
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
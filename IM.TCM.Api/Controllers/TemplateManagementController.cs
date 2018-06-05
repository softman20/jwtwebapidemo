using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IM.TCM.Domain.Dtos;
using IM.TCM.Domain.Models;
using IM.TCM.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IM.TCM.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/TemplateManagement")]
    public class TemplateManagementController : Controller
    {
        private readonly ITemplateManagementService _templateManagementService;
        public TemplateManagementController(ITemplateManagementService templateManagementService)
        {
            _templateManagementService = templateManagementService;
        }

        public IActionResult Get()
        {
            var all = _templateManagementService.GetAll();
            return Ok(all);
        }

        [HttpPost]
        public IActionResult GetTemplateControls([FromBody] SelectionCriteriaDto selectionCriteria)
        {
            var result = _templateManagementService.GetTemplateControls(selectionCriteria);
            return Ok(result);
        }

        [HttpPost("AddNewTemplate")]
        public IActionResult AddNewTemplate([FromBody] SelectionCriteriaDto selectionCriteria)
        {
            var result = _templateManagementService.AddNewTemplate(selectionCriteria);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateTemplate([FromBody] IEnumerable<TemplateControlDto> templateControls)
        {
            var result = _templateManagementService.UpdateTemplate(templateControls);
            return Ok(result);
        }
    }
}
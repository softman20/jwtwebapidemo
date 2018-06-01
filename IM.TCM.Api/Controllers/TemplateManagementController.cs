using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly ITemplateControlService _templateControlService;
        public TemplateManagementController(ITemplateControlService templateControlService)
        {
            _templateControlService = templateControlService;
        }

        public IActionResult Get()
        {
            var all = _templateControlService.GetAll();
            return Ok(all);
        }
    }
}
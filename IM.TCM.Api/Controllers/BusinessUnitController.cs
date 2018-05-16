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
    public class BusinessUnitController : Controller
    {
        private readonly IBusinessUnitService _businessUnitService;
        public BusinessUnitController(IBusinessUnitService businessUnitService)
        {
            _businessUnitService = businessUnitService;
        }

        public IActionResult Get()
        {
            var all = _businessUnitService.GetAll().Select(e=>new BusinessUnit {Name=e.Name,Id=e.Id }) .OrderBy(e=>e.Name);
            return Ok(all);
        }

        [HttpGet("/api/BusinessUnitByIds")]
        public IActionResult GetByIds([FromQuery] int[] ids)
        {
            var all = _businessUnitService.GetAll().Where(e=> ids.Any(o=>o==e.Id)).Select(e => new BusinessUnit { Name = e.Name, Id = e.Id }).OrderBy(e => e.Name);
            return Ok(all);
        }
    }
}
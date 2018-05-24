﻿using System;
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
    [Route("api/Company")]
    public class CompanyController : BaseController
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("{businessUnitId}/{processTypeId}")]
        public IActionResult Get(int businessUnitId, int processTypeId)
        {
            var all = _companyService.GetCompaniesByBUAndProcessType(UserId, businessUnitId,processTypeId).Select(e=> new MasterDto { Id = e.Id, Name = e.Name });
            return Ok(all);
        }

        
        [HttpGet("GetByBU/{businessUnitId}")]
        public IActionResult GetByBU(int businessUnitId)
        {
        
            var all = _companyService.GetCompaniesByBU(businessUnitId);
            return Ok(all);
        }

        [HttpGet("/api/CompanyById")]
        public IActionResult GetById(int id)
        {
              return Ok();
        }
    }
}
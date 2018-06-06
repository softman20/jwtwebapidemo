using Microsoft.AspNetCore.Mvc;
using IM.TCM.Services.Interfaces;

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
            var all = _companyService.GetCompaniesByBUAndProcessType(UserId, businessUnitId,processTypeId);
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
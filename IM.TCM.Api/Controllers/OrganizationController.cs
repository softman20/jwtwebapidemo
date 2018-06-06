using System.Linq;
using Microsoft.AspNetCore.Mvc;
using IM.TCM.Services.Interfaces;

namespace IM.TCM.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Organization")]
    public class OrganizationController :BaseController
    {
        private readonly IOrganizationService _organizationService;
        private readonly IApplicationUserService _applicationUserService;
        public OrganizationController(IOrganizationService organizationService, IApplicationUserService applicationUserService)
        {
            _organizationService = organizationService;
            _applicationUserService = applicationUserService;
        }
        [HttpGet("{businessUnitId}/{processTypeId}")]
        public IActionResult Get([FromRoute] int businessUnitId, int processTypeId)
        {
            var all = _organizationService.GetAll().Where(e=>e.BusinessUnitId== businessUnitId && (e.ProcessTypeId== processTypeId || e.ProcessTypeId==-1));
            return Ok(all);
        }

        
    }
}
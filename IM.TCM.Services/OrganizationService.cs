

using IM.TCM.Data.Repositories.Interfaces;
using IM.TCM.Domain.Models;
using IM.TCM.Services.Interfaces;
using System.Collections.Generic;

namespace IM.TCM.Services
{
    public class OrganizationService : BaseService<SalesOrganization>, IOrganizationService
    {
      //  private readonly IBaseRepository<UserOrganization> _userOrganizationRepository;
        public OrganizationService(IOrganizationRepository organizationRepository) : base(organizationRepository)
        {
           // _userOrganizationRepository = userOrganizationRepository;
        }
       
        

    }
}

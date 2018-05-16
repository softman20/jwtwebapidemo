

using IM.TCM.Data.Repositories.Interfaces;
using IM.TCM.Domain.Models;
using IM.TCM.Services.Interfaces;
using System.Collections.Generic;

namespace IM.TCM.Services
{
    public class BusinessUnitService : BaseService<BusinessUnit>, IBusinessUnitService
    {
      //  private readonly IBaseRepository<UserBusinessUnit> _userBusinessUnitRepository;
        public BusinessUnitService(IBusinessUnitRepository businessUnitRepository) : base(businessUnitRepository)
        {
           // _userBusinessUnitRepository = userBusinessUnitRepository;
        }
       
        

    }
}

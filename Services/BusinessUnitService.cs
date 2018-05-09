

using Data.Repositories.Interfaces;
using Domain.Models;
using Services.Interfaces;
using System.Collections.Generic;

namespace Services
{
    public class BusinessUnitService : BaseService<BusinessUnit>, IBusinessUnitService
    {
      //  private readonly IBaseRepository<UserBusinessUnit> _userBusinessUnitRepository;
        public BusinessUnitService(IBaseRepository<BusinessUnit> businessUnitRepository) : base(businessUnitRepository)
        {
           // _userBusinessUnitRepository = userBusinessUnitRepository;
        }
       
        

    }
}



using IM.TCM.Data.Repositories.Interfaces;
using IM.TCM.Domain.Models;
using IM.TCM.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace IM.TCM.Services
{
    public class CompanyService : BaseService<Company>, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository) : base(companyRepository)
        {
            _companyRepository = companyRepository;
        }
       
        public IEnumerable<Company> GetCompaniesByBUAndProcessType(int businessUnitId,int processTypeId)
        {
            return _companyRepository.GetQuery().Where(c=>c.BusinessUnitId==businessUnitId && c.CompanyProcessTypes.Any(e=>e.ProcessTypeId== processTypeId));
        }
        

    }
}

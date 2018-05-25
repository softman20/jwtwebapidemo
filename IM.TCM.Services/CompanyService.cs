

using IM.TCM.Data.Enums;
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
        private readonly IUserAuthorizationRepository _userAuthorizationRepository;
        public CompanyService(ICompanyRepository companyRepository, IUserAuthorizationRepository userAuthorizationRepository) : base(companyRepository)
        {
            _companyRepository = companyRepository;
            _userAuthorizationRepository = userAuthorizationRepository;
        }

        public IEnumerable<Company> GetCompaniesByBUAndProcessType(int userId, int businessUnitId, int processTypeId)
        {
            IEnumerable<int> authorizedCompanies = _userAuthorizationRepository.Find(where: e => e.UserId == userId && e.RoleId==(int)Roles.Administrator && (e.BUId == businessUnitId)
             && (e.ProcessTypeId == processTypeId || e.ProcessTypeId == -1))
            .Select(e => e.CompanyId);

            //if All(-1) authrorized get all companies of BU
            if (authorizedCompanies.Contains(-1))
                return _companyRepository.Find(where: e => e.BusinessUnitId==businessUnitId && e.Id!=-1);
            else return _companyRepository.Find(where: e => e.BusinessUnitId==businessUnitId && authorizedCompanies.Contains(e.Id));
        }

        public IEnumerable<Company> GetCompaniesByBU(int businessUnitId)
        {
            return _companyRepository.GetQuery().Where(c => c.BusinessUnitId == businessUnitId || c.BusinessUnitId == -1);
        }

    }
}

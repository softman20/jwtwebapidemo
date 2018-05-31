

using AutoMapper;
using IM.TCM.Data.Enums;
using IM.TCM.Data.Repositories.Interfaces;
using IM.TCM.Domain.Dtos;
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
        private readonly IMapper _mapper;
        public CompanyService(IMapper mapper, ICompanyRepository companyRepository, IUserAuthorizationRepository userAuthorizationRepository) : base(companyRepository)
        {
            _companyRepository = companyRepository;
            _userAuthorizationRepository = userAuthorizationRepository;
            _mapper = mapper;
        }

        public IEnumerable<MasterDto> GetCompaniesByBUAndProcessType(int userId, int businessUnitId, int processTypeId)
        {
            IEnumerable<Company> lstCompanies;
            IEnumerable<int> authorizedCompanies = _userAuthorizationRepository.Find(where: e => e.UserId == userId && e.RoleId==(int)Roles.Administrator && (e.BUId == businessUnitId || e.BUId==-1)
             && (e.ProcessTypeId == processTypeId || e.ProcessTypeId == -1))
            .Select(e => e.CompanyId);

            //if All(-1) authrorized get all companies of BU
            if (authorizedCompanies.Contains(-1))
                lstCompanies= _companyRepository.Find(where: e => e.BusinessUnitId==businessUnitId && e.Id!=-1);
            else lstCompanies= _companyRepository.Find(where: e => e.BusinessUnitId==businessUnitId && authorizedCompanies.Contains(e.Id));

            return _mapper.Map<IEnumerable<Company>, IEnumerable<MasterDto>>(lstCompanies);
        }

        public IEnumerable<Company> GetCompaniesByBU(int businessUnitId)
        {
            return _companyRepository.GetQuery().Where(c => c.BusinessUnitId == businessUnitId || c.BusinessUnitId == -1);
        }

    }
}

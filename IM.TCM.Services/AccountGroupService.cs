

using IM.TCM.Data.Enums;
using IM.TCM.Data.Repositories.Interfaces;
using IM.TCM.Domain.Models;
using IM.TCM.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace IM.TCM.Services
{
    public class AccountGroupService : BaseService<AccountGroup>, IAccountGroupService
    {
        private readonly IAccountGroupRepository _accountGroupRepository;
        private readonly IUserAuthorizationRepository _userAuthorizationRepository;
        public AccountGroupService(IAccountGroupRepository accountGroupRepository, IUserAuthorizationRepository userAuthorizationRepository) : base(accountGroupRepository)
        {
            _accountGroupRepository = accountGroupRepository;
            _userAuthorizationRepository = userAuthorizationRepository;
        }

        public IEnumerable<AccountGroup> GetAccountGroupsByBUAndProcessType(int businessUnitId, int processTypeId)
        {
           return _accountGroupRepository.Find(include:e=>e.Include(p=>p.AccountGroupProcessType), where: e => e.BusinessUnitId==businessUnitId && e.AccountGroupProcessType.Any(ag=>ag.ProcessTypeId==processTypeId));
        }

        public IEnumerable<AccountGroup> GetAccountGroupsByBU(int businessUnitId)
        {
            return _accountGroupRepository.GetQuery().Where(c => c.BusinessUnitId == businessUnitId || c.BusinessUnitId == -1);
        }

    }
}

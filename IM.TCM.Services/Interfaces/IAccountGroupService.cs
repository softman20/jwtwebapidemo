using IM.TCM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IM.TCM.Services.Interfaces
{
    public interface IAccountGroupService : IBaseService<AccountGroup>
    {
        IEnumerable<AccountGroup> GetAccountGroupsByBUAndProcessType(int businessUnitId,int processTypeId);
        IEnumerable<AccountGroup> GetAccountGroupsByBU(int businessUnitId);
    }
}

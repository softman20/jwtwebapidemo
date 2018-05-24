using IM.TCM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IM.TCM.Services.Interfaces
{
    public interface ICompanyService : IBaseService<Company>
    {
        IEnumerable<Company> GetCompaniesByBUAndProcessType(int userId,int businessUnitId,int processTypeId);
        IEnumerable<Company> GetCompaniesByBU(int businessUnitId);
    }
}

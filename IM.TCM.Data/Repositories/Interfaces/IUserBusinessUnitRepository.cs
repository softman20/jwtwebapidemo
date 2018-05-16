using IM.TCM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IM.TCM.Data.Repositories.Interfaces
{
    public interface IUserBusinessUnitRepository : IBaseRepository<UserBusinessUnit>
    {
        void AddBusinessUnitToUser(int userId, IEnumerable<string> buIds,bool deleteCurrent=false);
    }
}

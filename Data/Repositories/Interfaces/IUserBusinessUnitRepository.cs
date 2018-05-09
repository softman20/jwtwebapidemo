using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories.Interfaces
{
    public interface IUserBusinessUnitRepository : IBaseRepository<UserBusinessUnit>
    {
        void AddBusinessUnitToUser(int userId, IEnumerable<string> buIds,bool deleteCurrent=false);
    }
}

using IM.TCM.Data.EF;
using IM.TCM.Data.Repositories.Interfaces;
using IM.TCM.Domain.Models;

namespace IM.TCM.Data.Repositories
{
    public class AccountGroupRepository : BaseRepository<AccountGroup>, IAccountGroupRepository
    {
        public AccountGroupRepository(TCMContext context) : base(context)
        {

        }

      
    }
}

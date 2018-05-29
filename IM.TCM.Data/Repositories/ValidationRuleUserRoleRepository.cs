using IM.TCM.Data.EF;
using IM.TCM.Data.Repositories.Interfaces;
using IM.TCM.Domain.Models;

namespace IM.TCM.Data.Repositories
{
    public class ValidationRuleUserRoleRepository : BaseRepository<ValidationRuleUserRole>, IValidationRuleUserRoleRepository
    {
        public ValidationRuleUserRoleRepository(TCMContext context) : base(context)
        {

        }

      
    }
}

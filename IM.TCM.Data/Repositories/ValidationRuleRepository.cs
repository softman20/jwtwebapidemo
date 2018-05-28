using IM.TCM.Data.EF;
using IM.TCM.Data.Repositories.Interfaces;
using IM.TCM.Domain.Models;

namespace IM.TCM.Data.Repositories
{
    public class ValidationRuleRepository : BaseRepository<ValidationRule>, IValidationRuleRepository
    {
        public ValidationRuleRepository(TCMContext context) : base(context)
        {

        }

      
    }
}

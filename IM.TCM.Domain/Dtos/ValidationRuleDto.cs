using System.Collections.Generic;

namespace IM.TCM.Domain.Dtos
{
    public class ValidationRuleDto : SelectionCriteriaDto
    {
        public IEnumerable<ValidationRuleUserRoleDto> ValidationRuleUserRoles { get; set; }       
    }
}

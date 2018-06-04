using IM.TCM.Domain.Dtos;
using IM.TCM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IM.TCM.Services.Interfaces
{
    public interface IValidationRuleService : IBaseService<ValidationRule>
    {
        IEnumerable<UserDto> GetValidationRulePotentielUsers(ValidationRuleDto validationRule);
        int AddValidationRule(ValidationRuleDto validationRule);
        int AddValidationRuleFromCopy(ValidationRuleDto validationRule, ValidationRuleDto validationRuleToCompyFrom);
        IEnumerable<ValidationRuleUserRoleDto> GetValidationRuleUserRoles(ValidationRuleDto validationRule);
    }
}

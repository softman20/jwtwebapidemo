using IM.TCM.Domain.Models;

namespace IM.TCM.Domain.Dtos
{
    public class ValidationRuleUserRoleDto
    {
        public int ValidationRuleId { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }

        public ValidationRuleDto ValidationRule { get; set; }
 
        public UserDto User { get; set; }
       
        public MasterDto Role { get; set; }
    }
}

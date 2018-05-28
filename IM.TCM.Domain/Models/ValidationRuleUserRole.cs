using IM.TCM.Domain.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace IM.TCM.Domain.Models
{
    public  class ValidationRuleUserRole:BaseEntity
    {
        public int ValidationRuleId { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }

        [ForeignKey("ValidationRuleId")]
        public virtual ValidationRule ValidationRule { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("RoleId")]
        public virtual ApplicationRole Role { get; set; }
    }
}

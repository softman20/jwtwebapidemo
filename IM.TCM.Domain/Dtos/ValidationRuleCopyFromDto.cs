using System;
using System.Collections.Generic;
using System.Text;

namespace IM.TCM.Domain.Dtos
{
   public class ValidationRuleCopyFromDto
    {
        public ValidationRuleDto ValidationRule { get; set; }
        public ValidationRuleDto ValidationRuleCopyFrom { get; set; }
    }
}

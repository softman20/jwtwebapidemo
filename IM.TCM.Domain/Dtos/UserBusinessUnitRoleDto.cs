using System;
using System.Collections.Generic;
using System.Text;

namespace IM.TCM.Domain.Dtos
{
   public class UserBusinessUnitRoleDto
    {
        public BusinessUnitDto BusinessUnit { get; set; }
        public MasterDto Role { get; set; }
    }
}

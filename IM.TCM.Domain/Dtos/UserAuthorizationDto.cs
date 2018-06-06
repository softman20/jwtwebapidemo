using IM.TCM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IM.TCM.Domain.Dtos
{
    public class UserAuthorizationDto
    {
        public int UserId { get; set; }
        public int BUId { get; set; }
        public int RoleId { get; set; }
        public int CompanyId { get; set; }
        public int ProcessTypeId { get; set; }
        
        public BusinessUnitDto BusinessUnit { get; set; }

        public MasterDto Role { get; set; }

        public MasterDto CompanyCode { get; set; }

        public MasterDto ProcessType { get; set; }

        public MasterDto Organization { get; set; }
    }
}

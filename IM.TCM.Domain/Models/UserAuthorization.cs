using System;
using System.Collections.Generic;
using System.Text;

namespace IM.TCM.Domain.Models
{
    public class UserAuthorization
    {
        public int UserId { get; set; }
        public int BUId { get; set; }
        public int RoleId { get; set; }
        public int CompanyId { get; set; }
        public int ProcessTypeId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual BusinessUnit BusinessUnit { get; set; }

        public virtual ApplicationRole Role { get; set; }

        public virtual Company CompanyCode { get; set; }

        public virtual ProcessType ProcessType { get; set; }
    }
}

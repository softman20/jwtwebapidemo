using System;
using System.Collections.Generic;
using System.Text;

namespace IM.TCM.Domain.Models
{
    public class CompanyProcessType
    {
        public int CompanyId { get; set; }
        public int ProcessTypeId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ProcessType ProcessType { get; set; }
    }
}

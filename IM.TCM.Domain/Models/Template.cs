using IM.TCM.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace IM.TCM.Domain.Models
{
    public class Template:BaseEntity
    {
        public int BUId { get; set; }
        public int AccountGroupId { get; set; }
        public int CompanyId { get; set; }
        public int ProcessTypeId { get; set; }
       

        public virtual BusinessUnit BusinessUnit { get; set; }

        public virtual AccountGroup AccountGroup { get; set; }

        public virtual Company CompanyCode { get; set; }

        public virtual ProcessType ProcessType { get; set; }
        
    }
}

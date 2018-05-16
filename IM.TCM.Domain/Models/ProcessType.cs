using IM.TCM.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace IM.TCM.Domain.Models
{
    public class ProcessType:BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<CompanyProcessType> CompanyProcessTypes { get; set; }
    }
}

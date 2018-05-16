using IM.TCM.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IM.TCM.Domain.Models
{
    public class Company : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int BusinessUnitId { get; set; }
        
        public virtual ICollection<CompanyProcessType> CompanyProcessTypes { get;set;}

        [ForeignKey("BusinessUnitId")]
        public virtual BusinessUnit BusinessUnit { get; set; }
    }
}

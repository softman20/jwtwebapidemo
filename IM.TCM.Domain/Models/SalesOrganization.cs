using IM.TCM.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IM.TCM.Domain.Models
{
    public class SalesOrganization:BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int BusinessUnitId { get; set; }
        public int ProcessTypeId { get; set; }

        [ForeignKey("BusinessUnitId")]
        public virtual BusinessUnit BusinessUnit { get; set; }
        [ForeignKey("ProcessTypeId")]
        public virtual ProcessType ProcessType { get; set; }

        public virtual ICollection<UserAuthorization> UserAuthorizations { get; set; }

        public virtual ICollection<ValidationRule> ValidationRules { get; set; }

        public virtual ICollection<Template> Templates { get; set; }
    }
}

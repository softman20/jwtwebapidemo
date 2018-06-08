using IM.TCM.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IM.TCM.Domain.Models
{
    public class ControlMasterData : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public int ProcessTypeId { get; set; }
        public int BUId { get; set; }
        public int TemplateControlId { get; set; }

        [ForeignKey("ProcessTypeId")]
        public virtual ProcessType ProcessType { get; set; }
        [ForeignKey("BUId")]
        public virtual BusinessUnit BusinessUnit { get; set; }
        [ForeignKey("TemplateControlId")]
        public virtual TemplateControl TemplateControl { get; set; }
    }
}

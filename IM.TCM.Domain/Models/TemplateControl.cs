using IM.TCM.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IM.TCM.Domain.Models
{
    public class TemplateControl:BaseEntity
    {
        public string Label { get; set; }
        public string SapTable { get; set; }
        public string SapField { get; set; }

        public int ProcessTypeId { get; set; }
        public int BUId { get; set; }

        [ForeignKey("ProcessTypeId")]
        public virtual ProcessType ProcessType { get; set; }
        [ForeignKey("BUId")]
        public virtual BusinessUnit BusinessUnit { get; set; }
    }
}

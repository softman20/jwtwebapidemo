using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IM.TCM.Domain.Models
{
   public class TemplateControlConfig
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool Mandatory { get; set; }
        public bool Display { get; set; }
        public bool Capital { get; set; }
        public bool AlterableProvider { get; set; }
        public bool AlterableApprover1 { get; set; }
        public bool AlterableApprover2 { get; set; }
        public bool AlterableApprover3 { get; set; }
        public string DefaultValue { get; set; }
        public int ControlTypeId { get; set; }


        public int TemplateId { get; set; }
        public int TemplateControlId { get; set; }

        [ForeignKey("TemplateId")]
        public virtual Template Template { get; set; }

        [ForeignKey("TemplateControlId")]
        public virtual TemplateControl TemplateControl { get; set; }

        [ForeignKey("ControlTypeId")]
        public virtual ControlType ControlType { get; set; }
    }
}

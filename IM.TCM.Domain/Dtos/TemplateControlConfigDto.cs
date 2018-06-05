using IM.TCM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IM.TCM.Domain.Dtos
{
    public class TemplateControlConfigDto
    {
        public int Id { get; set; }
        public bool Mandatory { get; set; }
        public bool Display { get; set; }
        public bool Capital { get; set; }
        public bool AlterableProvider { get; set; }
        public bool AlterableApprover1 { get; set; }
        public bool AlterableApprover2 { get; set; }
        public bool AlterableApprover3 { get; set; }
        public string DefaultValue { get; set; }



        public int TemplateId { get; set; }
        public int TemplateControlId { get; set; }

        public TemplateControlConfigDto(int templateId,int templateControlId)
        {
            this.Mandatory = false;
            this.Display = false;
            this.Capital = false;
            this.AlterableProvider = false;
            this.AlterableApprover1 = false;
            this.AlterableApprover2 = false;
            this.AlterableApprover3 = false;
            this.DefaultValue = string.Empty;

            this.TemplateId = templateId;
            this.TemplateControlId = templateControlId;
        }
        
    }
}

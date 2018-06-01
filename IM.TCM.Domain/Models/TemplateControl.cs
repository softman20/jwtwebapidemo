using IM.TCM.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace IM.TCM.Domain.Models
{
    public class TemplateControl:BaseEntity
    {
        public string Label { get; set; }
        public string SapTable { get; set; }
        public string SapField { get; set; }
    }
}

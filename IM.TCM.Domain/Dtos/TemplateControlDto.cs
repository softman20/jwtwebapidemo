using IM.TCM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IM.TCM.Domain.Dtos
{
   public class TemplateControlDto
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string SapTable { get; set; }
        public string SapField { get; set; }

        public int ProcessTypeId { get; set; }
        public int BUId { get; set; }

        public TemplateControlConfigDto TemplateControlConfig { get; set; }
    }
}

using IM.TCM.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace IM.TCM.Domain.Dtos
{
    public class BusinessUnitDto 
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Roles { get; set; }
         
    }
}

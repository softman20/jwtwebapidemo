using System;
using System.Collections.Generic;
using System.Text;

namespace IM.TCM.Domain.Dtos
{
    public class SelectionCriteriaDto
    {
        public int Id { get; set; }
        public int BUId { get; set; }
        public int AccountGroupId { get; set; }
        public int CompanyId { get; set; }
        public int ProcessTypeId { get; set; }
        public int RequestTypeId { get; set; }
        
        public BusinessUnitDto BusinessUnit { get; set; }

        public MasterDto AccountGroup { get; set; }

        public MasterDto CompanyCode { get; set; }

        public MasterDto ProcessType { get; set; }

        public MasterDto RequestType { get; set; }
    }
}

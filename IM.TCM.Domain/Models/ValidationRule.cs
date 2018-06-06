using IM.TCM.Domain.Models.Common;

namespace IM.TCM.Domain.Models
{
    public class ValidationRule:BaseEntity
    {
        public int BUId { get; set; }
        public int AccountGroupId { get; set; }
        public int CompanyId { get; set; }
        public int ProcessTypeId { get; set; }
        public int RequestTypeId { get; set; }
        public int OrganizationId { get; set; }

        public virtual BusinessUnit BusinessUnit { get; set; }

        public virtual AccountGroup AccountGroup { get; set; }

        public virtual Company CompanyCode { get; set; }

        public virtual ProcessType ProcessType { get; set; }

        public virtual RequestType RequestType { get; set; }

        public virtual SalesOrganization Organization { get; set; }
    }
}

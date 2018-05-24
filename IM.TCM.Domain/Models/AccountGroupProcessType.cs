namespace IM.TCM.Domain.Models
{
    public class AccountGroupProcessType
    {       
        public int AccountGroupId { get; set; }
        public int ProcessTypeId { get; set; }

        public virtual AccountGroup AccountGroup { get; set; }
        public virtual ProcessType ProcessType { get; set; }
    }
}

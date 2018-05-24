using IM.TCM.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IM.TCM.Domain.Models
{
    public class ProcessType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CompanyProcessType> CompanyProcessTypes { get; set; }

        public virtual ICollection<AccountGroupProcessType> AccountGroupProcessType { get; set; }

        public virtual ICollection<UserAuthorization> UserAuthorizations { get; set; }
    }
}

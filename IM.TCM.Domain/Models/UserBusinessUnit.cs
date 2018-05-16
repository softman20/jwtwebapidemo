using System;
using System.Collections.Generic;
using System.Text;

namespace IM.TCM.Domain.Models
{
   public class UserBusinessUnit
    {
        public int UserId { get; set; }
        public int BUId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual BusinessUnit BusinessUnit { get; set; }
    }
}

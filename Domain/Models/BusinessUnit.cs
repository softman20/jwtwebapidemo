using Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
   public class BusinessUnit:BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserBusinessUnit> UserBusinessUnits { get; set; }
    }
}

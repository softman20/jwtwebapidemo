using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class ApplicationUserRole : IdentityUserRole<int>
    {
        public ApplicationUserRole()
            : base()
        { }

        //public override int UserId { get; set; }
        //public override int RoleId { get; set; }

        
        public virtual ApplicationUser User { get; set; }
        //[ForeignKey("RoleId")]
        public virtual ApplicationRole Role { get; set; }
    }
}

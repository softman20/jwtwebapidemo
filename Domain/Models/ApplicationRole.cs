using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class ApplicationRole : IdentityRole<int>
    {

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
     //   public ApplicationUser User { get; set; }
    }
}

﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IM.TCM.Domain.Models
{
    public class ApplicationRole : IdentityRole<int>
    {

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }

        public virtual ICollection<UserAuthorization> UserAuthorizations { get; set; }
        //   public ApplicationUser User { get; set; }
    }
}

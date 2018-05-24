using IM.TCM.Domain.Dtos;
using IM.TCM.Domain.Models.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IM.TCM.Domain.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        [Required]
        [StringLength(20)]
        public string SgId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }

        public virtual ICollection<UserBusinessUnit> UserBusinessUnits { get; set; }
        public virtual ICollection<UserAuthorization> Authorizations { get; set; }

    }
}

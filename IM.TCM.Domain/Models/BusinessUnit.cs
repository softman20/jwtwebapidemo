using IM.TCM.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IM.TCM.Domain.Models
{
   public class BusinessUnit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserBusinessUnit> UserBusinessUnits { get; set; }
        public virtual ICollection<UserAuthorization> UserAuthorizations { get; set; }
        public virtual ICollection<ValidationRule> ValidationRules { get; set; }
        public virtual ICollection<Template> Templates { get; set; }
    }
}

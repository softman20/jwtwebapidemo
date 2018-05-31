using IM.TCM.Domain.Models;
using IM.TCM.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace IM.TCM.Domain.Dtos
{
    public class UserDto: BaseEntity
    {
      //  public int Id { get; set; }
        public string SgId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public bool ValidAvatar { get; set; }
        public bool IsSuperAdmin { get; set; }
        public ICollection<string> Roles { get; set; }
        public ICollection<BusinessUnit> BusinessUnits { get; set; }
        public ICollection<string> BusinessUnitsId { get; set; }

        public ICollection<UserAuthorizationDto> Authorizations { get; set; }
    }
}

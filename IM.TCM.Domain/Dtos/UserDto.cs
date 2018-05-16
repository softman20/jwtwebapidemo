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
        public IEnumerable<string> Roles { get; set; }
        public IEnumerable<BusinessUnit> BusinessUnits { get; set; }
        public IEnumerable<string> BusinessUnitsId { get; set; }
    }
}

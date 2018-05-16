using IM.TCM.Data.EF;
using IM.TCM.Data.Repositories.Interfaces;
using IM.TCM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IM.TCM.Data.Repositories
{
    public class BusinessUnitRepository: BaseRepository<BusinessUnit>,IBusinessUnitRepository
    {
        public BusinessUnitRepository(TCMContext context) : base(context)
        {

        }

      
    }
}

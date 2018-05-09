using Data.EF;
using Data.Repositories.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class BusinessUnitRepository: BaseRepository<BusinessUnit>,IBusinessUnitRepository
    {
        public BusinessUnitRepository(JWTDemoContext context) : base(context)
        {

        }

      
    }
}

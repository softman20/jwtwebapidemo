using IM.TCM.Data.EF;
using IM.TCM.Data.Repositories.Interfaces;
using IM.TCM.Domain.Dtos;
using IM.TCM.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IM.TCM.Data.Repositories
{
    public class ApplicationUserRepository : BaseRepository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(TCMContext context) : base(context)
        {

        }

       

       
    }
}

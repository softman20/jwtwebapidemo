using Data.EF;
using Data.Repositories.Interfaces;
using Domain.Dtos;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class ApplicationUserRepository : BaseRepository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(JWTDemoContext context) : base(context)
        {

        }

       

       
    }
}

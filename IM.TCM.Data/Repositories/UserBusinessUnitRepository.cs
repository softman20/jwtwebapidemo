using IM.TCM.Data.EF;
using IM.TCM.Data.Repositories.Interfaces;
using IM.TCM.Domain.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace IM.TCM.Data.Repositories
{
    public class UserBusinessUnitRepository: BaseRepository<UserBusinessUnit>, IUserBusinessUnitRepository
    {
        public UserBusinessUnitRepository(TCMContext context) : base(context)
        {

        }

        public void AddBusinessUnitToUser(int userId, IEnumerable<string> BUs,bool deleteCurrent=false)
        {
            try
            {
                if (deleteCurrent)
                    this.Context.UserBusinessUnit.RemoveRange(this.DbSet.Where(e => e.UserId == userId));
                this.Context.SaveChanges();
                foreach (var bu in BUs)
                {
                    this.Context.Add(new UserBusinessUnit { UserId = userId, BUId = Convert.ToInt32(bu) });
                }
                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

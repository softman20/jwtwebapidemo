

using IM.TCM.Data.Repositories.Interfaces;
using IM.TCM.Domain.Models;
using IM.TCM.Services.Interfaces;
using System.Collections.Generic;

namespace IM.TCM.Services
{
    public class TemplateControlService : BaseService<TemplateControl>, ITemplateControlService
    {
      //  private readonly IBaseRepository<UserBusinessUnit> _userBusinessUnitRepository;
        public TemplateControlService(ITemplateControlRepository templateControlRepository) : base(templateControlRepository)
        {
           // _userBusinessUnitRepository = userBusinessUnitRepository;
        }
       
        

    }
}

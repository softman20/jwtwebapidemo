

using IM.TCM.Data.Repositories.Interfaces;
using IM.TCM.Domain.Dtos;
using IM.TCM.Domain.Models;
using IM.TCM.Services.Interfaces;
using System.Collections.Generic;

namespace IM.TCM.Services
{
    public class TemplateControlService : BaseService<TemplateControl>, ITemplateControlService
    {
        private readonly ITemplateControlRepository _templateControlRepository;
        private readonly ITemplateRepository _templateRepository;
        public TemplateControlService(ITemplateControlRepository templateControlRepository, ITemplateRepository templateRepository) : base(templateControlRepository)
        {
            _templateControlRepository = templateControlRepository;
            _templateRepository = templateRepository;
        }
       
        public IEnumerable<TemplateControl> GetTemplateControls(SelectionCriteriaDto selectionCriteria)
        {
            return _templateControlRepository.Find(e => e.BUId == selectionCriteria.BusinessUnit.Id && e.ProcessTypeId == e.ProcessTypeId);
        }

    }
}

using IM.TCM.Data.EF;
using IM.TCM.Data.Repositories.Interfaces;
using IM.TCM.Domain.Models;
using System.Linq;
using System.Collections.Generic;
using IM.TCM.Domain.Dtos;
using AutoMapper;

namespace IM.TCM.Data.Repositories
{
    public class TemplateControlRepository : BaseRepository<TemplateControl>, ITemplateControlRepository
    {
        private readonly IMapper _mapper;
        public TemplateControlRepository(TCMContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public IEnumerable<TemplateControlDto> GetTemplateControlsWithConfig(int templateId,SelectionCriteriaDto selectionCriteria)
        {
            IEnumerable<TemplateControl> allControls = Context.TemplateControl.Where(e => e.BUId == selectionCriteria.BusinessUnit.Id && e.ProcessTypeId == selectionCriteria.ProcessTypeId);
            IEnumerable <TemplateControlDto> res;
          
                res = from tc in allControls
                      from tcc in Context.TemplateControlConfig.Where(e => e.TemplateId == templateId && e.TemplateControlId==tc.Id).DefaultIfEmpty()
                      select new TemplateControlDto { Label=tc.Label,SapField=tc.SapField,SapTable=tc.SapTable,
                          TemplateControlConfig = tcc!=null? _mapper.Map< TemplateControlConfig, TemplateControlConfigDto>( tcc):new TemplateControlConfigDto(templateId,tc.Id)};
           
            return res;
        }

       

    }
}

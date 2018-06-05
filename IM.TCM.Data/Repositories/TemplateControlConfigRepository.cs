using IM.TCM.Data.EF;
using IM.TCM.Data.Repositories.Interfaces;
using IM.TCM.Domain.Models;
using System.Linq;
using System.Collections.Generic;
using IM.TCM.Domain.Dtos;
using AutoMapper;

namespace IM.TCM.Data.Repositories
{
    public class TemplateControlConfigRepository : BaseRepository<TemplateControlConfig>, ITemplateControlConfigRepository
    {
        private readonly IMapper _mapper;
        public TemplateControlConfigRepository(TCMContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        
      
    }
}

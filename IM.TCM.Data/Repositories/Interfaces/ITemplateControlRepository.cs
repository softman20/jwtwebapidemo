using IM.TCM.Domain.Dtos;
using IM.TCM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IM.TCM.Data.Repositories.Interfaces
{
    public interface ITemplateControlRepository : IBaseRepository<TemplateControl>
    {
        IEnumerable<TemplateControlDto> GetTemplateControlsWithConfig(int templateId, SelectionCriteriaDto selectionCriteria);
    }
}

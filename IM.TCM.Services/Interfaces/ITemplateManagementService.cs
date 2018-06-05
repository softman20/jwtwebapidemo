using IM.TCM.Domain.Dtos;
using IM.TCM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IM.TCM.Services.Interfaces
{
    public interface ITemplateManagementService : IBaseService<TemplateControl>
    {
        IEnumerable<TemplateControlDto> GetTemplateControls(SelectionCriteriaDto selectionCriteria);
        IEnumerable<TemplateControlDto> AddNewTemplate(SelectionCriteriaDto selectionCriteria);
        bool UpdateTemplate(IEnumerable<TemplateControlDto> templateControls);
    }
}

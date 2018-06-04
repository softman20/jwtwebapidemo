﻿using IM.TCM.Domain.Dtos;
using IM.TCM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IM.TCM.Services.Interfaces
{
    public interface ITemplateControlService : IBaseService<TemplateControl>
    {
        IEnumerable<TemplateControl> GetTemplateControls(SelectionCriteriaDto selectionCriteria);
    }
}

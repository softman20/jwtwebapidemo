

using AutoMapper;
using IM.TCM.Data.Repositories.Interfaces;
using IM.TCM.Domain.Dtos;
using IM.TCM.Domain.Models;
using IM.TCM.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace IM.TCM.Services
{
    public class TemplateManagementService : BaseService<TemplateControl>, ITemplateManagementService
    {
        private readonly ITemplateControlRepository _templateControlRepository;
        private readonly ITemplateControlConfigRepository _templateControlConfigRepository;
        private readonly ITemplateRepository _templateRepository;
        private readonly IMapper _mapper;
        public TemplateManagementService(ITemplateControlRepository templateControlRepository, ITemplateRepository templateRepository, IMapper mapper, ITemplateControlConfigRepository templateControlConfigRepository) : base(templateControlRepository)
        {
            _templateControlRepository = templateControlRepository;
            _templateControlConfigRepository = templateControlConfigRepository;
            _templateRepository = templateRepository;
            _mapper = mapper;
        }

        public IEnumerable<TemplateControlDto> GetTemplateControls(SelectionCriteriaDto selectionCriteria)
        {
            //get template id
            int templateId = 0;
            Template theTemplate = _templateRepository.Find(e => e.BUId == selectionCriteria.BusinessUnit.Id && e.CompanyId == selectionCriteria.CompanyCode.Id && e.OrganizationId == selectionCriteria.Organization.Id 
            && e.ProcessTypeId == selectionCriteria.ProcessTypeId
             && e.AccountGroupId == selectionCriteria.AccountGroup.Id).FirstOrDefault();
            if (theTemplate != null)
            {
                templateId = theTemplate.Id;
                IEnumerable<TemplateControlDto> result = _templateControlRepository.GetTemplateControlsWithConfig(templateId, selectionCriteria);
                return result;
            }
            else return null;
        }

        public IEnumerable<TemplateControlDto> AddNewTemplate(SelectionCriteriaDto selectionCriteria)
        {
            Template newTemplate = new Template
            {
                BUId = selectionCriteria.BusinessUnit.Id,
                CompanyId = selectionCriteria.CompanyCode.Id,
                ProcessTypeId = selectionCriteria.ProcessTypeId,
                AccountGroupId = selectionCriteria.AccountGroup.Id,
                OrganizationId =selectionCriteria.Organization.Id
            };
            _templateRepository.Add(newTemplate);
            _templateRepository.SaveChanges();

            IEnumerable<TemplateControlDto> result = _templateControlRepository.GetTemplateControlsWithConfig(newTemplate.Id, selectionCriteria);
            return result;

        }

        public bool UpdateTemplate(IEnumerable<TemplateControlDto> templateControls)
        {
            int templateId = templateControls.FirstOrDefault().TemplateControlConfig.TemplateId;
            //delete old template config
            _templateControlConfigRepository.DeleteMulti(e => e.TemplateId == templateId);
            _templateControlConfigRepository.SaveChanges();
            //add new template control config

            foreach (var templateControl in templateControls)
            {

                var newTConfig = _mapper.Map<TemplateControlConfigDto, TemplateControlConfig>(templateControl.TemplateControlConfig);
                _templateControlConfigRepository.Add(newTConfig);
            }
            _templateControlConfigRepository.SaveChanges();
            return true;
        }

    }
}

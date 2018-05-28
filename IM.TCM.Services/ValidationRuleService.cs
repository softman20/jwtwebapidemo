

using AutoMapper;
using IM.TCM.Data.Enums;
using IM.TCM.Data.Repositories.Interfaces;
using IM.TCM.Domain.Dtos;
using IM.TCM.Domain.Models;
using IM.TCM.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace IM.TCM.Services
{
    public class ValidationRuleService : BaseService<ValidationRule>, IValidationRuleService
    {
        private readonly IValidationRuleRepository _validationRuleRepository;
        private readonly IUserAuthorizationRepository _userAuthorizationRepository;
        private readonly IMapper _mapper;
        public ValidationRuleService(IValidationRuleRepository validationRuleRepository, IMapper mapper, IUserAuthorizationRepository userAuthorizationRepository) : base(validationRuleRepository)
        {
            _validationRuleRepository = validationRuleRepository;
            _userAuthorizationRepository = userAuthorizationRepository;
            _mapper = mapper;
        }

        public IEnumerable<UserDto> GetValidationRulePotentielUsers(ValidationRuleDto validationRule)
        {
            return _mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<UserDto> >( _userAuthorizationRepository.Find(where: e => e.BUId == validationRule.BusinessUnit.Id && e.CompanyId == validationRule.CompanyCode.Id && e.ProcessTypeId == validationRule.ProcessType.Id,
                include: e => e.Include(p => p.User)).Select(e => e.User));
        }

      

    }
}

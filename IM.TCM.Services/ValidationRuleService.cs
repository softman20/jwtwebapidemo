

using AutoMapper;
using IM.TCM.Data.Enums;
using IM.TCM.Data.Repositories.Interfaces;
using IM.TCM.Domain.Dtos;
using IM.TCM.Domain.Models;
using IM.TCM.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using MoreLinq;
using System.Collections.Generic;
using System.Linq;

namespace IM.TCM.Services
{
    public class ValidationRuleService : BaseService<ValidationRule>, IValidationRuleService
    {
        private readonly IValidationRuleRepository _validationRuleRepository;
        private readonly IValidationRuleUserRoleRepository _validationRuleUserRoleRepository;
        private readonly IUserAuthorizationRepository _userAuthorizationRepository;
        private readonly IMapper _mapper;
        public ValidationRuleService(IValidationRuleUserRoleRepository validationRuleUserRoleRepository, IValidationRuleRepository validationRuleRepository, IMapper mapper, IUserAuthorizationRepository userAuthorizationRepository) : base(validationRuleRepository)
        {
            _validationRuleRepository = validationRuleRepository;
            _userAuthorizationRepository = userAuthorizationRepository;
            _validationRuleUserRoleRepository = validationRuleUserRoleRepository;
            _mapper = mapper;
        }

        public IEnumerable<UserDto> GetValidationRulePotentielUsers(ValidationRuleDto validationRule)
        {
            return _mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<UserDto>>(
                _userAuthorizationRepository.Find(
                    where: e => (e.BUId == validationRule.BusinessUnit.Id || e.BUId == -1) && (e.CompanyId == validationRule.CompanyCode.Id || e.CompanyId == -1) && (e.ProcessTypeId == validationRule.ProcessType.Id || e.ProcessTypeId == -1),
                    include: e => e.Include(p => p.User)).Select(e => e.User)).DistinctBy(e => e.Id).OrderBy(e=>e.FirstName);
        }

        public void DeleteValidationRule(int id)
        {
            ValidationRule validationRule = _validationRuleRepository.GetById(id);
            if (validationRule != null)
                _validationRuleRepository.Delete(validationRule);
        }
        public int AddValidationRule(ValidationRuleDto validationRule)
        {
            //delete validation rule if exist
            if (validationRule.Id > 0)
                this.Delete(validationRule.Id);
            //add validation rule
            ValidationRule newValidationRule = new ValidationRule
            {
                BUId = validationRule.BusinessUnit.Id,
                AccountGroupId = validationRule.AccountGroup.Id,
                CompanyId = validationRule.CompanyCode.Id,
                ProcessTypeId = validationRule.ProcessType.Id,
                RequestTypeId = validationRule.RequestType.Id
            };

            _validationRuleRepository.Add(newValidationRule);
            _validationRuleRepository.SaveChanges();
            //add validation rule user roles

            foreach (ValidationRuleUserRoleDto validationRuleUserRole in validationRule.ValidationRuleUserRoles)
            {
                _validationRuleUserRoleRepository.Add(new ValidationRuleUserRole
                {
                    RoleId = validationRuleUserRole.RoleId,
                    UserId = validationRuleUserRole.User.Id,
                    ValidationRuleId = newValidationRule.Id
                });
            }
            _validationRuleRepository.SaveChanges();
            return newValidationRule.Id;
        }
       public int AddValidationRuleFromCopy(ValidationRuleDto validationRule, ValidationRuleDto validationRuleToCompyFrom)
        {
            ValidationRule theValidationRule = _validationRuleRepository.Find(
                where: e => (e.BUId == validationRuleToCompyFrom.BusinessUnit.Id) && (e.CompanyId == validationRuleToCompyFrom.CompanyCode.Id) && (e.AccountGroupId == validationRuleToCompyFrom.AccountGroup.Id)
                && (e.ProcessTypeId == validationRuleToCompyFrom.ProcessType.Id) && e.RequestTypeId == validationRuleToCompyFrom.RequestType.Id).FirstOrDefault();

            if (theValidationRule != null)
            {
                //add validation rule
                ValidationRule newValidationRule = new ValidationRule
                {
                    BUId = validationRule.BusinessUnit.Id,
                    AccountGroupId = validationRule.AccountGroup.Id,
                    CompanyId = validationRule.CompanyCode.Id,
                    ProcessTypeId = validationRule.ProcessType.Id,
                    RequestTypeId = validationRule.RequestType.Id
                };

                _validationRuleRepository.Add(newValidationRule);
                _validationRuleRepository.SaveChanges();

                IEnumerable<ValidationRuleUserRole> validationRuleUserRoles = _validationRuleUserRoleRepository.Find(e => e.ValidationRuleId == theValidationRule.Id);
                //add validation rule user roles
                foreach (ValidationRuleUserRole validationRuleUserRole in validationRuleUserRoles)
                {
                    _validationRuleUserRoleRepository.Add(new ValidationRuleUserRole
                    {
                        RoleId = validationRuleUserRole.RoleId,
                        UserId = validationRuleUserRole.UserId,
                        ValidationRuleId = newValidationRule.Id
                    });
                }
                _validationRuleRepository.SaveChanges();

                return newValidationRule.Id;
            }
            else return 0;
          
        }

        public IEnumerable<ValidationRuleUserRoleDto> GetValidationRuleUserRoles(ValidationRuleDto validationRule)
        {
            IEnumerable<ValidationRuleUserRoleDto> result = null;

            ValidationRule theValidationRule = _validationRuleRepository.Find(
                where: e => (e.BUId == validationRule.BusinessUnit.Id) && (e.CompanyId == validationRule.CompanyCode.Id) && (e.AccountGroupId==validationRule.AccountGroup.Id)
                && (e.ProcessTypeId == validationRule.ProcessType.Id) && e.RequestTypeId == validationRule.RequestType.Id).FirstOrDefault();

            if (theValidationRule != null)
                result = _mapper.Map<IEnumerable<ValidationRuleUserRole>, IEnumerable<ValidationRuleUserRoleDto>>(_validationRuleUserRoleRepository
                    .Find(include: e => e.Include(p => p.User).Include(p => p.Role), where: e => e.ValidationRuleId == theValidationRule.Id));

            return result;
        }
    }
}

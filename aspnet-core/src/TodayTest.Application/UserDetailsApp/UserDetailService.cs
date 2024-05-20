using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TodayTest.Authorization;
using TodayTest.Authorization.Users;
using TodayTest.Enums;
using TodayTest.Models;
using TodayTest.UserDetailsApp.Dto;

namespace TodayTest.UserDetailsApp
{
    [AbpAuthorize(PermissionNames.Pages_UserDetails)]
    public class UserDetailService:AsyncCrudAppService<UserDetails, UserDetailsDto, int, UserDetailsPageDto>, IUserDetailService
    {
        private readonly IRepository<User, long> _userRepository;
        public UserDetailService(IRepository<UserDetails, int> repository, IRepository<User, long> _userrepo):base (repository) 
        {
            _userRepository = _userrepo;
        }

         public List<UserDetailsDto> GetUserDetails()
        {
            var temp = Repository.GetAll().ToList();    
            return new List<UserDetailsDto>(ObjectMapper.Map<List<UserDetailsDto>>(temp));  
        }

        public async Task<List<NameValueDto<long>>> GetNames()
        {
            var users = await _userRepository.GetAll().Select(user => new NameValueDto<long>
            {
                Name = user.Name,

                Value = user.Id
            }).ToListAsync();
            return users;
        } 
        public async Task<List<NameValueDto<long>>> GetEmails()
        {
            var emails = await _userRepository.GetAll().Select(user => new NameValueDto<long>
            {
                Name = user.EmailAddress,
                Value = user.Id
            }).ToListAsync();
            return emails;
        }
        public async Task<List<NameValueDto<int>>> GetGenders()
        {
            var genders = Enum.GetValues(typeof(Gender)).Cast<Gender>().Select(g => new NameValueDto<int>
            {
                Name = Enum.GetName(typeof(Gender), g),
                Value = (int)g

            }).ToList();
            return genders;
        }
        public async Task<List<NameValueDto<int>>> GetMaritalStatus()
        {
            var maritalStatus = Enum.GetValues(typeof(MaritalStatus)).Cast<MaritalStatus>().Select(m => new NameValueDto<int>
            {
                Name = Enum.GetName(typeof(MaritalStatus), m),
                Value = (int)m

            }).ToList();
            return maritalStatus;
        }
    
        protected override IQueryable<UserDetails> CreateFilteredQuery(UserDetailsPageDto input)
        {
            var query = Repository.GetAll()
                .Include(x => x.User)
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(),
                    x => x.FatherName.Contains(input.Keyword)
                        || x.MotherName.Contains(input.Keyword)
                        || x.User.Name.Contains(input.Keyword)|| x.User.Surname.Contains(input.Keyword)
                        || x.User.EmailAddress.Contains(input.Keyword)
                        || (input.Keyword.Equals("Male", StringComparison.OrdinalIgnoreCase)
                            && x.Gender == Gender.Male)
                        || (input.Keyword.Equals("Female", StringComparison.OrdinalIgnoreCase)
                            && x.Gender == Gender.Female)
                        || (input.Keyword.Equals("Others", StringComparison.OrdinalIgnoreCase)
                            && x.Gender == Gender.Others));
            return query;
        }


        protected override async Task<UserDetails> GetEntityByIdAsync(int id)
        {
            return await Repository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }

        protected override IQueryable<UserDetails> ApplySorting(IQueryable<UserDetails> query, UserDetailsPageDto input)
        {
            return query.OrderBy(r => r.FatherName );
        }


    }
}

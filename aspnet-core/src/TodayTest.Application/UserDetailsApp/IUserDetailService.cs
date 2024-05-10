using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodayTest.UserDetailsApp.Dto;

namespace TodayTest.UserDetailsApp
{
    public interface IUserDetailService:IApplicationService
    {
        List<UserDetailsDto> GetUserDetails();
    }
}

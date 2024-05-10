using System.Threading.Tasks;
using Abp.Application.Services;
using TodayTest.Authorization.Accounts.Dto;

namespace TodayTest.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}

using System.Threading.Tasks;
using Abp.Application.Services;
using TodayTest.Sessions.Dto;

namespace TodayTest.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

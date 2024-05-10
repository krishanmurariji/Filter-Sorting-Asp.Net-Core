using Abp.Application.Services;
using TodayTest.MultiTenancy.Dto;

namespace TodayTest.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}


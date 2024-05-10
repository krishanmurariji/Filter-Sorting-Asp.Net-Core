using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using TodayTest.Configuration.Dto;

namespace TodayTest.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TodayTestAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}

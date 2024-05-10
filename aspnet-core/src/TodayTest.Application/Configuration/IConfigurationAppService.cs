using System.Threading.Tasks;
using TodayTest.Configuration.Dto;

namespace TodayTest.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}

using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace TodayTest.Controllers
{
    public abstract class TodayTestControllerBase: AbpController
    {
        protected TodayTestControllerBase()
        {
            LocalizationSourceName = TodayTestConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}

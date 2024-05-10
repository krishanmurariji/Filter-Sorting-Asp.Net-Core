using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace TodayTest.Authorization
{
    public class TodayTestAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);



            var UserDetailsPassesPermission = context.CreatePermission(PermissionNames.Pages_UserDetails, L("User Details"), multiTenancySides: MultiTenancySides.Host);
            UserDetailsPassesPermission.CreateChildPermission(PermissionNames.Create_UserDetails, L("Create User Details"));
            UserDetailsPassesPermission.CreateChildPermission(PermissionNames.Update_UserDetails, L("Update User Details"));
            UserDetailsPassesPermission.CreateChildPermission(PermissionNames.Delete_UserDetails, L("Delete User Details"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, TodayTestConsts.LocalizationSourceName);
        }
    }
}

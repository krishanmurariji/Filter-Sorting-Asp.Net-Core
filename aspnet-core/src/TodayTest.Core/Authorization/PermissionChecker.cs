using Abp.Authorization;
using TodayTest.Authorization.Roles;
using TodayTest.Authorization.Users;

namespace TodayTest.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}

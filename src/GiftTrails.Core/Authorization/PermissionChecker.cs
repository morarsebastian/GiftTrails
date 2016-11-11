using Abp.Authorization;
using GiftTrails.Authorization.Roles;
using GiftTrails.MultiTenancy;
using GiftTrails.Users;

namespace GiftTrails.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}

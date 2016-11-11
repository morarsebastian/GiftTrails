using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNet.Identity;
using Abp.IdentityFramework;
using Abp.Runtime.Session;

namespace GiftTrails.Web.Controllers
{
    public abstract class GiftTrailsControllerBase: AbpController
    {

        protected GiftTrailsControllerBase()
        {
            LocalizationSourceName = GiftTrailsConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
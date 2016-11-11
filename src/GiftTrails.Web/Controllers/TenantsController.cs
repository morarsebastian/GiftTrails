using Abp.AspNetCore.Mvc.Authorization;
using GiftTrails.Authorization;
using GiftTrails.MultiTenancy;
using Microsoft.AspNetCore.Mvc;

namespace GiftTrails.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : GiftTrailsControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public ActionResult Index()
        {
            var output = _tenantAppService.GetTenants();
            return View(output);
        }
    }
}
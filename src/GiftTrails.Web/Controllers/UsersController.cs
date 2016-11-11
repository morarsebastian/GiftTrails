using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using GiftTrails.Authorization;
using GiftTrails.Users;
using Microsoft.AspNetCore.Mvc;

namespace GiftTrails.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : GiftTrailsControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _userAppService.GetUsers();
            return View(output);
        }
    }
}
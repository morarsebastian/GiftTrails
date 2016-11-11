using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GiftTrails.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : GiftTrailsControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
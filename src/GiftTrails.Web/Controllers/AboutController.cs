using Microsoft.AspNetCore.Mvc;

namespace GiftTrails.Web.Controllers
{
    public class AboutController : GiftTrailsControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
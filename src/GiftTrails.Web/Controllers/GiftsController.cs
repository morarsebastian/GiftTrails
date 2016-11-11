using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GiftTrails.Gifts;
using GiftTrails.Web.Models.Gifts;

namespace GiftTrails.Web.Controllers
{
    public class GiftsController : GiftTrailsControllerBase
    {
        private readonly IGiftAppService _giftAppService;

        public GiftsController(IGiftAppService giftAppService)
        {
            _giftAppService = giftAppService;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _giftAppService.GetAll();
            var model = new IndexViewModel(output.Items);
            return View(model);
        }
    }
}
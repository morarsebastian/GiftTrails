using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GiftTrails.Trails;
using GiftTrails.Trails.Dtos;
using GiftTrails.Web.Models.Trails;
using GiftTrails.Sessions;
using Abp.Runtime.Session;

namespace GiftTrails.Web.Controllers
{
    public class TrailsController : GiftTrailsControllerBase
    {
        private readonly ITrailAppService _trailAppService;

        public TrailsController(
            ITrailAppService trailAppService)
        {
            _trailAppService = trailAppService;
        }

        public async Task<ActionResult> Index(GetAllTrailsInput input)
        {
            var output = await _trailAppService.GetAll(input);
            var model = new IndexViewModel(output.Items);
            return View(model);
        }

        public async Task<ActionResult> Create(int giftId)
        {
            var model = new CreateTrailViewModel(0, giftId);
            if (AbpSession != null && AbpSession.UserId.HasValue)
            {
                model = new CreateTrailViewModel(AbpSession.UserId.Value, giftId);
            }
            else
            {
                // SMTODO: We need to take the user from somewhere until then redirect to login
                return RedirectToAction("Login", "Account");
            }

            return View(model);
        }
    }
}
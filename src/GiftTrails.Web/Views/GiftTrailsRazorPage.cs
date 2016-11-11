using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace GiftTrails.Web.Views
{
    public abstract class GiftTrailsRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected GiftTrailsRazorPage()
        {
            LocalizationSourceName = GiftTrailsConsts.LocalizationSourceName;
        }
    }
}

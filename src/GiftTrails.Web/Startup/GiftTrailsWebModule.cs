using System.Reflection;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using GiftTrails.Configuration;
using GiftTrails.EntityFramework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Zero.Configuration;

namespace GiftTrails.Web.Startup
{
    [DependsOn(
        typeof(GiftTrailsApplicationModule), 
        typeof(GiftTrailsEntityFrameworkModule), 
        typeof(AbpAspNetCoreModule))]
    public class GiftTrailsWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public GiftTrailsWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(GiftTrailsConsts.ConnectionStringName);

            //Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            Configuration.Navigation.Providers.Add<GiftTrailsNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(GiftTrailsApplicationModule).Assembly
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
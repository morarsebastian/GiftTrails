using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using GiftTrails.Authorization;

namespace GiftTrails
{
    [DependsOn(
        typeof(GiftTrailsCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class GiftTrailsApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<GiftTrailsAuthorizationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
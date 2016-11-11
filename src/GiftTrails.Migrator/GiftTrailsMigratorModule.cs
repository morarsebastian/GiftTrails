using System.Data.Entity;
using System.Reflection;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;
using GiftTrails.Configuration;
using GiftTrails.EntityFramework;

namespace GiftTrails.Migrator
{
    [DependsOn(typeof(GiftTrailsEntityFrameworkModule))]
    public class GiftTrailsMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public GiftTrailsMigratorModule()
        {
            _appConfiguration = AppConfigurations.Get(
                typeof(GiftTrailsMigratorModule).Assembly.GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Database.SetInitializer<GiftTrailsDbContext>(null);

            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                GiftTrailsConsts.ConnectionStringName
                );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(typeof(IEventBus), () =>
            {
                IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                );
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
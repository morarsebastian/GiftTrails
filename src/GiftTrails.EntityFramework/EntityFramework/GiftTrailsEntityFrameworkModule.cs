using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;

namespace GiftTrails.EntityFramework
{
    [DependsOn(
        typeof(GiftTrailsCoreModule), 
        typeof(AbpZeroEntityFrameworkModule))]
    public class GiftTrailsEntityFrameworkModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<GiftTrailsDbContext>());
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
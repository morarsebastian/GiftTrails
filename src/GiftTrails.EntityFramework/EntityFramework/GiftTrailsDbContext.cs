using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using Microsoft.Extensions.Configuration;
using GiftTrails.Authorization.Roles;
using GiftTrails.Configuration;
using GiftTrails.MultiTenancy;
using GiftTrails.Users;
using GiftTrails.Web;
using GiftTrails.Gifts;
using GiftTrails.Trails;

namespace GiftTrails.EntityFramework
{
    [DbConfigurationType(typeof(GiftTrailsDbConfiguration))]
    public class GiftTrailsDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        /* Define an IDbSet for each entity of the application */
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<Trail> Trails { get; set; }

        /* Default constructor is needed for EF command line tool. */
        public GiftTrailsDbContext()
            : base(GetConnectionString())
        {

        }

        private static string GetConnectionString()
        {
            var configuration = AppConfigurations.Get(
                WebContentDirectoryFinder.CalculateContentRootFolder()
                );

            return configuration.GetConnectionString(
                GiftTrailsConsts.ConnectionStringName
                );
        }

        /* This constructor is used by ABP to pass connection string.
         * Notice that, actually you will not directly create an instance of GiftTrailsDbContext since ABP automatically handles it.
         */
        public GiftTrailsDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        /* This constructor is used in tests to pass a fake/mock connection. */
        public GiftTrailsDbContext(DbConnection dbConnection)
            : base(dbConnection, true)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trail>().Property(a => a.Latitude).HasPrecision(18, 9);
            modelBuilder.Entity<Trail>().Property(a => a.Longitude).HasPrecision(18, 9);

            base.OnModelCreating(modelBuilder);
        }
    }

    public class GiftTrailsDbConfiguration : DbConfiguration
    {
        public GiftTrailsDbConfiguration()
        {
            SetProviderServices(
                "System.Data.SqlClient",
                System.Data.Entity.SqlServer.SqlProviderServices.Instance
            );
        }
    }
}

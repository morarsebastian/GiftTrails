using System.Linq;
using GiftTrails.EntityFramework;
using GiftTrails.MultiTenancy;

namespace GiftTrails.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly GiftTrailsDbContext _context;

        public DefaultTenantCreator(GiftTrailsDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}

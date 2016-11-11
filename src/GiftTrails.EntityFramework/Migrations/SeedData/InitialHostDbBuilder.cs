using GiftTrails.EntityFramework;
using EntityFramework.DynamicFilters;

namespace GiftTrails.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly GiftTrailsDbContext _context;

        public InitialHostDbBuilder(GiftTrailsDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}

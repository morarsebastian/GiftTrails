using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace GiftTrails.EntityFramework.Repositories
{
    public abstract class GiftTrailsRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<GiftTrailsDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected GiftTrailsRepositoryBase(IDbContextProvider<GiftTrailsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class GiftTrailsRepositoryBase<TEntity> : GiftTrailsRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected GiftTrailsRepositoryBase(IDbContextProvider<GiftTrailsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}

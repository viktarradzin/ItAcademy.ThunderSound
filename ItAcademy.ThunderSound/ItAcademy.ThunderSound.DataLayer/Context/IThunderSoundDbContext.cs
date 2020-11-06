using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ItAcademy.ThunderSound.DataLayer.Context
{
    public interface IThunderSoundDbContext
    {
        DbSet<TEntity> Set<TEntity>()
                where TEntity : class;

        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;
    }
}
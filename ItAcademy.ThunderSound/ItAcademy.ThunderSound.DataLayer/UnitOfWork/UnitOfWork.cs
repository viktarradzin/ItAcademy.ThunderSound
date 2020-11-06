using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ItAcademy.ThunderSound.DataLayer.Context;
using ItAcademy.ThunderSound.DomainLayer.UnitOfWork;

namespace ItAcademy.ThunderSound.DataLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IThunderSoundDbContext db;

        public UnitOfWork(IThunderSoundDbContext db)
        {
            this.db = db;
        }

        public DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class
        {
            return db.Entry(entity);
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public DbSet<TEntity> Set<TEntity>()
            where TEntity : class
        {
            return db.Set<TEntity>();
        }
    }
}
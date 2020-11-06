using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Repositories;
using ItAcademy.ThunderSound.DomainLayer.UnitOfWork;

namespace ItAcademy.ThunderSound.DataLayer
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        private readonly IUnitOfWork unitOfWork;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(TEntity obj)
        {
            DbSet().Add(obj);
        }

        public void Delete(TEntity obj)
        {
            DbSet().Remove(obj);
        }

        public void DeleteById(int id)
        {
            Delete(Get(id));
        }

        public TEntity Get(int id)
        {
            return DbSet().Find(id);
        }

        public List<TEntity> GetAll()
        {
            return DbSet().ToList();
        }

        public void Update(TEntity obj)
        {
            DbSet().AddOrUpdate(obj);
        }

        protected IQueryable<TEntity> GetQueryableItems()
        {
            return DbSet().AsQueryable();
        }

        private DbSet<TEntity> DbSet()
        {
            return unitOfWork.Set<TEntity>();
        }
    }
}
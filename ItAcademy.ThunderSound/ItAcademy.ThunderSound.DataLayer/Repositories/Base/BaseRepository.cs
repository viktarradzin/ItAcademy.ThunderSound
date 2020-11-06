using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Repositories;

namespace ItAcademy.ThunderSound.DataLayer
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        public virtual bool Add(TEntity obj)
        {
            //Context
            return false;
        }

        public virtual bool Update(TEntity obj)
        {
            return false;
        }

        public virtual bool Delete(TEntity obj)
        {
            return false;
        }

        public virtual List<TEntity> GetAll()
        {
            return null;
        }
    }
}

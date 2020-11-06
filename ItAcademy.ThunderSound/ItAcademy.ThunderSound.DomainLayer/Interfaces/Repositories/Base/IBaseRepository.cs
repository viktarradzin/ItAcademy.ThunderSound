using System.Collections.Generic;

namespace ItAcademy.ThunderSound.DomainLayer.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        //Add
        bool Add(TEntity obj);

        //update
        bool Update(TEntity obj);

        //delete
        bool Delete(TEntity obj);

        //get
        List<TEntity> GetAll();
    }
}

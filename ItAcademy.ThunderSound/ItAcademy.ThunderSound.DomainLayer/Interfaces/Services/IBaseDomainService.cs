using System.Collections.Generic;

namespace ItAcademy.ThunderSound.DomainLayer.Interfaces.Services
{
    public interface IBaseDomainService<TEntity>
        where TEntity : class
    {
        void Add(TEntity obj);

        void Update(TEntity obj);

        void Delete(TEntity obj);

        void DeleteById(int id);

        List<TEntity> GetAll();

        TEntity Get(int id);

        void Edit();
    }
}
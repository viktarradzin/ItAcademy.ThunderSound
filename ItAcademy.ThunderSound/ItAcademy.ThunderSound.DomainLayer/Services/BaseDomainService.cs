using System.Collections.Generic;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Repositories;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Services;
using ItAcademy.ThunderSound.DomainLayer.UnitOfWork;

namespace ItAcademy.ThunderSound.DomainLayer.Services
{
    public class BaseDomainService<TEntity> : IBaseDomainService<TEntity>
        where TEntity : class
    {
        private readonly IBaseRepository<TEntity> baseRepository;

        private readonly IUnitOfWork unitOfWork;

        public BaseDomainService(IBaseRepository<TEntity> repository, IUnitOfWork unitOfWork)
        {
            baseRepository = repository;

            this.unitOfWork = unitOfWork;
        }

        public void Add(TEntity obj)
        {
            baseRepository.Add(obj);

            unitOfWork.SaveChanges();
        }

        public void Delete(TEntity obj)
        {
            baseRepository.Delete(obj);

            unitOfWork.SaveChanges();
        }

        public void DeleteById(int id)
        {
            baseRepository.Delete(Get(id));

            unitOfWork.SaveChanges();
        }

        public void Edit()
        {
            unitOfWork.SaveChanges();
        }

        public TEntity Get(int id)
        {
            return baseRepository.Get(id);
        }

        public List<TEntity> GetAll()
        {
            return baseRepository.GetAll();
        }

        public void Update(TEntity obj)
        {
            // todo for what this method?
        }
    }
}

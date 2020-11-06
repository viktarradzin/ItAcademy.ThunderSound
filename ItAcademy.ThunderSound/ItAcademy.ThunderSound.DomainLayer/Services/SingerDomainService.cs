using System.Collections.Generic;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Repositories;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Services;
using ItAcademy.ThunderSound.DomainLayer.Models;
using ItAcademy.ThunderSound.DomainLayer.UnitOfWork;

namespace ItAcademy.ThunderSound.DomainLayer.Services
{
    public class SingerDomainService : ISingerDomainService
    {
        private readonly ISingerRepository singerRepository;

        private readonly IUnitOfWork unitOfWork;

        public SingerDomainService(ISingerRepository repository, IUnitOfWork unitOfWork)
        {
            singerRepository = repository;

            this.unitOfWork = unitOfWork;
        }

        public void Add(SingerModel obj)
        {
            singerRepository.Add(obj);

            unitOfWork.SaveChanges();
        }

        public bool BelongSingerToTheGenre(int singerId, int genreId)
        {
            return singerRepository.BelongSingerToTheGenre(singerId, genreId);
        }

        public void Delete(SingerModel obj)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(int id)
        {
            singerRepository.DeleteById(id);

            unitOfWork.SaveChanges();
        }

        public void Edit()
        {
            unitOfWork.SaveChanges();
        }

        public SingerModel GetSingerByIdWithGenre(int id)
        {
            return singerRepository.GetSingerByIdWithGenre(id);
        }

        public List<SingerModel> GetAll()
        {
            return singerRepository.GetAll();
        }

        public List<SingerModel> GetAllSingersWithGenre()
        {
            return singerRepository.GetAllSingersWithGenre();
        }

        public List<SingerModel> GetSingersByGenreId(int id)
        {
            return singerRepository.GetSingersByGenreId(id);
        }

        public List<SingerModel> GetTopFivePopularSingers()
        {
            throw new System.NotImplementedException();
        }

        public void Update(SingerModel obj)
        {
            throw new System.NotImplementedException();
        }

        public List<SingerModel> GetSingersModelViewByIdWithGenre(int id)
        {
            throw new System.NotImplementedException();
        }

        public SingerModel Get(int id)
        {
            return singerRepository.Get(id);
        }
    }
}
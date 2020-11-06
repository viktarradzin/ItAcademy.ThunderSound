using System.Collections.Generic;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Repositories;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Services;
using ItAcademy.ThunderSound.DomainLayer.Models;

namespace ItAcademy.ThunderSound.DomainLayer.Services
{
    public class SingerService : ISingerService
    {
        private readonly ISingerRepository singerRepository;
        public SingerService(ISingerRepository repository)
        {
            this.singerRepository = repository;
        }
        #region Crud
        public bool AddSinger(Singer obj)
        {
            singerRepository.Add(obj);

            return false;
        }

        public bool AddSingers(List<Singer> obj)
        {
            foreach(Singer singer in obj)
            {
                singerRepository.Add(singer);
            }
            
            return false;
        }

        public bool UpdateSinger(Singer obj)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateSingers(List<Singer> obj)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteSinger(Singer obj)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteSingers(List<Singer> obj)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        public List<Singer> GetAllSingers()
        {
            return singerRepository.GetAll();
        }

        public List<Singer> GetTopFiveSingers()
        {
            throw new System.NotImplementedException();
        }

        
    }
}

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Repositories;
using ItAcademy.ThunderSound.DomainLayer.Models;
using ItAcademy.ThunderSound.DomainLayer.UnitOfWork;

namespace ItAcademy.ThunderSound.DataLayer.Repositories
{
    public class SingerRepository : BaseRepository<SingerModel>, ISingerRepository
    {
        public SingerRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public List<SingerModel> GetAllSingersWithGenre()
        {
            return GetQueryableItems().Include(x => x.Genre).ToList();
        }

        public List<SingerModel> GetTopFivePopularSingers()
        {
            return GetQueryableItems().OrderBy(x => x.SingerId).Take(5).ToList();
        }

        public List<SingerModel> GetSingersByGenreId(int id)
        {
            return GetQueryableItems().Where(x => x.Genre.GenreId == id).ToList();
        }

        public bool BelongSingerToTheGenre(int singerId, int genreId)
        {
            return GetQueryableItems().Any(x => x.Genre.GenreId == genreId && x.SingerId == singerId);
        }

        public SingerModel GetSingerByIdWithGenre(int id)
        {
            return GetQueryableItems().Include(x => x.Genre).Where(x => x.SingerId == id).FirstOrDefault();
        }
    }
}
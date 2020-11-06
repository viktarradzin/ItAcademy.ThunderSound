using System.Collections.Generic;
using ItAcademy.ThunderSound.DomainLayer.Models;

namespace ItAcademy.ThunderSound.DomainLayer.Interfaces.Repositories
{
    public interface ISingerRepository : IBaseRepository<SingerModel>
    {
        List<SingerModel> GetTopFivePopularSingers();

        List<SingerModel> GetSingersByGenreId(int id);

        List<SingerModel> GetAllSingersWithGenre();

        SingerModel GetSingerByIdWithGenre(int id);

        bool BelongSingerToTheGenre(int singerId, int genreId);
    }
}
using System.Collections.Generic;
using ItAcademy.ThunderSound.DomainLayer.Models;

namespace ItAcademy.ThunderSound.DomainLayer.Interfaces.Services
{
    public interface ISingerDomainService : IBaseDomainService<SingerModel>
    {
        List<SingerModel> GetSingersModelViewByIdWithGenre(int id);

        List<SingerModel> GetSingersByGenreId(int id);

        List<SingerModel> GetAllSingersWithGenre();

        SingerModel GetSingerByIdWithGenre(int id);

        bool BelongSingerToTheGenre(int singerId, int genreId);
    }
}
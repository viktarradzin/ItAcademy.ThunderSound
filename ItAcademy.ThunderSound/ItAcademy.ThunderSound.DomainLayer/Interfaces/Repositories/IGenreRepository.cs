using System.Collections.Generic;
using ItAcademy.ThunderSound.DomainLayer.Models;

namespace ItAcademy.ThunderSound.DomainLayer.Interfaces.Repositories
{
    public interface IGenreRepository : IBaseRepository<GenreModel>
    {
        List<GenreModel> GetTopFivePopularGenres();

        bool IsGenreExists(int genreId);
    }
}
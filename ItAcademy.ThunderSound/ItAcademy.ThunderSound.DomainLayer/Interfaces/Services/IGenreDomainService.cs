using System.Collections.Generic;
using ItAcademy.ThunderSound.DomainLayer.Models;

namespace ItAcademy.ThunderSound.DomainLayer.Interfaces.Services
{
    public interface IGenreDomainService : IBaseDomainService<GenreModel>
    {
        List<GenreModel> GetTopFivePopularGenres();

        bool IsGenreExists(int genreId);
     }
}
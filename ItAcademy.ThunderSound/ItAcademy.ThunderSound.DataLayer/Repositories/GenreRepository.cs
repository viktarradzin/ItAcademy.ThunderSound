using System.Collections.Generic;
using System.Linq;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Repositories;
using ItAcademy.ThunderSound.DomainLayer.Models;
using ItAcademy.ThunderSound.DomainLayer.UnitOfWork;

namespace ItAcademy.ThunderSound.DataLayer.Repositories
{
    public class GenreRepository : BaseRepository<GenreModel>, IGenreRepository
    {
        public GenreRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public List<GenreModel> GetTopFivePopularGenres()
        {
            return GetQueryableItems().OrderBy(x => x.GenreId).Take(5).ToList();
        }

        public bool IsGenreExists(int genreId)
        {
            return GetQueryableItems().Any(x => x.GenreId == genreId);
        }
    }
}
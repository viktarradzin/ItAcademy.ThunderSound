using System;
using System.Collections.Generic;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Repositories;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Services;
using ItAcademy.ThunderSound.DomainLayer.Models;
using ItAcademy.ThunderSound.DomainLayer.UnitOfWork;

namespace ItAcademy.ThunderSound.DomainLayer.Services
{
    public class GenreDomainService : BaseDomainService<GenreModel>, IGenreDomainService
    {
        private readonly IGenreRepository genreRepository;

        public GenreDomainService(IGenreRepository genreRepository, IUnitOfWork unitOfWork)
            : base(genreRepository, unitOfWork)
        {
            this.genreRepository = genreRepository;
        }

        public List<GenreModel> GetTopFivePopularGenres()
        {
            throw new NotImplementedException();
        }

        public bool IsGenreExists(int genreId)
        {
            return genreRepository.IsGenreExists(genreId);
        }
    }
}
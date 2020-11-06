using System.Collections.Generic;
using System.IO;
using System.Web;
using AutoMapper;
using ItAcademy.ThunderSound.Client.Models;
using ItAcademy.ThunderSound.Client.Services.Interfaces;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Services;
using ItAcademy.ThunderSound.DomainLayer.Models;

namespace ItAcademy.ThunderSound.Client.Services
{
    public class GenrePresentationService : IGenrePresentationService
    {
        private readonly IGenreDomainService genreDomainService;

        public GenrePresentationService(IGenreDomainService genreDomainService)
        {
            this.genreDomainService = genreDomainService;
        }

        public List<GenreViewModel> GetAllGenres()
        {
            var genres = genreDomainService.GetAll();

            var genresView = Mapper.Map<List<GenreViewModel>>(genres);

            return genresView;
        }

        public GenreViewModel GetGenreById(int id)
        {
            var genres = genreDomainService.Get(id);

            var genresView = Mapper.Map<GenreViewModel>(genres);

            return genresView;
        }

        public GenreViewModel EditGenre(int id)
        {
            return Mapper.Map<GenreViewModel>(genreDomainService.Get(id));
        }

        public void EditGenre(GenreViewModel genreView)
        {
            var genre = genreDomainService.Get(genreView.GenreId);

            Mapper.Map(genreView, genre);

            genreDomainService.Edit();
        }

        public void AddGenre(GenreViewModel genreView, HttpPostedFileBase uploadImage)
        {
            var genre = Mapper.Map<GenreViewModel, GenreModel>(genreView);

            if (uploadImage != null)
            {
                genre.Image = TransformPostedFileToByte(uploadImage);
            }

            genreDomainService.Add(genre);
        }

        public void DeleteGenreById(int id)
        {
            genreDomainService.DeleteById(id);
        }

        public bool IsGenreExists(int genreId)
        {
            return genreDomainService.IsGenreExists(genreId);
        }

        public byte[] GetImage(int id)
        {
            var genre = genreDomainService.Get(id);
            byte[] imageBytes = genre.Image;
            return imageBytes;
        }

        private byte[] TransformPostedFileToByte(HttpPostedFileBase uploadTrack)
        {
            byte[] trackData = null;

            using (var binaryReader = new BinaryReader(uploadTrack.InputStream))
            {
                trackData = binaryReader.ReadBytes(uploadTrack.ContentLength);
            }

            return trackData;
        }
    }
}
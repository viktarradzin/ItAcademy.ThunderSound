using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ItAcademy.ThunderSound.Client.Models;
using ItAcademy.ThunderSound.Client.Services.Interfaces;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Services;
using ItAcademy.ThunderSound.DomainLayer.Models;

namespace ItAcademy.ThunderSound.Client.Services
{
    public class SingerPresentationService : ISingerPresentationService
    {
        private readonly ISingerDomainService singerDomainService;

        private readonly IGenreDomainService genreDomainService;

        public SingerPresentationService(ISingerDomainService singerDomainService, IGenreDomainService genreDomainService)
        {
            this.singerDomainService = singerDomainService;
            this.genreDomainService = genreDomainService;
        }

        public List<SingerViewModel> GetAllSingers()
        {
            var singers = singerDomainService.GetAll();

            var singersViewModel = Mapper.Map<List<SingerViewModel>>(singers);

            return singersViewModel;
        }

        public List<SingerViewModel> GetAllSingersWithGenre()
        {
            var singers = singerDomainService.GetAllSingersWithGenre();

            var singersViewModel = Mapper.Map<List<SingerViewModel>>(singers);

            return singersViewModel;
        }

        public List<SingerViewModel> GetSingersByGenreId(int id)
        {
            var singers = singerDomainService.GetSingersByGenreId(id);

            var singersViewModel = Mapper.Map<List<SingerViewModel>>(singers);

            return singersViewModel;
        }

        public byte[] GetImage(int id)
        {
            var singerView = GetOneSingerViewByIdWithGenre(id);

            byte[] imageBytes = singerView.Image;

            return imageBytes;
        }

        public SingerViewModel GetOneSingerViewByIdWithGenre(int id)
        {
            var singer = singerDomainService.GetSingerByIdWithGenre(id);

            var singerView = Mapper.Map<SingerViewModel>(singer);

            singerView.SelectListGenres = GetGenresSelectList();

            return singerView;
        }

        public void AddSinger(SingerViewModel singerView, HttpPostedFileBase uploadImage)
        {
            var singer = Mapper.Map<SingerViewModel, SingerModel>(singerView);

            if (uploadImage != null)
            {
                singer.Image = TransformPostedFileToByte(uploadImage);
            }

            singer.Genre = genreDomainService.Get(singerView.Genre.GenreId);

            singerDomainService.Add(singer);
        }

        public void DeleteSingerById(int id)
        {
            singerDomainService.DeleteById(id);
        }

        public void EditSinger(SingerViewModel singerView, HttpPostedFileBase uploadImage)
        {
            var singer = singerDomainService.Get(singerView.SingerId);

            singer.SingerName = singerView.Name;

            if (uploadImage != null)
            {
                singer.Image = TransformPostedFileToByte(uploadImage);
            }

            singerDomainService.Edit();
        }

        public bool BelongSingerToTheGenre(TrackViewModel track)
        {
            return singerDomainService.BelongSingerToTheGenre(track.Singer.SingerId, track.Genre.GenreId);
        }

        public SingerViewModel GetCreateSingerView()
        {
            return new SingerViewModel
            {
               SelectListGenres = GetGenresSelectList()
            };
        }

        private SelectList GetGenresSelectList()
        {
            return new SelectList(genreDomainService.GetAll(), "GenreId", "GenreName");
        }

        private byte[] TransformPostedFileToByte(HttpPostedFileBase uploadImage)
        {
            byte[] imageData = null;

            using (var binaryReader = new BinaryReader(uploadImage.InputStream))
            {
                imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
            }

            return imageData;
        }
    }
}
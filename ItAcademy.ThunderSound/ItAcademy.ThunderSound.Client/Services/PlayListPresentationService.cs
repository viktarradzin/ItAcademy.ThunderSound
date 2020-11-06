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
    public class PlayListPresentationService : IPlayListPresentationService
    {
        private readonly IPlayListDomainService playListDomainService;

        private readonly IGenreDomainService genreDomainService;

        private readonly ISingerDomainService singerDomainService;

        private readonly ILabelDomainService labelDomainService;

        public PlayListPresentationService(
            IPlayListDomainService playListDomainService,
            IGenreDomainService genreDomainService,
            ISingerDomainService singerDomainService,
            ILabelDomainService labelDomainService)
        {
            this.playListDomainService = playListDomainService;

            this.genreDomainService = genreDomainService;

            this.singerDomainService = singerDomainService;

            this.labelDomainService = labelDomainService;
        }

        public byte[] GetImage(int id)
        {
            var playListView = playListDomainService.Get(id);

            byte[] imageBytes = playListView.Image;

            return imageBytes;
        }

        public List<PlayListViewModel> GetAllPlayLists()
        {
            var playLists = playListDomainService.GetAll();

            var playListView = Mapper.Map<List<PlayListViewModel>>(playLists);

            return playListView;
        }

        public PlayListViewModel GetPlayListById(int id)
        {
            var playList = playListDomainService.Get(id);

            var playListView = Mapper.Map<PlayListViewModel>(playList);

            return playListView;
        }

        public PlayListViewModel EditPlayList(int id)
        {
            var playListModel = playListDomainService.GetOnePlayListWithSingerandGenreAndLabelByPlayListId(id);

            var playListView = Mapper.Map<PlayListViewModel>(playListModel);

            playListView.SelectListGenres = GetGenresSelectList();

            playListView.SelectListSingers = GetSingersSelectList();

            playListView.SelectListLabels = GetLabelsSelectList();

            return playListView;
        }

        public void EditPlayList(PlayListViewModel playListView, HttpPostedFileBase uploadImage)
        {
            var playList = playListDomainService.Get(playListView.PlayListId);

            playListView.Genre = genreDomainService.Get(playListView.Genre.GenreId);

            playListView.Label = labelDomainService.Get(playListView.Label.LabelId);

            playListView.Singer = singerDomainService.Get(playListView.Singer.SingerId);

            Mapper.Map(playListView, playList);

            if (uploadImage != null)
            {
                playList.Image = TransformPostedFileToByte(uploadImage);
            }

            playListDomainService.Edit();
        }

        public void AddPlayList(PlayListViewModel playListView, HttpPostedFileBase uploadImage)
        {
            var playList = Mapper.Map<PlayListViewModel, PlayListModel>(playListView);

            playList.Genre = genreDomainService.Get(playListView.Genre.GenreId);

            playList.Label = labelDomainService.Get(playListView.Label.LabelId);

            playList.Singer = singerDomainService.Get(playListView.Singer.SingerId);

            if (uploadImage != null)
            {
                playList.Image = TransformPostedFileToByte(uploadImage);
            }

            playListDomainService.Add(playList);
        }

        public void DeletePlayListById(int id)
        {
            playListDomainService.DeleteById(id);
        }

        public bool BelongPlayListsToTheSinger(TrackViewModel track)
        {
            return playListDomainService.BelongPlayListToTheSinger(track.PlayList.PlayListId, track.Singer.SingerId);
        }

        public List<PlayListViewModel> GetPlayListsBySingerId(int id)
        {
            var playlists = playListDomainService.GetPlayListsBySingerId(id);

            var playlistsViewModel = Mapper.Map<List<PlayListViewModel>>(playlists);

            return playlistsViewModel;
        }

        public List<PlayListViewModel> GetAllPlayListsWithSingerandGenreandLabel()
        {
            var playLists = playListDomainService.GetAllPlayListsWithSingerandGenreandLabel();

            var playListView = Mapper.Map<List<PlayListViewModel>>(playLists);

            return playListView;
        }

        public PlayListViewModel GetCreatePlayListView()
        {
            return new PlayListViewModel
            {
                SelectListGenres = GetGenresSelectList(),
                SelectListSingers = GetSingersSelectList(),
                SelectListLabels = GetLabelsSelectList()
            };
        }

        public List<PlayListViewModel> GetThreePlayListWithLabelandSingerandGenreforMainPage()
        {
            var playLists = playListDomainService.GetThreePlayListWithLabelandSingerandGenreforMainPage();

            var playListView = Mapper.Map<List<PlayListViewModel>>(playLists);

            return playListView;
        }

        private SelectList GetGenresSelectList()
        {
            return new SelectList(genreDomainService.GetAll(), "GenreId", "GenreName");
        }

        private SelectList GetSingersSelectList()
        {
            return new SelectList(singerDomainService.GetAll(), "SingerId", "SingerName");
        }

        private SelectList GetLabelsSelectList()
        {
            return new SelectList(labelDomainService.GetAll(), "LabelId", "LabelName");
        }

        private SelectList GetPlayListsSelectList()
        {
            return new SelectList(playListDomainService.GetAll(), "PlayListId", "PlayListName");
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
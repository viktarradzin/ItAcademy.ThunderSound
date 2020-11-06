using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ItAcademy.ThunderSound.Client.Models;
using ItAcademy.ThunderSound.Client.Services.Interfaces;
using ItAcademy.ThunderSound.Client.Util.Mapper;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Services;
using ItAcademy.ThunderSound.DomainLayer.Models;

namespace ItAcademy.ThunderSound.Client.Services
{
    public class TrackPresentationService : ITrackPresentationService
    {
        private readonly ITrackDomainService trackDomainService;

        private readonly IGenreDomainService genreDomainService;

        private readonly ISingerDomainService singerDomainService;

        private readonly IPlayListDomainService playListDomainService;

        private readonly ISingerPresentationService singerPresentationService;

        private readonly IPlayListPresentationService playListPresentationService;

        public TrackPresentationService(ITrackDomainService trackDomainService, IGenreDomainService genreDomainService, ISingerDomainService singerDomainService, IPlayListDomainService playListDomainService, ISingerPresentationService singerPresentationService, IPlayListPresentationService playListPresentationService)
        {
            this.trackDomainService = trackDomainService;

            this.genreDomainService = genreDomainService;

            this.singerDomainService = singerDomainService;

            this.playListDomainService = playListDomainService;

            this.singerPresentationService = singerPresentationService;

            this.playListPresentationService = playListPresentationService;
        }

        public List<TrackViewModel> GetAllTracks()
        {
            var tracks = trackDomainService.GetAll();

            var tracksViewModel = Mapper.Map<List<TrackViewModel>>(tracks);

            return tracksViewModel;
        }

        public List<TrackViewModel> GetAllTracksWithSingerandGenresAndPlayLists()
        {
            var tracks = trackDomainService.GetAllTracksWithSingerandGenresAndPlayLists();

            var tracksView = Mapper.Map<List<TrackViewModel>>(tracks);

            return tracksView;
        }

        public MemoryStream MemoryStream(int id)
        {
            var track = trackDomainService.Get(id);

            var trackView = Mapper.Map<TrackViewModel>(track);

            byte[] trackBytes = trackView.File;

            return new MemoryStream(trackBytes);
        }

        public TrackViewModel GetOneTrackViewById(int id)
        {
            var track = trackDomainService.Get(id);

            var trackView = Mapper.Map<TrackViewModel>(track);

            return trackView;
        }

        public void DeleteTrackById(int id)
        {
            trackDomainService.DeleteById(id);
        }

        public TrackViewModel GetCreateTrackView()
        {
            return new TrackViewModel
            {
                SelectListGenres = GetGenresSelectList(),
                SelectListPlayLists = GetPlayListsSelectList(),
                SelectListSingers = GetSingersSelectList()
            };
        }

        public TrackViewModel GetCreateTrackViewByModel(TrackViewModel trackViewModel)
        {
            return new TrackViewModel
            {
                SelectListGenres = GetGenresSelectList(),
            };
        }

        public List<SelectListItem> GetSingersSelectListItem(string genreId)
        {
            int statId;
            List<SelectListItem> singerNames = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(genreId))
            {
                statId = Convert.ToInt32(genreId);

                List<SingerViewModel> singers = singerPresentationService.GetSingersByGenreId(statId);
                singers.ForEach(x =>
                {
                    singerNames.Add(new SelectListItem { Text = x.Name, Value = x.SingerId.ToString() });
                });
            }

            return singerNames;
        }

        public List<SelectListItem> GetPlayListsSelectListItem(string singerId)
        {
            int statId;
            List<SelectListItem> playListNames = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(singerId))
            {
                statId = Convert.ToInt32(singerId);
                List<PlayListViewModel> playLists = playListPresentationService.GetPlayListsBySingerId(statId);
                playLists.ForEach(x =>
                {
                playListNames.Add(new SelectListItem { Text = x.PlayListName, Value = x.PlayListId.ToString() });
                });
            }

            return playListNames;
        }

        public TrackViewModel EditTrack(int id)
        {
            var track = trackDomainService.GetOneTracksWithSingerandGenreAndPlayList(id);

            var trackView = Mapper.Map<TrackViewModel>(track);

            trackView.SelectListGenres = GetGenresSelectList();

            trackView.SelectListPlayLists = GetPlayListsSelectListItem(id.ToString());

            trackView.SelectListSingers = GetSingersSelectListItem(id.ToString());

            return trackView;
        }

        public void EditTrack(TrackViewModel trackView)
        {
            trackView.Genre = genreDomainService.Get(trackView.Genre.GenreId);

            trackView.PlayList = playListDomainService.Get(trackView.PlayList.PlayListId);

            trackView.Singer = singerDomainService.Get(trackView.Singer.SingerId);

            var track = trackDomainService.Get(trackView.TrackId);

            TrackMapper.TrackViewToTrack(trackView, track);

            trackDomainService.Edit();
        }

        public void AddTrack(TrackViewModel trackView)
        {
            var track = Mapper.Map<TrackViewModel, TrackModel>(trackView);

            track.File = TransformPostedFileToByte(trackView.UploadTrack);

            track.Genre = genreDomainService.Get(trackView.Genre.GenreId);

            track.PlayList = playListDomainService.Get(trackView.PlayList.PlayListId);

            track.Singer = singerDomainService.Get(trackView.Singer.SingerId);

            trackDomainService.Add(track);
        }

        public List<TrackViewModel> GetSixRandomTrackWithPlayListImage()
        {
            var sixRandomTracks = trackDomainService.GetSixRandomTrackWithPlayListImage();
            var tracksViewModel = Mapper.Map<List<TrackViewModel>>(sixRandomTracks);
            return tracksViewModel;
        }

        public byte[] GetImage(int id)
        {
            var track = trackDomainService.GetOneTracksWithSingerandGenreAndPlayList(id);

            byte[] imageBytes = track.PlayList.Image;

            return imageBytes;
        }

        public List<TrackViewModel> GetTracksWithPlayListandSingerByGenreId(int genreId)
        {
            var tracks = trackDomainService.GetTracksWithPlayListandSingerByGenreId(genreId);
            var tracksViewModel = Mapper.Map<List<TrackViewModel>>(tracks);
            return tracksViewModel;
        }

        public List<TrackViewModel> GetTracksWithGenreWithSingerByPlayListId(int playListId)
        {
            var tracks = trackDomainService.GetTracksWithGenreWithSingerByPlayListId(playListId);
            var tracksViewModel = Mapper.Map<List<TrackViewModel>>(tracks);
            return tracksViewModel;
        }

        public List<TrackViewModel> GetTracksWithGenreWithPlayListBySingerId(int singerId)
        {
            var tracks = trackDomainService.GetTracksWithGenreWithPlayListBySingerId(singerId);
            var tracksViewModel = Mapper.Map<List<TrackViewModel>>(tracks);
            return tracksViewModel;
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

        private SelectList GetGenresSelectList()
        {
            return new SelectList(genreDomainService.GetAll(), "GenreId", "GenreName");
        }

        private SelectList GetSingersSelectList()
        {
            return new SelectList(singerDomainService.GetAll(), "SingerId", "SingerName");
        }

        private SelectList GetPlayListsSelectList()
        {
            return new SelectList(playListDomainService.GetAll(), "PlayListId", "PlayListName");
        }
    }
}
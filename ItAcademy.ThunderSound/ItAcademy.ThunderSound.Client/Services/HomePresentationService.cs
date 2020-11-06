using System.Collections.Generic;
using ItAcademy.ThunderSound.Client.Models;
using ItAcademy.ThunderSound.Client.Services.Interfaces;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Services;

namespace ItAcademy.ThunderSound.Client.Services
{
    public class HomePresentationService : IHomePresentationService
    {
        private ITrackPresentationService trackPresentationService;
        private IPlayListPresentationService playListPresentationService;

        private ITrackDomainService trackDomainService;

        public HomePresentationService(ITrackPresentationService trackPresentationService, ISingerPresentationService singerPresentationService, ITrackDomainService trackDomainService, IPlayListPresentationService playListPresentationService)
        {
             this.trackPresentationService = trackPresentationService;
             this.trackDomainService = trackDomainService;
             this.playListPresentationService = playListPresentationService;
        }

        public List<TrackViewModel> GetSixRandomTrackWithPlayList()
        {
            return trackPresentationService.GetSixRandomTrackWithPlayListImage();
        }

        public List<PlayListViewModel> GetThreePlayListWithforMainPage()
        {
            return playListPresentationService.GetThreePlayListWithLabelandSingerandGenreforMainPage();
        }

        public byte[] GetImage(int id)
        {
            var track = trackDomainService.GetOneTracksWithSingerandGenreAndPlayList(id);

            byte[] imageBytes = track.PlayList.Image;

            return imageBytes;
        }
    }
}
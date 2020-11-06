using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using ItAcademy.ThunderSound.Client.Models;

namespace ItAcademy.ThunderSound.Client.Services.Interfaces
{
    public interface ITrackPresentationService
    {
        List<TrackViewModel> GetAllTracks();

        List<TrackViewModel> GetAllTracksWithSingerandGenresAndPlayLists();

        List<TrackViewModel> GetSixRandomTrackWithPlayListImage();

        List<TrackViewModel> GetTracksWithPlayListandSingerByGenreId(int genreId);

        List<TrackViewModel> GetTracksWithGenreWithSingerByPlayListId(int playListId);

        List<TrackViewModel> GetTracksWithGenreWithPlayListBySingerId(int singerId);

        List<SelectListItem> GetSingersSelectListItem(string genreId);

        List<SelectListItem> GetPlayListsSelectListItem(string singerId);

        MemoryStream MemoryStream(int id);

        TrackViewModel GetOneTrackViewById(int id);

        TrackViewModel GetCreateTrackView();

        TrackViewModel EditTrack(int id);

        void DeleteTrackById(int id);

        void AddTrack(TrackViewModel trackView);

        void EditTrack(TrackViewModel trackView);

        byte[] GetImage(int id);
    }
}

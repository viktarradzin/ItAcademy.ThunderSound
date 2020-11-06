using System.Collections.Generic;
using ItAcademy.ThunderSound.DomainLayer.Models;

namespace ItAcademy.ThunderSound.DomainLayer.Interfaces.Services
{
    public interface ITrackDomainService : IBaseDomainService<TrackModel>
    {
        List<TrackModel> GetAllTracksWithSingerandGenresAndPlayLists();

        List<TrackModel> GetTracksWithPlayListandSingerByGenreId(int genreId);

        List<TrackModel> GetTracksWithGenreWithSingerByPlayListId(int playListId);

        List<TrackModel> GetTracksWithGenreWithPlayListBySingerId(int singerId);

        List<TrackModel> GetTopFivePopularTracks();

        TrackModel GetOneTracksWithSingerandGenreAndPlayList(int id);

        List<TrackModel> GetSixRandomTrackWithPlayListImage();
    }
}
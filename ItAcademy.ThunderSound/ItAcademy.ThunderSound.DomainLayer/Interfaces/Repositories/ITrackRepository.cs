using System.Collections.Generic;
using ItAcademy.ThunderSound.DomainLayer.Models;

namespace ItAcademy.ThunderSound.DomainLayer.Interfaces.Repositories
{
    public interface ITrackRepository : IBaseRepository<TrackModel>
    {
        List<TrackModel> GetTopFivePopularTracks();

        List<TrackModel> GetAllTracksWithSingerandGenresAndPlayLists();

        List<TrackModel> GetSixRandomTrackWithPlayListImage();

        List<TrackModel> GetTracksWithPlayListandSingerByGenreId(int id);

        List<TrackModel> GetTracksWithGenreWithSingerByPlayListId(int id);

        List<TrackModel> GetTracksWithGenreWithPlayListBySingerId(int id);

        TrackModel GetOneTracksWithSingerandGenreAndPlayList(int id);
    }
}
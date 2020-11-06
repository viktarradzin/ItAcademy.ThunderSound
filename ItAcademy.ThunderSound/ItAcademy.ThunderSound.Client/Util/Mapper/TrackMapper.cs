using ItAcademy.ThunderSound.Client.Models;
using ItAcademy.ThunderSound.DomainLayer.Models;

namespace ItAcademy.ThunderSound.Client.Util.Mapper
{
    public static class TrackMapper
    {
        public static void TrackViewToTrack(TrackViewModel trackView, TrackModel track)
        {
            track.TrackId = trackView.TrackId;

            track.TrackName = trackView.TrackName;

            track.Genre = trackView.Genre;

            track.PlayList = trackView.PlayList;

            track.Singer = trackView.Singer;
        }
    }
}
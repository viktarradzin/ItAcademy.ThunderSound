using System.Collections.Generic;
using ItAcademy.ThunderSound.DomainLayer.Models;

namespace ItAcademy.ThunderSound.DomainLayer.Interfaces.Services
{
    public interface ITrackService
    {
        #region Crud
        #region Adding
        bool AddTrack(Track obj);

        bool AddTracks(List<Track> obj);
        #endregion

        #region Updating
        bool UpdateTrack(Track obj);

        bool UpdateTracks(List<Track> obj);
        #endregion

        #region Deleting
        bool DeleteTrack(int id);

        bool DeleteTracks(int[] ids);
        #endregion
        #endregion

        List<Track> GetAllTracks();

        List<Track> GetTopFive();
    }
}

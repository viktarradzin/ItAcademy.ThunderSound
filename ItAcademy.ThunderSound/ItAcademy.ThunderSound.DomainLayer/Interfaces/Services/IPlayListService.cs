using System.Collections.Generic;
using ItAcademy.ThunderSound.DomainLayer.Models;

namespace ItAcademy.ThunderSound.DomainLayer.Interfaces.Services
{
    public interface IPlayListService
    {
        #region Adding
        bool AddPlayList(PlayList obj);
        bool AddPlayLists(List<PlayList> obj);
        #endregion
            
        #region Updating
        bool Update(PlayList obj);

        bool UpdatePlayLists(List<PlayList> obj);
        #endregion

        #region Deleting
        bool DeletePlayList(PlayList obj);

        bool DeletePlayLists(List<PlayList> obj);
        #endregion

        List<PlayList> GetAllPlayLists();

        List<PlayList> GetTopFivePlayLists();
    }
}

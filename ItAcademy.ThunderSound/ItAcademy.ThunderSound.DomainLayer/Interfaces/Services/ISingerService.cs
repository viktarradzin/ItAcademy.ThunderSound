using System.Collections.Generic;
using ItAcademy.ThunderSound.DomainLayer.Models;

namespace ItAcademy.ThunderSound.DomainLayer.Interfaces.Services
{
    public interface ISingerService
    {
        #region Adding
        bool AddSinger(Singer obj);

        bool AddSingers(List<Singer> obj);
        #endregion

        #region Updating
        bool UpdateSinger(Singer obj);

        bool UpdateSingers(List<Singer> obj);
        #endregion

        #region Deleting
        bool DeleteSinger(Singer obj);

        bool DeleteSingers(List<Singer> obj);
        #endregion
        
        List<Singer> GetAllSingers();

        List<Singer> GetTopFiveSingers();
    }
}

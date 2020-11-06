using System.Collections.Generic;
using ItAcademy.ThunderSound.DomainLayer.Models;

namespace ItAcademy.ThunderSound.DomainLayer.Interfaces.Services
{
    public interface IPlayListDomainService : IBaseDomainService<PlayListModel>
    {
        List<PlayListModel> GetTopFivePopularPlayLists();

        List<PlayListModel> GetPlayListsBySingerId(int id);

        List<PlayListModel> GetAllPlayListsWithSingerandGenreandLabel();

        PlayListModel GetOnePlayListWithSingerandGenreAndLabelByPlayListId(int playListId);

        List<PlayListModel> GetThreePlayListWithLabelandSingerandGenreforMainPage();

        bool BelongPlayListToTheSinger(int playListId, int singerId);
    }
}
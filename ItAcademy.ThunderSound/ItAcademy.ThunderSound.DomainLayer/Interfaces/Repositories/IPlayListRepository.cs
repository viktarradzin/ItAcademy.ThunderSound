using System.Collections.Generic;
using ItAcademy.ThunderSound.DomainLayer.Models;

namespace ItAcademy.ThunderSound.DomainLayer.Interfaces.Repositories
{
    public interface IPlayListRepository : IBaseRepository<PlayListModel>
    {
        List<PlayListModel> GetTopFivePopularPlayLists();

        List<PlayListModel> GetPlayListsBySingerId(int id);

        List<PlayListModel> GetAllPlayListsWithSingerandGenreandLabel();

        List<PlayListModel> GetThreePlayListWithLabelandSingerandGenreforMainPage();

        PlayListModel GetOnePlayListWithSingerandGenreAndLabelByPlayListId(int id);

        bool BelongPlayListToTheSinger(int playListId, int singerId);
    }
}
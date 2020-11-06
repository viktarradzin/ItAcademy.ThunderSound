using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Repositories;
using ItAcademy.ThunderSound.DomainLayer.Models;
using ItAcademy.ThunderSound.DomainLayer.UnitOfWork;

namespace ItAcademy.ThunderSound.DataLayer.Repositories
{
    public class PlayListRepository : BaseRepository<PlayListModel>, IPlayListRepository
    {
        public PlayListRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public List<PlayListModel> GetTopFivePopularPlayLists()
        {
            return GetQueryableItems().OrderBy(x => x.PlayListId).Take(5).ToList();
        }

        public List<PlayListModel> GetPlayListsBySingerId(int id)
        {
            return GetQueryableItems().Where(x => x.Singer.SingerId == id).ToList();
        }

        public bool BelongPlayListToTheSinger(int playListId, int singerId)
        {
            return GetQueryableItems().Any(x => x.PlayListId == playListId && x.Singer.SingerId == singerId);
        }

        public List<PlayListModel> GetAllPlayListsWithSingerandGenreandLabel()
        {
            return GetQueryableItems().Include(x => x.Genre).Include(x => x.Singer).Include(x => x.Label).ToList();
        }

        public List<PlayListModel> GetThreePlayListWithLabelandSingerandGenreforMainPage()
        {
            return GetQueryableItems().Include(x => x.Genre).Include(x => x.Singer).Include(x => x.Label).Take(3).ToList();
        }

        public PlayListModel GetOnePlayListWithSingerandGenreAndLabelByPlayListId(int id)
        {
            return GetQueryableItems().Include(x => x.Genre).Include(x => x.Singer).Include(x => x.Label).Where(x => x.PlayListId == id).First();
        }
    }
}
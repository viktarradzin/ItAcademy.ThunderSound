using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Repositories;
using ItAcademy.ThunderSound.DomainLayer.Models;
using ItAcademy.ThunderSound.DomainLayer.UnitOfWork;

namespace ItAcademy.ThunderSound.DataLayer.Repositories
{
    public class TrackRepository : BaseRepository<TrackModel>, ITrackRepository
    {
        public TrackRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public List<TrackModel> GetAllTracksWithSingerandGenresAndPlayLists()
        {
            return GetQueryableItems().Include(x => x.Singer).Include(x => x.Genre).Include(x => x.PlayList).ToList();
        }

        public TrackModel GetOneTracksWithSingerandGenreAndPlayList(int id)
        {
            return GetQueryableItems().Include(x => x.Singer).Include(x => x.Genre).Include(x => x.PlayList).First(x => x.TrackId == id);
        }

        public List<TrackModel> GetSixRandomTrackWithPlayListImage()
        {
            return GetQueryableItems().Include(x => x.PlayList).Include(x => x.Singer).Include(x => x.Genre).OrderBy(x => x.TrackName).Take(6).ToList();
        }

        public List<TrackModel> GetTopFivePopularTracks()
        {
            return GetQueryableItems().OrderBy(x => x.TrackId).Take(5).ToList();
        }

        public List<TrackModel> GetTracksWithGenreWithPlayListBySingerId(int id)
        {
            return GetQueryableItems().Include(x => x.PlayList).Include(x => x.Singer).Include(x => x.Genre).Where(x => x.Singer.SingerId == id).ToList();
        }

        public List<TrackModel> GetTracksWithGenreWithSingerByPlayListId(int id)
        {
            return GetQueryableItems().Include(x => x.PlayList).Include(x => x.Singer).Include(x => x.Genre).Where(x => x.PlayList.PlayListId == id).ToList();
        }

        public List<TrackModel> GetTracksWithPlayListandSingerByGenreId(int id)
        {
            return GetQueryableItems().Include(x => x.PlayList).Include(x => x.Singer).Include(x => x.Genre).Where(x => x.Genre.GenreId == id).ToList();
        }
    }
}